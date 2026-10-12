using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using QuanLySinhVien.BUL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.WinForms;

public partial class FrmSinhVien : Form
{
    private readonly SinhVienBUL svb = new();
    private readonly LopBus lopBus = new();
    private List<SinhVien> allSinhVien = new();
    private List<LopHoc> allLopHoc = new();
    private bool updatingControls;

    public FrmSinhVien()
    {
        InitializeComponent();
    }

    private bool IsDesignTime =>
        DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

    private void FrmSinhVien_Load(object? sender, EventArgs e)
    {
        if (IsDesignTime) return;
        updatingControls = true;
        try
        {
            allLopHoc = lopBus.GetAllLopHoc();
            cboLop.DisplayMember = nameof(LopHoc.TenLop);
            cboLop.ValueMember = nameof(LopHoc.MaLop);
            cboLop.DataSource = allLopHoc.Select(x => x.Copy()).ToList();

            cboLocLop.DisplayMember = nameof(LopHoc.TenLop);
            cboLocLop.ValueMember = nameof(LopHoc.MaLop);
            var filterLop = new List<LopHoc>
            {
                new() { MaLop = "", TenLop = "Tất cả lớp" }
            };
            filterLop.AddRange(allLopHoc.Select(x => x.Copy()));
            cboLocLop.DataSource = filterLop;
            cboTimKiem.SelectedIndex = 0;
            allSinhVien = svb.GetAllSinhVien();
            dgvSinhVien.DataSource = studentSource;
        }
        finally { updatingControls = false; }
        ResetEditor();
        ShowStudents(allSinhVien); // FormLoad hiển thị tất cả sinh viên.
    }

    private void FrmSinhVien_Shown(object? sender, EventArgs e)
    {
        if (!IsDesignTime) txtMaSV.Focus();
    }

    private void Filter_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (!IsDesignTime && !updatingControls) ApplySearch();
    }

    private void butLamMoi_Click(object? sender, EventArgs e) => ResetEditor();
    private void butTimKiem_Click(object? sender, EventArgs e) => ApplySearch();
    private void butTatCa_Click(object? sender, EventArgs e) => ShowAll();

    private void txtTuKhoa_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        ApplySearch();
        e.SuppressKeyPress = true;
    }

    private void SetEditMode(bool exists)
    {
        butThem.Enabled = !exists;
        butSua.Enabled = exists;
        butXoa.Enabled = exists;
    }

    private void ClearOtherFields()
    {
        txtHoTen.Clear();
        txtEmail.Clear();
        txtDienThoai.Clear();
        dtpNgaySinh.Value = DateTime.Today;
        rdoNam.Checked = true;
        numDiem.Value = 0;
        cboTrangThai.SelectedIndex = 0;
        // Giữ lớp đang chọn, tránh mất ngữ cảnh khi nhập sinh viên mới.
        if (cboLop.SelectedIndex < 0 && cboLop.Items.Count > 0)
            cboLop.SelectedIndex = 0;
    }

    private void ResetEditor()
    {
        updatingControls = true;
        try
        {
            errProvider.Clear();
            txtMaSV.Clear();
            ClearOtherFields();
            SetEditMode(false);
            dgvSinhVien.ClearSelection();
        }
        finally { updatingControls = false; }
        txtMaSV.Focus();
    }

    private void txtMaSV_TextChanged(object? sender, EventArgs e)
    {
        if (IsDesignTime || updatingControls) return;
        errProvider.Clear();
        var sv = svb.GetSinhVienById(txtMaSV.Text);
        updatingControls = true;
        try
        {
            if (sv == null)
            {
                ClearOtherFields(); // Không xóa mã đang gõ.
                SetEditMode(false);
            }
            else
            {
                txtHoTen.Text = sv.HoTen;
                txtEmail.Text = sv.Email;
                txtDienThoai.Text = sv.SoDienThoai;
                dtpNgaySinh.Value = sv.NgaySinh;
                rdoNam.Checked = sv.GioiTinh == "Nam";
                rdoNu.Checked = sv.GioiTinh == "Nữ";
                cboLop.SelectedValue = sv.MaLop;
                numDiem.Value = (decimal)sv.Diem;
                cboTrangThai.SelectedItem = sv.TrangThai;
                SetEditMode(true);
            }
        }
        finally { updatingControls = false; }
    }

    private void cboLop_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (IsDesignTime || updatingControls) return;
        updatingControls = true;
        try
        {
            cboLocLop.SelectedValue = cboLop.SelectedValue?.ToString() ?? "";
        }
        finally { updatingControls = false; }
        ApplySearch(); // Chọn lớp nhập liệu cũng lọc sinh viên của lớp đó.
    }

    private SinhVien ReadStudent() => new()
    {
        MaSV = txtMaSV.Text,
        HoTen = txtHoTen.Text,
        NgaySinh = dtpNgaySinh.Value.Date,
        GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
        Email = txtEmail.Text,
        SoDienThoai = txtDienThoai.Text,
        MaLop = cboLop.SelectedValue?.ToString() ?? "",
        Diem = (double)numDiem.Value,
        TrangThai = cboTrangThai.SelectedItem?.ToString() ?? ""
    };

    private Dictionary<string, Control> FieldControls() => new()
    {
        [nameof(SinhVien.MaSV)] = txtMaSV,
        [nameof(SinhVien.HoTen)] = txtHoTen,
        [nameof(SinhVien.Email)] = txtEmail,
        [nameof(SinhVien.SoDienThoai)] = txtDienThoai,
        [nameof(SinhVien.NgaySinh)] = dtpNgaySinh,
        [nameof(SinhVien.GioiTinh)] = rdoNam,
        [nameof(SinhVien.MaLop)] = cboLop,
        [nameof(SinhVien.Diem)] = numDiem,
        [nameof(SinhVien.TrangThai)] = cboTrangThai
    };

    private bool ShowResult(KetQuaNghiepVu result)
    {
        errProvider.Clear();
        if (result.ThanhCong) return true;
        var map = FieldControls();
        var messagesByControl = new Dictionary<Control, List<string>>();
        var unmapped = new List<string>();
        foreach (ValidationResult error in result.Errors)
        {
            var mapped = false;
            foreach (var member in error.MemberNames)
            {
                if (!map.TryGetValue(member, out var control)) continue;
                if (!messagesByControl.ContainsKey(control))
                    messagesByControl[control] = new();
                messagesByControl[control].Add(error.ErrorMessage ?? "Dữ liệu không hợp lệ.");
                mapped = true;
            }
            if (!mapped) unmapped.Add(error.ErrorMessage ?? "Dữ liệu không hợp lệ.");
        }
        foreach (var pair in messagesByControl)
            errProvider.SetError(pair.Key, string.Join(Environment.NewLine, pair.Value.Distinct()));
        // Chỉ Focus một lần, theo thứ tự Tab, không nhảy qua mọi trường sai.
        messagesByControl.Keys.OrderBy(c => c.TabIndex).FirstOrDefault()?.Focus();
        if (unmapped.Count > 0)
            MessageBox.Show(this, string.Join(Environment.NewLine, unmapped.Distinct()),
                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    private void ReloadAndSearch()
    {
        allSinhVien = svb.GetAllSinhVien();
        ApplySearch();
    }

    private void butThem_Click(object? sender, EventArgs e)
    {
        // Presentation không tự quyết định mã trùng, lớp tồn tại, dữ liệu hợp lệ.
        if (!ShowResult(svb.AddSinhVien(ReadStudent()))) return;
        ReloadAndSearch();
        SetEditMode(true);
        MessageBox.Show(this, "Thêm sinh viên thành công.", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void butSua_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show(this, $"Lưu thay đổi sinh viên {txtMaSV.Text.Trim()}?",
            "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
        if (!ShowResult(svb.UpdateSinhVien(ReadStudent()))) return;
        ReloadAndSearch();
        MessageBox.Show(this, "Sửa sinh viên thành công.", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void butXoa_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show(this, $"Bạn có chắc muốn xóa sinh viên {txtMaSV.Text.Trim()}?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
        if (!ShowResult(svb.DeleteSinhVien(txtMaSV.Text))) return;
        ReloadAndSearch();
        ResetEditor();
    }

    private void ApplySearch()
    {
        if (IsDesignTime || updatingControls) return;
        string maLop = cboLocLop.SelectedValue?.ToString() ?? "";
        var list = cboTimKiem.SelectedIndex == 1
            ? svb.TimKiemTaiNguon(txtTuKhoa.Text, maLop, (double)numDiemTu.Value)
            : svb.TimKiemTrenDanhSach(allSinhVien, txtTuKhoa.Text,
                maLop, (double)numDiemTu.Value);
        ShowStudents(list);
    }

    private void ShowAll()
    {
        updatingControls = true;
        try
        {
            txtTuKhoa.Clear();
            cboLocLop.SelectedIndex = 0;
            numDiemTu.Value = 0;
            allSinhVien = svb.GetAllSinhVien();
        }
        finally { updatingControls = false; }
        ApplySearch();
    }

    private void ShowStudents(List<SinhVien> students)
    {
        // Chỉ chuyển sang mô hình hiển thị để đổi mã lớp thành tên lớp.
        var names = allLopHoc.ToDictionary(l => l.MaLop, l => l.TenLop,
            StringComparer.OrdinalIgnoreCase);
        studentSource.DataSource = students.Select(sv => new
        {
            sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.Email, sv.SoDienThoai,
            sv.Diem, TenLop = names.GetValueOrDefault(sv.MaLop, sv.MaLop), sv.TrangThai
        }).ToList();
        lblTongSo.Text = $"Tổng số: {students.Count} sinh viên";
        dgvSinhVien.ClearSelection();
    }

    private void dgvSinhVien_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var value = dgvSinhVien.Rows[e.RowIndex].Cells[colMaSV.Index].Value?.ToString();
        if (value == null) return;
        txtMaSV.Text = value;
        // TextChanged không phát sinh nếu vừa bấm lại cùng một mã.
        txtMaSV_TextChanged(txtMaSV, EventArgs.Empty);
    }

}

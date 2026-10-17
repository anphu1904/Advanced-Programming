using System;
using System.Windows.Forms;
using QuanLySinhVien.Business;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.View
{
    /// <summary>
    /// Tầng View: gọi tầng Business và XỬ LÝ ngoại lệ (try/catch + MessageBox).
    /// BusinessException  -> cảnh báo dữ liệu/nghiệp vụ.
    /// DataAccessException -> báo lỗi cơ sở dữ liệu.
    /// Exception           -> lỗi không xác định.
    /// </summary>
    public partial class frmSinhVien : Form
    {
        private readonly SinhVienBUS sinhVienBUS = new SinhVienBUS();
        private readonly LopHocBUS lopHocBUS = new LopHocBUS();

        private readonly DataGridView dgvSinhVien = new DataGridView();
        private readonly ComboBox cboLop = new ComboBox();
        private readonly TextBox txtMaSV = new TextBox();
        private readonly TextBox txtHoTen = new TextBox();
        private readonly TextBox txtGioiTinh = new TextBox();
        private readonly TextBox txtNgaySinh = new TextBox();
        private readonly TextBox txtSoDienThoai = new TextBox();
        private readonly TextBox txtDiem = new TextBox();
        private readonly TextBox txtEmail = new TextBox();

        public frmSinhVien()
        {
            InitializeUi();
            Load += frmSinhVien_Load;
        }

        private void InitializeUi()
        {
            Text = "Quản lý sinh viên";
            Width = 900;
            Height = 600;

            TableLayoutPanel form = new TableLayoutPanel
            {
                Dock = DockStyle.Top, AutoSize = true, ColumnCount = 2, Padding = new Padding(8)
            };
            AddRow(form, "Mã SV", txtMaSV);
            AddRow(form, "Họ tên", txtHoTen);
            AddRow(form, "Giới tính", txtGioiTinh);
            AddRow(form, "Ngày sinh", txtNgaySinh);
            AddRow(form, "SĐT", txtSoDienThoai);
            AddRow(form, "Điểm", txtDiem);
            AddRow(form, "Email", txtEmail);
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            AddRow(form, "Lớp", cboLop);

            FlowLayoutPanel buttons = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
            buttons.Controls.Add(MakeButton("Thêm", btnThem_Click));
            buttons.Controls.Add(MakeButton("Sửa", btnSua_Click));
            buttons.Controls.Add(MakeButton("Xóa", btnXoa_Click));
            buttons.Controls.Add(MakeButton("Làm mới", (s, e) => LoadSinhVien()));

            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;

            Controls.Add(dgvSinhVien);
            Controls.Add(buttons);
            Controls.Add(form);
        }

        private static void AddRow(TableLayoutPanel panel, string caption, Control input)
        {
            panel.Controls.Add(new Label { Text = caption, AutoSize = true, Anchor = AnchorStyles.Left });
            input.Width = 300;
            panel.Controls.Add(input);
        }

        private static Button MakeButton(string text, EventHandler onClick)
        {
            Button b = new Button { Text = text, AutoSize = true };
            b.Click += onClick;
            return b;
        }

        // ---------- Xử lý ngoại lệ tập trung ----------

        private static void ShowError(Exception ex)
        {
            if (ex is BusinessException || ex is ArgumentException)
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (ex is DataAccessException)
                MessageBox.Show(ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(ex.Message, "Lỗi không xác định", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ---------- Sự kiện ----------

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                cboLop.DataSource = lopHocBUS.GetAllLopHoc();
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadSinhVien()
        {
            try
            {
                dgvSinhVien.DataSource = sinhVienBUS.GetAllSinhVien();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private SinhVien ReadForm()
        {
            if (!double.TryParse(txtDiem.Text, out double diem))
                throw new BusinessException("Điểm phải là một số.");

            return new SinhVien
            {
                MaSV = txtMaSV.Text,
                HoTen = txtHoTen.Text,
                GioiTinh = txtGioiTinh.Text,
                NgaySinh = txtNgaySinh.Text,
                SoDienThoai = txtSoDienThoai.Text,
                Diem = diem,
                Email = txtEmail.Text,
                MaLop = cboLop.SelectedValue?.ToString()
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                sinhVienBUS.AddSinhVien(ReadForm());
                MessageBox.Show("Thêm sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                sinhVienBUS.UpdateSinhVien(ReadForm());
                MessageBox.Show("Cập nhật sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Xóa sinh viên '{txtMaSV.Text}'?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                sinhVienBUS.DeleteSinhVien(txtMaSV.Text);
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                SinhVien sv = (SinhVien)dgvSinhVien.Rows[e.RowIndex].DataBoundItem;
                txtMaSV.Text = sv.MaSV;
                txtHoTen.Text = sv.HoTen;
                txtGioiTinh.Text = sv.GioiTinh;
                txtNgaySinh.Text = sv.NgaySinh;
                txtSoDienThoai.Text = sv.SoDienThoai;
                txtDiem.Text = sv.Diem.ToString();
                txtEmail.Text = sv.Email;
                cboLop.SelectedValue = sv.MaLop;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.BUL;

public class SinhVienBUL
{
    private readonly SinhVienDAL svd;
    private readonly LopDAL lopDAL;
    public SinhVienBUL() : this(DataList.Shared) { }
    public SinhVienBUL(DataList data)
    {
        svd = new SinhVienDAL(data);
        lopDAL = new LopDAL(data);
    }

    public List<SinhVien> GetAllSinhVien() => svd.GetAllSinhVien();
    public SinhVien? GetSinhVienById(string maSV) =>
        svd.GetSinhVienById((maSV ?? "").Trim());
    public List<SinhVien> GetSinhVienByLop(string maLop) =>
        svd.GetSinhVienByLop((maLop ?? "").Trim());

    private static SinhVien Normalize(SinhVien sv)
    {
        var copy = sv.Copy();
        copy.MaSV = (copy.MaSV ?? "").Trim().ToUpperInvariant();
        copy.HoTen = (copy.HoTen ?? "").Trim();
        copy.Email = (copy.Email ?? "").Trim();
        copy.SoDienThoai = (copy.SoDienThoai ?? "").Trim();
        copy.MaLop = (copy.MaLop ?? "").Trim().ToUpperInvariant();
        copy.GioiTinh = (copy.GioiTinh ?? "").Trim();
        copy.TrangThai = (copy.TrangThai ?? "").Trim();
        copy.NgaySinh = copy.NgaySinh.Date;
        return copy;
    }

    private List<ValidationResult> Validate(SinhVien sv)
    {
        var errors = sv.IsInValid();
        if (!string.IsNullOrWhiteSpace(sv.MaLop) &&
            lopDAL.GetLopHocById(sv.MaLop) == null)
            errors.Add(new ValidationResult("Lớp học không tồn tại.",
                new[] { nameof(SinhVien.MaLop) }));
        return errors;
    }

    public KetQuaNghiepVu AddSinhVien(SinhVien sv)
    {
        sv = Normalize(sv);
        var errors = Validate(sv);
        if (svd.GetSinhVienById(sv.MaSV) != null)
            errors.Add(new ValidationResult("Mã sinh viên đã tồn tại.",
                new[] { nameof(SinhVien.MaSV) }));
        if (errors.Count > 0) return new(errors);
        svd.AddSinhVien(sv);
        return new();
    }

    public KetQuaNghiepVu UpdateSinhVien(SinhVien sv)
    {
        sv = Normalize(sv);
        var errors = Validate(sv);
        if (svd.GetSinhVienById(sv.MaSV) == null)
            errors.Add(new ValidationResult("Không tìm thấy sinh viên cần sửa.",
                new[] { nameof(SinhVien.MaSV) }));
        if (errors.Count > 0) return new(errors);
        svd.UpdateSinhVien(sv);
        return new();
    }

    public KetQuaNghiepVu DeleteSinhVien(string maSV) =>
        svd.DeleteSinhVien((maSV ?? "").Trim()) ? new()
            : KetQuaNghiepVu.Loi("Không tìm thấy sinh viên cần xóa.",
                nameof(SinhVien.MaSV));

    public List<SinhVien> TimKiemTaiNguon(string tuKhoa, string? maLop, double diemTu) =>
        svd.TimKiem(tuKhoa, maLop, diemTu);

    // Lọc snapshot đã tải; không gọi DAL hoặc đọc lại nguồn dữ liệu.
    public List<SinhVien> TimKiemTrenDanhSach(IEnumerable<SinhVien> danhSach,
        string tuKhoa, string? maLop, double diemTu)
    {
        tuKhoa = (tuKhoa ?? "").Trim();
        return danhSach.Where(sv =>
            (string.IsNullOrEmpty(maLop) ||
             string.Equals(sv.MaLop, maLop, StringComparison.OrdinalIgnoreCase))
            && sv.Diem >= diemTu
            && (tuKhoa.Length == 0
                || sv.MaSV.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                || sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                || sv.Email.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                || sv.SoDienThoai.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)))
            .Select(x => x.Copy()).ToList();
    }
}

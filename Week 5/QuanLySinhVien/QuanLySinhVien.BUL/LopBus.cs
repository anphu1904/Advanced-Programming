using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.BUL;

public class LopBus
{
    private readonly LopDAL lopDAL;
    private readonly SinhVienDAL sinhVienDAL;
    public LopBus() : this(DataList.Shared) { }
    public LopBus(DataList data)
    {
        lopDAL = new LopDAL(data);
        sinhVienDAL = new SinhVienDAL(data);
    }

    public List<LopHoc> GetAllLopHoc() => lopDAL.GetAllLopHoc();
    public LopHoc? GetLopHocById(string maLop) =>
        lopDAL.GetLopHocById((maLop ?? "").Trim());

    private static LopHoc Normalize(LopHoc lh)
    {
        var copy = lh.Copy();
        copy.MaLop = (copy.MaLop ?? "").Trim().ToUpperInvariant();
        copy.TenLop = (copy.TenLop ?? "").Trim();
        return copy;
    }

    public KetQuaNghiepVu AddLopHoc(LopHoc lh)
    {
        lh = Normalize(lh);
        var errors = lh.IsInValid();
        if (errors.Count > 0) return new(errors);
        if (lopDAL.GetLopHocById(lh.MaLop) != null)
            return KetQuaNghiepVu.Loi("Mã lớp đã tồn tại.", nameof(LopHoc.MaLop));
        lopDAL.AddLopHoc(lh);
        return new();
    }

    public KetQuaNghiepVu UpdateLopHoc(LopHoc lh)
    {
        lh = Normalize(lh);
        var errors = lh.IsInValid();
        if (errors.Count > 0) return new(errors);
        return lopDAL.UpdateLopHoc(lh) ? new()
            : KetQuaNghiepVu.Loi("Không tìm thấy lớp cần sửa.", nameof(LopHoc.MaLop));
    }

    public KetQuaNghiepVu DeleteLopHoc(string maLop)
    {
        maLop = (maLop ?? "").Trim();
        if (sinhVienDAL.GetSinhVienByLop(maLop).Count > 0)
            return KetQuaNghiepVu.Loi("Không thể xóa lớp đang có sinh viên.",
                nameof(LopHoc.MaLop));
        return lopDAL.DeleteLopHoc(maLop) ? new()
            : KetQuaNghiepVu.Loi("Không tìm thấy lớp cần xóa.", nameof(LopHoc.MaLop));
    }
}

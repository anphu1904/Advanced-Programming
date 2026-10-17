using System;
using System.Collections.Generic;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Business
{
    /// <summary>
    /// Tầng nghiệp vụ cho lớp học. Kiểm tra dữ liệu, ném BusinessException khi vi phạm quy tắc,
    /// và để DataAccessException từ tầng DAL lan lên tầng View (không nuốt lỗi).
    /// </summary>
    public class LopHocBUS
    {
        private readonly LopHocDAO lopHocDAO;
        private readonly SinhVienDAO sinhVienDAO;

        public LopHocBUS() : this(new LopHocDAO(), new SinhVienDAO()) { }

        public LopHocBUS(LopHocDAO lopHocDAO, SinhVienDAO sinhVienDAO)
        {
            this.lopHocDAO = lopHocDAO ?? throw new ArgumentNullException(nameof(lopHocDAO));
            this.sinhVienDAO = sinhVienDAO ?? throw new ArgumentNullException(nameof(sinhVienDAO));
        }

        public List<LopHoc> GetAllLopHoc()
        {
            return lopHocDAO.GetAllLopHoc();
        }

        public LopHoc GetLopHocByMaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new BusinessException("Mã lớp không được để trống.");
            LopHoc lop = lopHocDAO.GetLopHocByMaLop(maLop.Trim());
            if (lop == null)
                throw new BusinessException($"Không tồn tại lớp có mã '{maLop}'.");
            return lop;
        }

        public void AddLopHoc(LopHoc lop)
        {
            Validate(lop);
            if (lopHocDAO.Exists(lop.MaLop))
                throw new BusinessException($"Mã lớp '{lop.MaLop}' đã tồn tại.");
            lopHocDAO.AddLopHoc(lop);
        }

        public void UpdateLopHoc(LopHoc lop)
        {
            Validate(lop);
            lopHocDAO.UpdateLopHoc(lop);
        }

        public void DeleteLopHoc(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new BusinessException("Mã lớp không được để trống.");
            maLop = maLop.Trim();
            if (sinhVienDAO.GetSinhViensByMaLop(maLop).Count > 0)
                throw new BusinessException($"Không thể xóa lớp '{maLop}' vì vẫn còn sinh viên thuộc lớp này.");
            lopHocDAO.DeleteLopHoc(maLop);
        }

        private static void Validate(LopHoc lop)
        {
            if (lop == null)
                throw new ArgumentNullException(nameof(lop));
            if (string.IsNullOrWhiteSpace(lop.MaLop))
                throw new BusinessException("Mã lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(lop.TenLop))
                throw new BusinessException("Tên lớp không được để trống.");
            lop.MaLop = lop.MaLop.Trim();
            lop.TenLop = lop.TenLop.Trim();
        }
    }
}

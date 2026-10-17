using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Business
{
    /// <summary>
    /// Tầng nghiệp vụ cho sinh viên. Ném BusinessException khi dữ liệu không hợp lệ,
    /// và để DataAccessException từ tầng DAL lan lên tầng View.
    /// </summary>
    public class SinhVienBUS
    {
        private readonly SinhVienDAO sinhVienDAO;
        private readonly LopHocDAO lopHocDAO;

        public SinhVienBUS() : this(new SinhVienDAO(), new LopHocDAO()) { }

        public SinhVienBUS(SinhVienDAO sinhVienDAO, LopHocDAO lopHocDAO)
        {
            this.sinhVienDAO = sinhVienDAO ?? throw new ArgumentNullException(nameof(sinhVienDAO));
            this.lopHocDAO = lopHocDAO ?? throw new ArgumentNullException(nameof(lopHocDAO));
        }

        public List<SinhVien> GetAllSinhVien()
        {
            return sinhVienDAO.GetAllSinhVien();
        }

        public SinhVien GetSinhVienByMaSV(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new BusinessException("Mã sinh viên không được để trống.");
            SinhVien sv = sinhVienDAO.GetSinhVienByMaSV(maSV.Trim());
            if (sv == null)
                throw new BusinessException($"Không tồn tại sinh viên có mã '{maSV}'.");
            return sv;
        }

        public List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
                throw new BusinessException("Mã lớp không được để trống.");
            return sinhVienDAO.GetSinhViensByMaLop(maLop.Trim());
        }

        public void AddSinhVien(SinhVien sv)
        {
            Validate(sv);
            if (sinhVienDAO.Exists(sv.MaSV))
                throw new BusinessException($"Mã sinh viên '{sv.MaSV}' đã tồn tại.");
            sinhVienDAO.AddSinhVien(sv);
        }

        public void UpdateSinhVien(SinhVien sv)
        {
            Validate(sv);
            sinhVienDAO.UpdateSinhVien(sv);
        }

        public void DeleteSinhVien(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new BusinessException("Mã sinh viên không được để trống.");
            sinhVienDAO.DeleteSinhVien(maSV.Trim());
        }

        private void Validate(SinhVien sv)
        {
            if (sv == null)
                throw new ArgumentNullException(nameof(sv));
            if (string.IsNullOrWhiteSpace(sv.MaSV))
                throw new BusinessException("Mã sinh viên không được để trống.");
            if (string.IsNullOrWhiteSpace(sv.HoTen))
                throw new BusinessException("Họ tên không được để trống.");
            if (string.IsNullOrWhiteSpace(sv.MaLop))
                throw new BusinessException("Mã lớp không được để trống.");
            if (sv.Diem < 0 || sv.Diem > 10)
                throw new BusinessException("Điểm phải nằm trong khoảng từ 0 đến 10.");
            if (!string.IsNullOrWhiteSpace(sv.Email) &&
                !Regex.IsMatch(sv.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new BusinessException("Email không đúng định dạng.");

            sv.MaSV = sv.MaSV.Trim();
            sv.HoTen = sv.HoTen.Trim();
            sv.MaLop = sv.MaLop.Trim();

            if (!lopHocDAO.Exists(sv.MaLop))
                throw new BusinessException($"Lớp '{sv.MaLop}' không tồn tại.");
        }
    }
}

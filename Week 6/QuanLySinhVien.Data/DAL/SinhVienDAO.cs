using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    /// <summary>
    /// Truy cập bảng SinhVien bằng ADO.NET (SqlConnection/SqlCommand/SqlDataAdapter/SqlDataReader).
    /// Mọi phương thức ném DataAccessException khi có lỗi; không còn thao tác trên List trong bộ nhớ.
    /// </summary>
    public class SinhVienDAO
    {
        private const string SelectAll =
            "SELECT MaSV, HoTen, GioiTinh, NgaySinh, SoDienThoai, MaLop, Diem, Email FROM SinhVien";

        private readonly DataHelper dataHelper;

        public SinhVienDAO() : this(new DataHelper()) { }

        public SinhVienDAO(DataHelper dataHelper)
        {
            this.dataHelper = dataHelper ?? throw new ArgumentNullException(nameof(dataHelper));
        }

        private static SinhVien MapRow(DataRow r)
        {
            return new SinhVien
            {
                MaSV = r["MaSV"].ToString(),
                HoTen = r["HoTen"].ToString(),
                GioiTinh = r["GioiTinh"].ToString(),
                NgaySinh = r["NgaySinh"].ToString(),
                SoDienThoai = r["SoDienThoai"].ToString(),
                MaLop = r["MaLop"].ToString(),
                Diem = r["Diem"] == DBNull.Value ? 0 : Convert.ToDouble(r["Diem"]),
                Email = r["Email"].ToString()
            };
        }

        private static SinhVien MapReader(SqlDataReader dr)
        {
            return new SinhVien
            {
                MaSV = dr["MaSV"].ToString(),
                HoTen = dr["HoTen"].ToString(),
                GioiTinh = dr["GioiTinh"].ToString(),
                NgaySinh = dr["NgaySinh"].ToString(),
                SoDienThoai = dr["SoDienThoai"].ToString(),
                MaLop = dr["MaLop"].ToString(),
                Diem = dr["Diem"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Diem"]),
                Email = dr["Email"].ToString()
            };
        }

        private static SqlParameter[] ToParameters(SinhVien sv)
        {
            return new[]
            {
                new SqlParameter("@MaSV", sv.MaSV),
                new SqlParameter("@MaLop", sv.MaLop),
                new SqlParameter("@HoTen", sv.HoTen),
                new SqlParameter("@GioiTinh", sv.GioiTinh),
                new SqlParameter("@NgaySinh", sv.NgaySinh),
                new SqlParameter("@Diem", sv.Diem),
                new SqlParameter("@SoDienThoai", sv.SoDienThoai),
                new SqlParameter("@Email", sv.Email)
            };
        }

        /// <summary>Lấy toàn bộ sinh viên bằng SqlDataAdapter + DataTable (mô hình ngắt kết nối).</summary>
        public List<SinhVien> GetAllSinhVien()
        {
            DataTable dt = dataHelper.GetDataTable(SelectAll);
            List<SinhVien> list = new List<SinhVien>();
            foreach (DataRow r in dt.Rows)
                list.Add(MapRow(r));
            return list;
        }

        /// <summary>Lấy toàn bộ sinh viên bằng SqlDataReader (mô hình kết nối).</summary>
        public List<SinhVien> GetAllSinhVienByReader()
        {
            return dataHelper.ExecuteReader(SelectAll, MapReader);
        }

        /// <summary>Trả về null nếu không tìm thấy.</summary>
        public SinhVien GetSinhVienByMaSV(string maSV)
        {
            DataTable dt = dataHelper.GetDataTable(
                SelectAll + " WHERE MaSV = @MaSV",
                new SqlParameter("@MaSV", maSV));
            return dt.Rows.Count == 0 ? null : MapRow(dt.Rows[0]);
        }

        public List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            DataTable dt = dataHelper.GetDataTable(
                SelectAll + " WHERE MaLop = @MaLop",
                new SqlParameter("@MaLop", maLop));
            List<SinhVien> list = new List<SinhVien>();
            foreach (DataRow r in dt.Rows)
                list.Add(MapRow(r));
            return list;
        }

        public bool Exists(string maSV)
        {
            object count = dataHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM SinhVien WHERE MaSV = @MaSV",
                new SqlParameter("@MaSV", maSV));
            return Convert.ToInt32(count) > 0;
        }

        public void AddSinhVien(SinhVien sv)
        {
            if (sv == null) throw new ArgumentNullException(nameof(sv));
            const string sql =
                "INSERT INTO SinhVien (MaSV, MaLop, HoTen, GioiTinh, NgaySinh, Diem, SoDienThoai, Email) " +
                "VALUES (@MaSV, @MaLop, @HoTen, @GioiTinh, @NgaySinh, @Diem, @SoDienThoai, @Email)";
            dataHelper.ExecuteNonQuery(sql, ToParameters(sv));
        }

        public void UpdateSinhVien(SinhVien sv)
        {
            if (sv == null) throw new ArgumentNullException(nameof(sv));
            const string sql =
                "UPDATE SinhVien SET HoTen = @HoTen, MaLop = @MaLop, GioiTinh = @GioiTinh, " +
                "NgaySinh = @NgaySinh, Diem = @Diem, SoDienThoai = @SoDienThoai, Email = @Email " +
                "WHERE MaSV = @MaSV";
            int rows = dataHelper.ExecuteNonQuery(sql, ToParameters(sv));
            if (rows == 0)
                throw new DataAccessException($"Không tìm thấy sinh viên '{sv.MaSV}' để cập nhật.");
        }

        public void DeleteSinhVien(string maSV)
        {
            int rows = dataHelper.ExecuteNonQuery(
                "DELETE FROM SinhVien WHERE MaSV = @MaSV",
                new SqlParameter("@MaSV", maSV));
            if (rows == 0)
                throw new DataAccessException($"Không tìm thấy sinh viên '{maSV}' để xóa.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    /// <summary>
    /// Truy cập bảng LopHoc bằng ADO.NET. Mọi phương thức ném DataAccessException khi có lỗi.
    /// </summary>
    public class LopHocDAO
    {
        private readonly DataHelper dataHelper;

        public LopHocDAO() : this(new DataHelper()) { }

        public LopHocDAO(DataHelper dataHelper)
        {
            this.dataHelper = dataHelper ?? throw new ArgumentNullException(nameof(dataHelper));
        }

        private static LopHoc MapRow(DataRow r)
        {
            return new LopHoc
            {
                MaLop = r["MaLop"].ToString(),
                TenLop = r["TenLop"].ToString()
            };
        }

        public List<LopHoc> GetAllLopHoc()
        {
            DataTable dt = dataHelper.GetDataTable("SELECT MaLop, TenLop FROM LopHoc");
            List<LopHoc> list = new List<LopHoc>();
            foreach (DataRow r in dt.Rows)
                list.Add(MapRow(r));
            return list;
        }

        /// <summary>Trả về null nếu không tìm thấy lớp.</summary>
        public LopHoc GetLopHocByMaLop(string maLop)
        {
            DataTable dt = dataHelper.GetDataTable(
                "SELECT MaLop, TenLop FROM LopHoc WHERE MaLop = @MaLop",
                new SqlParameter("@MaLop", maLop));
            return dt.Rows.Count == 0 ? null : MapRow(dt.Rows[0]);
        }

        public bool Exists(string maLop)
        {
            object count = dataHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM LopHoc WHERE MaLop = @MaLop",
                new SqlParameter("@MaLop", maLop));
            return Convert.ToInt32(count) > 0;
        }

        public void AddLopHoc(LopHoc lop)
        {
            if (lop == null) throw new ArgumentNullException(nameof(lop));
            dataHelper.ExecuteNonQuery(
                "INSERT INTO LopHoc (MaLop, TenLop) VALUES (@MaLop, @TenLop)",
                new SqlParameter("@MaLop", lop.MaLop),
                new SqlParameter("@TenLop", lop.TenLop));
        }

        public void UpdateLopHoc(LopHoc lop)
        {
            if (lop == null) throw new ArgumentNullException(nameof(lop));
            int rows = dataHelper.ExecuteNonQuery(
                "UPDATE LopHoc SET TenLop = @TenLop WHERE MaLop = @MaLop",
                new SqlParameter("@TenLop", lop.TenLop),
                new SqlParameter("@MaLop", lop.MaLop));
            if (rows == 0)
                throw new DataAccessException($"Không tìm thấy lớp '{lop.MaLop}' để cập nhật.");
        }

        public void DeleteLopHoc(string maLop)
        {
            int rows = dataHelper.ExecuteNonQuery(
                "DELETE FROM LopHoc WHERE MaLop = @MaLop",
                new SqlParameter("@MaLop", maLop));
            if (rows == 0)
                throw new DataAccessException($"Không tìm thấy lớp '{maLop}' để xóa.");
        }
    }
}

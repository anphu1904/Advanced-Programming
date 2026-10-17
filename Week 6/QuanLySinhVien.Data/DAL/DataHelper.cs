using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVien.Data.DAL
{
    /// <summary>
    /// Lớp tiện ích ADO.NET: mỗi lệnh dùng một SqlConnection riêng (using) và
    /// luôn truyền tham số bằng SqlParameter (chống SQL Injection).
    /// Mọi lỗi được ném lại dưới dạng DataAccessException, KHÔNG nuốt lỗi.
    /// </summary>
    public class DataHelper
    {
        private readonly string connectionString;

        public DataHelper()
        {
            connectionString = @"Server=LAPTOP-6SN65NCS\HUECTMDB; Database=QLSV;Integrated Security=True; TrustServerCertificate=true";
        }

        public DataHelper(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Chuỗi kết nối không được rỗng.", nameof(connectionString));
            this.connectionString = connectionString;
        }

        /// <summary>INSERT / UPDATE / DELETE. Trả về số dòng bị ảnh hưởng.</summary>
        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Lỗi cơ sở dữ liệu khi thực thi lệnh: " + ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new DataAccessException("Không thể mở kết nối cơ sở dữ liệu: " + ex.Message, ex);
            }
        }

        /// <summary>SELECT trả về một giá trị đơn (COUNT, MAX, ...).</summary>
        public object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Lỗi cơ sở dữ liệu khi truy vấn: " + ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new DataAccessException("Không thể mở kết nối cơ sở dữ liệu: " + ex.Message, ex);
            }
        }

        /// <summary>SELECT trả về DataTable (mô hình ngắt kết nối, dùng SqlDataAdapter).</summary>
        public DataTable GetDataTable(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Lỗi cơ sở dữ liệu khi đọc dữ liệu: " + ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new DataAccessException("Không thể mở kết nối cơ sở dữ liệu: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// SELECT bằng SqlDataReader (mô hình kết nối). Mỗi dòng được ánh xạ qua hàm map,
        /// kết nối đóng ngay khi đọc xong nên không để rò rỉ connection.
        /// </summary>
        public List<T> ExecuteReader<T>(string sql, Func<SqlDataReader, T> map, params SqlParameter[] parameters)
        {
            try
            {
                List<T> result = new List<T>();
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            result.Add(map(dr));
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw new DataAccessException("Lỗi cơ sở dữ liệu khi đọc dữ liệu: " + ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new DataAccessException("Không thể mở kết nối cơ sở dữ liệu: " + ex.Message, ex);
            }
            catch (FormatException ex)
            {
                throw new DataAccessException("Dữ liệu trong cơ sở dữ liệu có định dạng không hợp lệ: " + ex.Message, ex);
            }
            catch (InvalidCastException ex)
            {
                throw new DataAccessException("Dữ liệu trong cơ sở dữ liệu có kiểu không hợp lệ: " + ex.Message, ex);
            }
        }
    }
}

using System;

namespace QuanLySinhVien.Data.DAL
{
    /// <summary>
    /// Ngoại lệ do tầng truy cập dữ liệu (DAL) ném ra khi thao tác ADO.NET thất bại.
    /// InnerException giữ lại ngoại lệ gốc (SqlException, ...).
    /// </summary>
    public class DataAccessException : Exception
    {
        public DataAccessException(string message) : base(message) { }
        public DataAccessException(string message, Exception inner) : base(message, inner) { }
    }
}

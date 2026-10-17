using System;

namespace QuanLySinhVien.Business
{
    /// <summary>Ngoại lệ nghiệp vụ (dữ liệu không hợp lệ, vi phạm quy tắc nghiệp vụ).</summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception inner) : base(message, inner) { }
    }
}

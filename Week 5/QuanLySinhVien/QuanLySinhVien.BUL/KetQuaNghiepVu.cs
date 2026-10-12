using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.BUL;

public sealed class KetQuaNghiepVu
{
    public List<ValidationResult> Errors { get; }
    public bool ThanhCong => Errors.Count == 0;
    public KetQuaNghiepVu(IEnumerable<ValidationResult>? errors = null) =>
        Errors = errors?.ToList() ?? new();

    public static KetQuaNghiepVu Loi(string message, string field) =>
        new(new[] { new ValidationResult(message, new[] { field }) });
}

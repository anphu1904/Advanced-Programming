using QuanLySinhVien.BUL;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

var passed = 0;
void Check(bool ok, string message)
{
    if (!ok) throw new Exception("FAIL: " + message);
    passed++;
    Console.WriteLine("PASS: " + message);
}

SinhVien Valid(string id = "SV99") => new()
{
    MaSV = id, HoTen = "Sinh viên thử nghiệm", NgaySinh = new DateTime(2005, 3, 10),
    GioiTinh = "Nữ", Email = "test@example.com", SoDienThoai = "0912345678",
    MaLop = "CSE0001", Diem = 8.5, TrangThai = "Đang học"
};

var data = new DataList();
var svb = new SinhVienBUL(data);
var lb = new LopBus(data);
Check(lb.GetAllLopHoc().Count == 3, "Khởi tạo 3 lớp");
Check(svb.GetAllSinhVien().Count == 4, "Khởi tạo 4 sinh viên");
Check(svb.GetSinhVienByLop("cse0001").Count == 2, "Quan hệ lớp 1-n, không phân biệt hoa thường");
Check(svb.GetSinhVienById(" sv000123 ")?.HoTen == "Nguyễn Văn An", "Tra mã có khoảng trắng");
Check(svb.GetSinhVienById("NOT_FOUND") == null, "Tra mã không tồn tại trả null");
Check(svb.AddSinhVien(Valid()).ThanhCong, "Thêm hợp lệ");
Check(!svb.AddSinhVien(Valid("sv99")).ThanhCong, "Chặn mã trùng khác hoa thường");
Check(svb.GetAllSinhVien().Count == 5, "Thêm trùng không đổi số bản ghi");

var invalid = Valid("BAD99");
invalid.HoTen = " ";
invalid.Email = "sai-email";
invalid.SoDienThoai = "123";
invalid.MaLop = "NO_CLASS";
invalid.Diem = 11;
invalid.NgaySinh = DateTime.Today.AddDays(1);
var badResult = svb.AddSinhVien(invalid);
foreach (var field in new[] { "HoTen", "Email", "SoDienThoai", "MaLop", "Diem", "NgaySinh" })
    Check(badResult.Errors.Any(e => e.MemberNames.Contains(field)),
        "Lỗi ánh xạ đúng trường " + field);
Check(svb.GetSinhVienById("BAD99") == null, "Dữ liệu sai không được ghi");

var blank = Valid("");
Check(!svb.AddSinhVien(blank).ThanhCong, "Chặn mã rỗng");
var invalidStatus = Valid("BADSTATUS");
invalidStatus.TrangThai = "Khác";
Check(!svb.AddSinhVien(invalidStatus).ThanhCong, "Chặn trạng thái sai");
var invalidGender = Valid("BADGENDER");
invalidGender.GioiTinh = "Khác";
Check(!svb.AddSinhVien(invalidGender).ThanhCong, "Chặn giới tính sai");
var notFinite = Valid("BADPOINT");
notFinite.Diem = double.NaN;
Check(!svb.AddSinhVien(notFinite).ThanhCong, "Chặn điểm NaN");
var tooOld = Valid("BADDATE");
tooOld.NgaySinh = new DateTime(1899, 1, 1);
Check(!svb.AddSinhVien(tooOld).ThanhCong, "Chặn ngày sinh trước 1900");

var changed = Valid();
changed.HoTen = "Tên sau sửa";
changed.MaLop = "CSE0002";
changed.Diem = 9;
Check(svb.UpdateSinhVien(changed).ThanhCong, "Sửa hợp lệ và chuyển lớp");
Check(svb.GetSinhVienById("SV99")?.MaLop == "CSE0002", "Dữ liệu sửa được lưu");
changed.Email = "bad";
Check(!svb.UpdateSinhVien(changed).ThanhCong, "Sửa sai bị từ chối");
Check(svb.GetSinhVienById("SV99")?.Email == "test@example.com",
    "Sửa sai không làm thay đổi bản ghi đã lưu");
Check(!svb.UpdateSinhVien(Valid("MISSING")).ThanhCong, "Sửa mã không có bị từ chối");

var snapshot = svb.GetAllSinhVien();
foreach (var q in new[]
{
    ("", "", 0.0), ("", "CSE0001", 0.0), ("Anh", "", 0.0),
    ("vju.ac.vn", "", 8.0), ("091234", "", 0.0), ("sv99", "", 0.0),
    ("", "CSE0002", 9.0), ("không tồn tại", "", 0.0)
})
{
    var local = svb.TimKiemTrenDanhSach(snapshot, q.Item1, q.Item2, q.Item3);
    var source = svb.TimKiemTaiNguon(q.Item1, q.Item2, q.Item3);
    Check(local.Select(s => s.MaSV).SequenceEqual(source.Select(s => s.MaSV)),
        $"Hai chế độ tìm kiếm khớp: '{q.Item1}', '{q.Item2}', {q.Item3}");
}
Check(svb.TimKiemTaiNguon("Anh", "", 0).Single().MaSV == "SV000124",
    "Tìm đúng họ tên");
Check(svb.TimKiemTaiNguon("", "CSE0002", 9).Count == 2,
    "Lọc lớp kết hợp điểm tối thiểu");
Check(svb.TimKiemTaiNguon("không tồn tại", "", 0).Count == 0,
    "Tìm không có trả danh sách rỗng");

// Kiểm tra DAL trả bản sao, không lộ tham chiếu nguồn.
var copy = svb.GetSinhVienById("SV99")!;
copy.HoTen = "Thay đổi ngoài luồng";
Check(svb.GetSinhVienById("SV99")?.HoTen == "Tên sau sửa", "Tra mã trả bản sao");
snapshot[0].HoTen = "Không được ghi";
Check(svb.GetSinhVienById(snapshot[0].MaSV)?.HoTen != "Không được ghi",
    "Danh sách trả bản sao");
var toAdd = Valid("COPY01");
Check(svb.AddSinhVien(toAdd).ThanhCong, "Thêm bản ghi kiểm tra snapshot");
toAdd.HoTen = "Sửa đối tượng đầu vào";
Check(svb.GetSinhVienById("COPY01")?.HoTen == "Sinh viên thử nghiệm",
    "Thêm không giữ tham chiếu đầu vào");
Check(svb.TimKiemTrenDanhSach(snapshot, "COPY01", "", 0).Count == 0
      && svb.TimKiemTaiNguon("COPY01", "", 0).Count == 1,
    "Lọc snapshot không đọc lại DAL");

Check(!lb.DeleteLopHoc("CSE0001").ThanhCong, "Chặn xóa lớp có sinh viên");
Check(!lb.AddLopHoc(new LopHoc { MaLop = "cse0001", TenLop = "Lớp trùng" }).ThanhCong,
    "Chặn mã lớp trùng");
Check(!lb.AddLopHoc(new LopHoc { MaLop = "", TenLop = "" }).ThanhCong,
    "Validate lớp học");
Check(lb.AddLopHoc(new LopHoc { MaLop = "CSE0004", TenLop = "Lớp mới" }).ThanhCong,
    "Thêm lớp hợp lệ");
Check(lb.UpdateLopHoc(new LopHoc { MaLop = "CSE0004", TenLop = "Lớp đổi tên" }).ThanhCong,
    "Sửa lớp hợp lệ");
Check(lb.GetLopHocById("CSE0004")?.TenLop == "Lớp đổi tên", "Tên lớp sửa được lưu");
Check(lb.DeleteLopHoc("CSE0004").ThanhCong, "Xóa lớp rỗng");
Check(!lb.DeleteLopHoc("CSE0004").ThanhCong, "Xóa lớp không có bị từ chối");
Check(!lb.UpdateLopHoc(new LopHoc { MaLop = "MISSING", TenLop = "Không có" }).ThanhCong,
    "Sửa lớp không có bị từ chối");
Check(svb.DeleteSinhVien("sv99").ThanhCong, "Xóa sinh viên");
Check(svb.GetSinhVienById("SV99") == null, "Sau xóa không còn bản ghi");
Check(!svb.DeleteSinhVien("SV99").ThanhCong, "Xóa mã không có bị từ chối");

// DAL CRUD trực tiếp trên nguồn riêng để chứng minh đủ thao tác cho mỗi thực thể.
var empty = new DataList(false);
var lopDal = new LopDAL(empty);
var svDal = new SinhVienDAL(empty);
lopDal.AddLopHoc(new LopHoc { MaLop = "L01", TenLop = "Lớp 01" });
Check(lopDal.GetAllLopHoc().Count == 1, "LopDAL thêm/lấy");
Check(lopDal.UpdateLopHoc(new LopHoc { MaLop = "L01", TenLop = "Lớp 02" }),
    "LopDAL sửa");
Check(lopDal.DeleteLopHoc("L01"), "LopDAL xóa");
svDal.AddSinhVien(Valid("DAL01"));
Check(svDal.GetAllSinhVien().Count == 1, "SinhVienDAL thêm/lấy");
var direct = Valid("DAL01");
direct.HoTen = "Đã sửa tại DAL";
Check(svDal.UpdateSinhVien(direct), "SinhVienDAL sửa");
Check(svDal.DeleteSinhVien("DAL01"), "SinhVienDAL xóa");

Console.WriteLine($"\nALL {passed} CHECKS PASSED.");

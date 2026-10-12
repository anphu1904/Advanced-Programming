# Kết quả kiểm thử bài Quản lý sinh viên

Solution gồm Data/Entity/DAL, Business, WinForms và chương trình Console kiểm thử. Các kết quả dưới đây là kiểm tra bằng công cụ thực tế, không phải kết quả giả định.

## Môi trường

- **Hệ điều hành:** Linux, không có Windows desktop.
- **SDK:** .NET SDK 8.0.425.
- **Data, Business, Tests:** target `net8.0`.
- **WinForms:** target `net8.0-windows`, bật `EnableWindowsTargeting` để kiểm tra biên dịch từ Linux.

## Lệnh kiểm tra

```text
dotnet build QuanLySinhVien.sln --configuration Release --nologo
dotnet run --project QuanLySinhVien.Tests --configuration Release --no-build
```

## Kết quả

- **Biên dịch:** thành công, 0 cảnh báo, 0 lỗi.
- **Kiểm thử logic:** `ALL 59 CHECKS PASSED.`
- **Giao diện:** đã kiểm tra mã xử lý và biên dịch; chưa chạy hoặc thao tác giao diện trên Windows.
- **Sửa lỗi Designer:** loại bỏ vòng lặp và hàm helper trong `InitializeComponent`; khai báo điều khiển/cột bằng field và khởi tạo tường minh; thêm `.resx`, thông tin lồng file trong `.csproj`, và kiểm tra design-time ở các sự kiện nạp/tra cứu/lọc dữ liệu.

Các nhóm logic đã kiểm tra:

- **Dữ liệu mẫu:** 3 lớp, 4 sinh viên, tra mã, lấy sinh viên theo lớp.
- **CRUD sinh viên:** thêm/sửa/xóa hợp lệ, mã trùng không phân biệt hoa/thường, bản ghi không tồn tại.
- **Validation:** mã rỗng, họ tên, email, điện thoại, lớp không tồn tại, điểm ngoài khoảng/NaN, ngày sinh tương lai/trước năm 1900, giới tính và trạng thái.
- **Tìm kiếm:** kết hợp từ khóa/lớp/điểm, kết quả hai chế độ khớp, tìm không có trả danh sách rỗng.
- **Snapshot:** tìm trên danh sách không đọc lại nguồn; trả và ghi bản sao để không lộ tham chiếu.
- **CRUD lớp:** thêm/sửa/xóa, mã trùng, dữ liệu sai và lớp không tồn tại.
- **Toàn vẹn quan hệ:** không xóa lớp đang có sinh viên.
- **DAL:** mỗi thực thể đủ thao tác thêm, sửa, xóa và lấy dữ liệu.

## Phần cần xác nhận trong Visual Studio

Mở solution trên Windows, chọn `QuanLySinhVien.WinForms` làm Startup Project và nhấn F5. Dùng bảng kiểm thử UI trong `README.md` để kiểm tra bố cục, thứ tự Tab, focus, ErrorProvider, trạng thái nút và hộp thoại xác nhận.

Mở **View Designer** của `FrmSinhVien.cs` để xác nhận Form hiển thị, chọn được điều khiển, sửa được thuộc tính và lưu lại. Chạy lại F5 sau khi đổi vị trí/màu/text để kiểm tra kết quả; các bước chi tiết nằm trong `HUONG_DAN_DESIGNER.md`.

Việc biên dịch WinForms trên Linux chỉ xác nhận mã hợp lệ về mặt biên dịch; không thay thế kiểm thử UI thực tế trên Windows. Nhánh tìm tại DAL đang dùng nguồn `DataList`, không phải SQL Server.

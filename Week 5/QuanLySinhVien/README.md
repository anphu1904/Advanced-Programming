# Bài thực hành 3: Quản lý sinh viên, tách Layer

Bản C# Windows Forms này hoàn thiện Bài 1 trong tài liệu và yêu cầu tách tầng của Bài 2. Giao diện có các trường trong ảnh đề: mã sinh viên, họ tên, lớp, ngày sinh, giới tính, điểm, email, điện thoại, trạng thái; có thêm bộ lọc và hai chế độ tìm kiếm.

## Mở và chạy trong Visual Studio

1. Giải nén toàn bộ `QuanLySinhVien-CSharp.zip`.
2. Dùng Visual Studio 2022 hỗ trợ .NET 8, đã cài workload **.NET desktop development** và .NET 8 SDK.
3. Mở `QuanLySinhVien.sln`.
4. Nhấn chuột phải project `QuanLySinhVien.WinForms`, chọn **Set as Startup Project**.
5. Chọn **Build > Build Solution**, sau đó nhấn **F5**.

Ứng dụng WinForms chỉ chạy trên Windows. Không cần SQL Server hay gói NuGet bên thứ ba; lần restore đầu tiên có thể cần Internet để tải targeting pack nếu máy chưa có.

Giao diện đã được chuyển sang cấu trúc WinForms Designer thông thường: `FrmSinhVien.cs`, `FrmSinhVien.Designer.cs`, `FrmSinhVien.resx`. `InitializeComponent` chỉ khởi tạo và đặt thuộc tính điều khiển bằng các lệnh tường minh, không chứa vòng lặp hay hàm dựng giao diện tùy chỉnh như bản đầu.

Để chỉnh giao diện, mở `FrmSinhVien.cs` bằng **View Designer**, chọn điều khiển và chỉnh trong **Properties** hoặc kéo/thả; đây là quy trình thiết kế Form của Visual Studio theo [Microsoft Learn](https://learn.microsoft.com/en-us/visualstudio/designers/walkthrough-windows-forms-designer?view=visualstudio). Không tự thêm `for`, `foreach`, LINQ hoặc hàm helper vào `InitializeComponent`; mã nghiệp vụ và sự kiện nằm trong `FrmSinhVien.cs`/Business.

Hướng dẫn cập nhật từ bản cũ và xử lý Designer nằm trong `HUONG_DAN_DESIGNER.md`. Bản sửa đã build và kiểm tra logic, nhưng chưa thể thao tác Designer trực tiếp trên Windows trong môi trường thực hiện.

## Cấu trúc solution

```text
QuanLySinhVien.sln
├── QuanLySinhVien.Data
│   ├── Entity
│   │   ├── SinhVien.cs
│   │   └── LopHoc.cs
│   └── DAL
│       ├── DataList.cs
│       ├── SinhVienDAL.cs
│       └── LopDAL.cs
├── QuanLySinhVien.BUL
│   ├── SinhVienBUL.cs
│   ├── LopBus.cs
│   └── KetQuaNghiepVu.cs
├── QuanLySinhVien.WinForms
│   ├── Program.cs
│   ├── FrmSinhVien.cs
│   ├── FrmSinhVien.Designer.cs
│   └── FrmSinhVien.resx
└── QuanLySinhVien.Tests
    └── Program.cs
```

Luồng xử lý:

```text
Presentation (Form) -> Business (BUL/Bus) -> DAL -> DataList
                             |
                             +-> Entity + Data Annotations
```

- **Entity:** khai báo dữ liệu, Data Annotations và `IsInValid()`.
- **DAL:** thêm, sửa, xóa, lấy tất cả, lấy theo mã; SinhVienDAL còn lấy theo lớp và tìm kiếm tại nguồn. Mỗi thực thể có DAL riêng, các hàm cần gọi giữa project được khai báo `public`.
- **Business:** kiểm tra dữ liệu, mã trùng, lớp có tồn tại, không xóa lớp còn sinh viên; cung cấp các use case và trả lỗi gắn với tên trường.
- **Presentation:** đọc điều khiển, gọi Business, bind dữ liệu, bật/tắt nút, xác nhận sửa/xóa, hiển thị ErrorProvider. Không truy cập `List<T>` của nguồn và không gọi DAL trực tiếp.

Tên tầng `BUL` và lớp `LopBus` được giữ để tương thích ý tưởng các file bạn gửi. Không thêm đồng thời file cũ vào solution mới vì sẽ trùng lớp; `SinhVienDAL1` rỗng được thay bằng `SinhVienDAL` đầy đủ.

## Nguồn dữ liệu và quan hệ 1-n

`DataList` chứa `List<LopHoc>` và `List<SinhVien>` trong bộ nhớ. Các lớp DAL dùng cùng một `DataList.Shared`, nên thao tác thêm/sửa/xóa được nhìn thấy thống nhất giữa Business của lớp và sinh viên; constructor nhận `DataList` dùng cho kiểm thử trên nguồn riêng.

Quan hệ 1-n biểu diễn qua `SinhVien.MaLop` tham chiếu `LopHoc.MaLop`. Business kiểm tra mã lớp tồn tại khi thêm/sửa sinh viên, và từ chối xóa lớp đang có sinh viên. DAL trả bản sao đối tượng để giao diện không vô tình sửa dữ liệu trước khi validate.

**Dữ liệu không lưu xuống ổ đĩa.** Đóng ứng dụng và mở lại sẽ nạp lại 3 lớp, 4 sinh viên mẫu. Đây là lựa chọn đúng với yêu cầu nguồn DataList, không phải lỗi mất dữ liệu.

## Các yêu cầu giao diện đã xử lý

| Yêu cầu | Vị trí thực hiện |
|---|---|
| FormLoad nạp danh sách lớp vào ComboBox | `FrmSinhVien_Load` |
| FormLoad hiển thị toàn bộ sinh viên | `ShowStudents(allSinhVien)` |
| Con trỏ mặc định ở mã sinh viên | Sự kiện `Shown` và `ResetEditor` |
| Tab từ trái sang phải, từ trên xuống dưới | `TabIndex` trong `InitializeComponent` |
| Chọn lớp hiển thị sinh viên lớp đó | `cboLop_SelectedIndexChanged`, `ApplySearch` |
| Mã tồn tại: hiển thị thông tin, tắt Thêm, bật Sửa/Xóa | `txtMaSV_TextChanged`, `SetEditMode(true)` |
| Mã chưa tồn tại: xóa trường thông tin, bật Thêm | `ClearOtherFields`, `SetEditMode(false)` |
| Làm mới: xóa mã/thông tin, trạng thái thêm mới, focus mã | `ResetEditor` |
| Chọn dòng trong bảng để lấy thông tin | `dgvSinhVien_CellClick` |
| Thêm/sửa phải validate, lỗi đúng điều khiển | Business + `ShowResult` |
| Xác nhận thao tác nguy hiểm | `butSua_Click`, `butXoa_Click` |

Khi mã chưa tồn tại, giữ nguyên mã đang gõ và lớp đang chọn; xóa họ tên/email/điện thoại, đặt ngày sinh về hôm nay, điểm về 0, giới tính Nam và trạng thái Đang học. Điều khiển DateTimePicker/NumericUpDown không có trạng thái chuỗi trống nên dùng giá trị mặc định.

Form có **hai ComboBox lớp**:

- **`cboLop`:** lớp sẽ được ghi cho sinh viên. Khi người dùng đổi lớp này, bảng cũng lọc theo lớp vừa chọn.
- **`cboLocLop`:** chỉ lọc bảng, có lựa chọn “Tất cả lớp”; không đổi lớp của sinh viên đang nhập.

Khi tra mã hoặc chọn dòng, việc gán lớp bằng code không kích hoạt lọc ngoài ý muốn nhờ cờ `updatingControls`. Nút “Làm mới” chỉ reset vùng nhập, không xóa bộ lọc; nút “Hiển thị tất cả” mới reset từ khóa, lớp lọc và điểm từ.

## Hai cách tìm kiếm

Chọn cách tìm trong ComboBox cạnh nút “Tìm kiếm”.

### Trên danh sách

```csharp
svb.TimKiemTrenDanhSach(allSinhVien, tuKhoa, maLop, diemTu);
```

Lọc snapshot đã tải từ trước, không đọc lại DAL. Việc lọc được đóng gói ở Business để Form chỉ lấy các giá trị điều khiển và hiển thị kết quả; sau thêm/sửa/xóa, Form tải lại snapshot.

### Tại nguồn (DAL)

```csharp
svb.TimKiemTaiNguon(tuKhoa, maLop, diemTu);
```

Business gọi `SinhVienDAL.TimKiem`, DAL lọc trực tiếp `DataList` rồi mới trả kết quả. Cả hai chế độ tìm trong mã, họ tên, email, điện thoại; kết hợp lớp và điểm tối thiểu, không phân biệt hoa/thường.

**Lưu ý về “tìm kiếm phía cơ sở dữ liệu”:** vì đề yêu cầu nguồn DataList, nhánh DAL hiện lọc `List<T>`, không chạy SQL. Nếu giảng viên yêu cầu cơ sở dữ liệu SQL Server thật, cần thay nguồn trong DAL bằng truy vấn SQL có tham số hoặc EF; Business và Form vẫn giữ vai trò hiện tại. Bản này không giả định có database hay connection string chưa được cung cấp.

## Kiểm tra dữ liệu và ErrorProvider

Các quy tắc dưới đây được chọn cho bài thực hành vì đề không nêu mọi ràng buộc cụ thể. Có thể chỉnh trong Entity nếu giảng viên quy định khác:

- **Mã sinh viên/mã lớp:** bắt buộc, 2–20 ký tự gồm chữ, số, `_` hoặc `-`; mã được trim, viết hoa và so sánh không phân biệt hoa/thường.
- **Họ tên/tên lớp:** bắt buộc, 2–100 ký tự sau trim.
- **Email:** bắt buộc, kiểm tra bằng `EmailAddress`, tối đa 254 ký tự.
- **Điện thoại:** bắt buộc, 10 chữ số, bắt đầu bằng 0.
- **Ngày sinh:** từ 01/01/1900 đến hôm nay, không tự đặt giới hạn tuổi.
- **Điểm:** từ 0 đến 10, số hữu hạn.
- **Giới tính:** Nam hoặc Nữ.
- **Trạng thái:** Đang học, Bảo lưu hoặc Đã tốt nghiệp.
- **Lớp:** bắt buộc và phải tồn tại trong nguồn.
- **Nghiệp vụ:** thêm không trùng mã; sửa/xóa phải có bản ghi; không xóa lớp đang có sinh viên.

`IsInValid()` vẫn trả `List<ValidationResult>` giống đoạn mẫu của bạn. Business gọi hàm này trên bản sao đã chuẩn hóa và bổ sung lỗi nghiệp vụ; tất cả lỗi được trả về qua `KetQuaNghiepVu.Errors`.

Đoạn `butThem_Click` được rút gọn:

```csharp
private void butThem_Click(object? sender, EventArgs e)
{
    if (!ShowResult(svb.AddSinhVien(ReadStudent()))) return;
    ReloadAndSearch();
    SetEditMode(true);
    MessageBox.Show(this, "Thêm sinh viên thành công.", "Thông báo",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}
```

`ShowResult` ánh xạ `ValidationResult.MemberNames` sang điều khiển, xóa lỗi cũ trước mỗi lần kiểm tra, gom nhiều lỗi cùng trường và chỉ focus vào điều khiển sai đầu tiên. Chỉ cần **một ErrorProvider cho toàn Form**; không bắt buộc tạo một ErrorProvider cho từng TextBox.

Trong đoạn bạn đưa, hộp thoại tổng hợp lỗi nằm bên trong `foreach`, nên sẽ xuất hiện nhiều lần khi có nhiều lỗi. Bản này hiển thị lỗi trường bằng ErrorProvider; chỉ hiển thị một hộp thoại cho lỗi không ánh xạ được điều khiển, thay vì lặp thông báo.

## Các hàm CRUD lớp học

Ảnh đề chỉ yêu cầu Form quản lý sinh viên, nên không bổ sung Form quản lý lớp ngoài phạm vi đó. Tuy nhiên, DAL và Business của lớp đã có đủ thao tác để bạn dùng cho một Form lớp riêng:

```csharp
var bus = new LopBus();
var result = bus.AddLopHoc(new LopHoc
{
    MaLop = "CSE0004",
    TenLop = "Khoa học máy tính 04"
});

bus.GetAllLopHoc();
bus.GetLopHocById("CSE0004");
bus.UpdateLopHoc(new LopHoc { MaLop = "CSE0004", TenLop = "Tên lớp mới" });
bus.DeleteLopHoc("CSE0004"); // Business chặn nếu lớp còn sinh viên.
```

Các dòng trên là ví dụ gọi API, không phải chức năng chạy tự động khi mở ứng dụng. Mã là khóa của bản ghi; bản này sửa nội dung sinh viên/lớp, không hỗ trợ đổi khóa chính.

## Kiểm thử

Project `QuanLySinhVien.Tests` là chương trình Console kiểm thử tự động, không cần xUnit hay MSTest. Mở terminal tại thư mục solution:

```text
dotnet build QuanLySinhVien.sln
dotnet run --project QuanLySinhVien.Tests
```

Chương trình kiểm tra CRUD của hai thực thể, dữ liệu sai theo từng trường, mã trùng, lớp không tồn tại, quan hệ lớp-sinh viên, hai chế độ tìm kiếm, tính độc lập của snapshot và việc trả bản sao.

Kiểm thử giao diện trực tiếp trên Windows:

| Thao tác | Kết quả mong đợi |
|---|---|
| F5 | Hiện 4 sinh viên, 3 lớp, focus mã, chỉ nút Thêm bật |
| Gõ `SV000123` | Hiện Nguyễn Văn An, tắt Thêm, bật Sửa/Xóa |
| Gõ mã mới `SV001000` | Xóa thông tin cũ, giữ mã mới, bật Thêm |
| Nhập email/điện thoại sai và bấm Thêm | ErrorProvider ở đúng trường, không thêm |
| Nhập ngày sinh tương lai | ErrorProvider ở DateTimePicker |
| Chọn lớp CSE0001 khi bộ lọc khác rỗng | Hiện sinh viên lớp 01 |
| Chọn từng chế độ tìm, tìm `Anh` | Hai chế độ cùng trả Trần Minh Anh |
| Chọn sinh viên, sửa lớp, xác nhận Sửa | Sinh viên được chuyển lớp |
| Bấm Xóa rồi chọn No | Không xóa |
| Bấm Xóa rồi chọn Yes | Xóa sinh viên, reset vùng nhập |
| Bấm Làm mới | Về chế độ thêm, focus mã |
| Bấm Hiển thị tất cả | Reset bộ lọc và hiển thị danh sách hiện có |

Môi trường thực hiện bài không có Windows desktop, nên không thể xác nhận bằng thao tác chạy UI trực tiếp tại đây. Kết quả build và kiểm thử logic thực tế được ghi riêng trong `KET_QUA_KIEM_THU.md`.

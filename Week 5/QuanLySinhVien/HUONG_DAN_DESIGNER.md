# Sửa lỗi và chỉnh giao diện WinForms Designer

Ảnh bạn gửi cho thấy Visual Studio không đọc được vòng lặp `for` tại dòng 69 trong `InitializeComponent` của bản đầu. Lỗi này thuộc cách viết Form của bản được gửi, không phải lỗi bạn mở Designer; build thành công không đồng nghĩa Designer đọc được mọi kiểu code dựng giao diện.

## Những phần đã sửa

- **`FrmSinhVien.Designer.cs`:** bỏ hoàn toàn vòng lặp, hàm tạo điều khiển và bố cục động; dùng các field, lệnh khởi tạo, đặt thuộc tính và gắn sự kiện tường minh theo cấu trúc WinForms Designer thông thường.
- **`FrmSinhVien.resx`:** thêm tài nguyên Form và vị trí các thành phần ErrorProvider/BindingSource trong component tray.
- **`FrmSinhVien.cs`:** giữ code nghiệp vụ và xử lý giao diện; chuyển các lambda sang hàm sự kiện có tên, constructor chỉ gọi `InitializeComponent`, không nạp dữ liệu ở design-time.
- **`QuanLySinhVien.WinForms.csproj`:** khai báo Form và quan hệ lồng file Designer/resx trong Solution Explorer.
- **Data và Business:** không đổi quy tắc xử lý, CRUD, validation hay nguồn DataList.

Đã kiểm tra build Release: 0 lỗi, 0 cảnh báo; 59 kiểm tra logic vẫn đạt. Chưa thể chạy Windows Forms Designer thực tế trên Windows từ môi trường hiện tại, nên cần xác nhận bước mở Designer trên máy bạn.

## Cách mở bản cập nhật

Cách ít rủi ro nhất nếu bạn chưa chỉnh bài:

1. Đóng solution cũ trong Visual Studio.
2. Giải nén ZIP cập nhật vào **thư mục mới**, không chồng lên bản cũ.
3. Mở `QuanLySinhVien.sln` từ thư mục vừa giải nén.
4. Trong Solution Explorer, nhấn chuột phải **`QuanLySinhVien.WinForms`**, chọn **Set as Startup Project**.
5. Chọn **Build > Rebuild Solution**.
6. Nhấn chuột phải **`FrmSinhVien.cs`**, chọn **View Designer**.

Trong ảnh, Startup Project trên thanh công cụ đang là **`QuanLySinhVien.Data`**. Để chạy giao diện, phải đổi sang **`QuanLySinhVien.WinForms`**; đây là vấn đề riêng với lỗi đọc vòng lặp.

Nếu bạn đã chỉnh mã bài cũ, sao lưu trước. Bản sửa thay đổi bốn file sau trong project WinForms; đừng chỉ thay `FrmSinhVien.Designer.cs` vì các sự kiện mới và BindingSource cũng cần phần code còn lại:

```text
FrmSinhVien.cs
FrmSinhVien.Designer.cs
FrmSinhVien.resx
QuanLySinhVien.WinForms.csproj
```

Giữ lại các chỉnh sửa của bạn bằng cách đối chiếu trước khi thay file. Không cần thay Data/Business nếu bạn đã sửa các phần đó theo yêu cầu riêng.

## Căn chỉnh như giảng viên

Windows Forms Designer hỗ trợ chọn, di chuyển, thay đổi kích thước điều khiển và đặt thuộc tính bằng Properties theo [hướng dẫn Microsoft](https://learn.microsoft.com/en-us/visualstudio/designers/walkthrough-windows-forms-designer?view=visualstudio). Trên bản mới, thử theo các bước sau:

1. Mở **View Designer** của `FrmSinhVien.cs`.
2. Chọn nút **Thêm**, kéo nhẹ vị trí hoặc đổi `Text` thành “Nhập”.
3. Trong Properties, thử đổi `BackColor`, `ForeColor`, `Font`, `Size`, `Location`.
4. Lưu Form, build và nhấn F5 để kiểm tra.

Các control đang nằm trong GroupBox; `Location` của một control được tính theo container của nó. Các điều khiển ở cột phải có `Anchor = Top, Right`; nếu muốn thay bố cục lớn, kiểm tra thuộc tính Anchor cùng với Location/Size.

Giữ nguyên tên các control đang được code sử dụng, ví dụ `txtMaSV`, `txtHoTen`, `cboLop`, `butThem`. Đổi nhãn hiển thị bằng thuộc tính **Text**, không tùy tiện đổi **Name**; nếu đổi Name thì phải sửa các chỗ tham chiếu trong code tương ứng.

Các nút đã gắn sự kiện Click trong Designer. Không gắn thêm lần thứ hai trong constructor, vì một lần bấm có thể gọi cùng xử lý hai lần; code xử lý vẫn nằm ở `butThem_Click`, `butSua_Click`, `butXoa_Click`, v.v.

## Chỉnh MessageBox

MessageBox được hiển thị bằng `MessageBox.Show`; nội dung, tiêu đề, bộ nút và biểu tượng do các tham số quyết định theo [Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox?view=windowsdesktop-10.0). Sửa nội dung thông báo trong `FrmSinhVien.cs`, không trong Designer:

```csharp
MessageBox.Show(
    this,
    "Đã thêm sinh viên vào danh sách!",
    "Thông báo",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information
);
```

## Nếu Designer vẫn báo lỗi

- **Đúng file:** mở `FrmSinhVien.cs`, không mở `FrmSinhVien.Designer.cs` bằng View Designer.
- **Đúng bản:** kiểm tra bạn đang mở solution từ thư mục ZIP cập nhật, không phải solution cũ.
- **Đúng nội dung:** tìm `for (` trong `FrmSinhVien.Designer.cs`; bản cập nhật không có vòng lặp đó.
- **Build:** giải quyết lỗi build trước, đóng tab Designer rồi mở lại.
- **Không sửa thử dữ liệu:** lỗi Designer không cần đổi DAL, xóa sinh viên hoặc thêm database.

Nếu vẫn lỗi, gửi ảnh mới có nội dung lỗi và tên file/dòng được Visual Studio chỉ ra. Không xóa solution hay dữ liệu bài để thử sửa.

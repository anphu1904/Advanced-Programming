#nullable disable

namespace QuanLySinhVien.WinForms
{
    partial class FrmSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dateStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle pointStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.pnlGioiTinh = new System.Windows.Forms.Panel();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.lblDiem = new System.Windows.Forms.Label();
            this.numDiem = new System.Windows.Forms.NumericUpDown();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.butThem = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butLamMoi = new System.Windows.Forms.Button();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblLocLop = new System.Windows.Forms.Label();
            this.cboLocLop = new System.Windows.Forms.ComboBox();
            this.lblDiemTu = new System.Windows.Forms.Label();
            this.numDiemTu = new System.Windows.Forms.NumericUpDown();
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.butTimKiem = new System.Windows.Forms.Button();
            this.butTatCa = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFooter = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.studentSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpThongTin.SuspendLayout();
            this.pnlGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).BeginInit();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemTu)).BeginInit();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentSource)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(26, 66, 103);
            this.lblTitle.Location = new System.Drawing.Point(18, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            //
            // grpThongTin
            //
            this.grpThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongTin.Controls.Add(this.lblMaSV);
            this.grpThongTin.Controls.Add(this.txtMaSV);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.lblLop);
            this.grpThongTin.Controls.Add(this.cboLop);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblGioiTinh);
            this.grpThongTin.Controls.Add(this.pnlGioiTinh);
            this.grpThongTin.Controls.Add(this.lblDiem);
            this.grpThongTin.Controls.Add(this.numDiem);
            this.grpThongTin.Controls.Add(this.lblEmail);
            this.grpThongTin.Controls.Add(this.txtEmail);
            this.grpThongTin.Controls.Add(this.lblDienThoai);
            this.grpThongTin.Controls.Add(this.txtDienThoai);
            this.grpThongTin.Controls.Add(this.lblTrangThai);
            this.grpThongTin.Controls.Add(this.cboTrangThai);
            this.grpThongTin.Controls.Add(this.butThem);
            this.grpThongTin.Controls.Add(this.butSua);
            this.grpThongTin.Controls.Add(this.butXoa);
            this.grpThongTin.Controls.Add(this.butLamMoi);
            this.grpThongTin.Location = new System.Drawing.Point(18, 70);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(1214, 244);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin sinh viên";
            //
            // lblMaSV
            //
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(18, 45);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(88, 19);
            this.lblMaSV.TabStop = false;
            this.lblMaSV.Text = "Mã sinh viên *";
            //
            // txtMaSV
            //
            this.txtMaSV.Location = new System.Drawing.Point(120, 42);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(230, 25);
            this.txtMaSV.TabIndex = 0;
            this.txtMaSV.TextChanged += new System.EventHandler(this.txtMaSV_TextChanged);
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(406, 45);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(75, 19);
            this.lblHoTen.TabStop = false;
            this.lblHoTen.Text = "Họ và tên *";
            //
            // txtHoTen
            //
            this.txtHoTen.Location = new System.Drawing.Point(510, 42);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(230, 25);
            this.txtHoTen.TabIndex = 1;
            //
            // lblLop
            //
            this.lblLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(786, 45);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(67, 19);
            this.lblLop.TabStop = false;
            this.lblLop.Text = "Lớp học *";
            //
            // cboLop
            //
            this.cboLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(890, 42);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(284, 25);
            this.cboLop.TabIndex = 2;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            //
            // lblNgaySinh
            //
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(18, 89);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(70, 19);
            this.lblNgaySinh.TabStop = false;
            this.lblNgaySinh.Text = "Ngày sinh";
            //
            // dtpNgaySinh
            //
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(120, 86);
            this.dtpNgaySinh.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(230, 25);
            this.dtpNgaySinh.TabIndex = 3;
            //
            // lblGioiTinh
            //
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(406, 89);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(62, 19);
            this.lblGioiTinh.TabStop = false;
            this.lblGioiTinh.Text = "Giới tính";
            //
            // pnlGioiTinh
            //
            this.pnlGioiTinh.Controls.Add(this.rdoNam);
            this.pnlGioiTinh.Controls.Add(this.rdoNu);
            this.pnlGioiTinh.Location = new System.Drawing.Point(510, 83);
            this.pnlGioiTinh.Name = "pnlGioiTinh";
            this.pnlGioiTinh.Size = new System.Drawing.Size(230, 31);
            this.pnlGioiTinh.TabIndex = 4;
            //
            // rdoNam
            //
            this.rdoNam.AutoSize = true;
            this.rdoNam.Checked = true;
            this.rdoNam.Location = new System.Drawing.Point(0, 3);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(58, 23);
            this.rdoNam.TabIndex = 0;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            //
            // rdoNu
            //
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(90, 3);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(47, 23);
            this.rdoNu.TabIndex = 1;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            //
            // lblDiem
            //
            this.lblDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(786, 89);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(51, 19);
            this.lblDiem.TabStop = false;
            this.lblDiem.Text = "Điểm *";
            //
            // numDiem
            //
            this.numDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDiem.DecimalPlaces = 1;
            this.numDiem.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numDiem.Location = new System.Drawing.Point(890, 86);
            this.numDiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDiem.Name = "numDiem";
            this.numDiem.Size = new System.Drawing.Size(284, 25);
            this.numDiem.TabIndex = 5;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(18, 133);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 19);
            this.lblEmail.TabStop = false;
            this.lblEmail.Text = "Email *";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(120, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(230, 25);
            this.txtEmail.TabIndex = 6;
            //
            // lblDienThoai
            //
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(406, 133);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(85, 19);
            this.lblDienThoai.TabStop = false;
            this.lblDienThoai.Text = "Điện thoại *";
            //
            // txtDienThoai
            //
            this.txtDienThoai.Location = new System.Drawing.Point(510, 130);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(230, 25);
            this.txtDienThoai.TabIndex = 7;
            //
            // lblTrangThai
            //
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(786, 133);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(72, 19);
            this.lblTrangThai.TabStop = false;
            this.lblTrangThai.Text = "Trạng thái";
            //
            // cboTrangThai
            //
            this.cboTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Đã tốt nghiệp" });
            this.cboTrangThai.Location = new System.Drawing.Point(890, 130);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(284, 25);
            this.cboTrangThai.TabIndex = 8;
            //
            // butThem
            //
            this.butThem.BackColor = System.Drawing.Color.SeaGreen;
            this.butThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butThem.ForeColor = System.Drawing.Color.White;
            this.butThem.Location = new System.Drawing.Point(18, 186);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(105, 34);
            this.butThem.TabIndex = 9;
            this.butThem.Text = "Thêm";
            this.butThem.UseVisualStyleBackColor = false;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            //
            // butSua
            //
            this.butSua.BackColor = System.Drawing.Color.SteelBlue;
            this.butSua.Enabled = false;
            this.butSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSua.ForeColor = System.Drawing.Color.White;
            this.butSua.Location = new System.Drawing.Point(135, 186);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(105, 34);
            this.butSua.TabIndex = 10;
            this.butSua.Text = "Sửa";
            this.butSua.UseVisualStyleBackColor = false;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            //
            // butXoa
            //
            this.butXoa.BackColor = System.Drawing.Color.IndianRed;
            this.butXoa.Enabled = false;
            this.butXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butXoa.ForeColor = System.Drawing.Color.White;
            this.butXoa.Location = new System.Drawing.Point(252, 186);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(105, 34);
            this.butXoa.TabIndex = 11;
            this.butXoa.Text = "Xóa";
            this.butXoa.UseVisualStyleBackColor = false;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            //
            // butLamMoi
            //
            this.butLamMoi.BackColor = System.Drawing.Color.SlateGray;
            this.butLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLamMoi.ForeColor = System.Drawing.Color.White;
            this.butLamMoi.Location = new System.Drawing.Point(369, 186);
            this.butLamMoi.Name = "butLamMoi";
            this.butLamMoi.Size = new System.Drawing.Size(105, 34);
            this.butLamMoi.TabIndex = 12;
            this.butLamMoi.Text = "Làm mới";
            this.butLamMoi.UseVisualStyleBackColor = false;
            this.butLamMoi.Click += new System.EventHandler(this.butLamMoi_Click);
            //
            // grpTimKiem
            //
            this.grpTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTimKiem.Controls.Add(this.lblTuKhoa);
            this.grpTimKiem.Controls.Add(this.txtTuKhoa);
            this.grpTimKiem.Controls.Add(this.lblLocLop);
            this.grpTimKiem.Controls.Add(this.cboLocLop);
            this.grpTimKiem.Controls.Add(this.lblDiemTu);
            this.grpTimKiem.Controls.Add(this.numDiemTu);
            this.grpTimKiem.Controls.Add(this.cboTimKiem);
            this.grpTimKiem.Controls.Add(this.butTimKiem);
            this.grpTimKiem.Controls.Add(this.butTatCa);
            this.grpTimKiem.Location = new System.Drawing.Point(18, 326);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(1214, 108);
            this.grpTimKiem.TabIndex = 2;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm / lọc sinh viên";
            //
            // lblTuKhoa
            //
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(18, 33);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(57, 19);
            this.lblTuKhoa.TabStop = false;
            this.lblTuKhoa.Text = "Từ khóa";
            //
            // txtTuKhoa
            //
            this.txtTuKhoa.Location = new System.Drawing.Point(86, 30);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.PlaceholderText = "Mã, họ tên, email, điện thoại";
            this.txtTuKhoa.Size = new System.Drawing.Size(280, 25);
            this.txtTuKhoa.TabIndex = 0;
            this.txtTuKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTuKhoa_KeyDown);
            //
            // lblLocLop
            //
            this.lblLocLop.AutoSize = true;
            this.lblLocLop.Location = new System.Drawing.Point(382, 33);
            this.lblLocLop.Name = "lblLocLop";
            this.lblLocLop.Size = new System.Drawing.Size(32, 19);
            this.lblLocLop.TabStop = false;
            this.lblLocLop.Text = "Lớp";
            //
            // cboLocLop
            //
            this.cboLocLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLop.FormattingEnabled = true;
            this.cboLocLop.Location = new System.Drawing.Point(420, 30);
            this.cboLocLop.Name = "cboLocLop";
            this.cboLocLop.Size = new System.Drawing.Size(320, 25);
            this.cboLocLop.TabIndex = 1;
            this.cboLocLop.SelectedIndexChanged += new System.EventHandler(this.Filter_SelectedIndexChanged);
            //
            // lblDiemTu
            //
            this.lblDiemTu.AutoSize = true;
            this.lblDiemTu.Location = new System.Drawing.Point(760, 33);
            this.lblDiemTu.Name = "lblDiemTu";
            this.lblDiemTu.Size = new System.Drawing.Size(57, 19);
            this.lblDiemTu.TabStop = false;
            this.lblDiemTu.Text = "Điểm từ";
            //
            // numDiemTu
            //
            this.numDiemTu.DecimalPlaces = 1;
            this.numDiemTu.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numDiemTu.Location = new System.Drawing.Point(832, 30);
            this.numDiemTu.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDiemTu.Name = "numDiemTu";
            this.numDiemTu.Size = new System.Drawing.Size(70, 25);
            this.numDiemTu.TabIndex = 2;
            //
            // cboTimKiem
            //
            this.cboTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] { "Trên danh sách", "Tại nguồn (DAL)" });
            this.cboTimKiem.Location = new System.Drawing.Point(928, 30);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(246, 25);
            this.cboTimKiem.TabIndex = 3;
            this.cboTimKiem.SelectedIndexChanged += new System.EventHandler(this.Filter_SelectedIndexChanged);
            //
            // butTimKiem
            //
            this.butTimKiem.BackColor = System.Drawing.Color.SteelBlue;
            this.butTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTimKiem.ForeColor = System.Drawing.Color.White;
            this.butTimKiem.Location = new System.Drawing.Point(18, 65);
            this.butTimKiem.Name = "butTimKiem";
            this.butTimKiem.Size = new System.Drawing.Size(105, 32);
            this.butTimKiem.TabIndex = 4;
            this.butTimKiem.Text = "Tìm kiếm";
            this.butTimKiem.UseVisualStyleBackColor = false;
            this.butTimKiem.Click += new System.EventHandler(this.butTimKiem_Click);
            //
            // butTatCa
            //
            this.butTatCa.BackColor = System.Drawing.Color.SlateGray;
            this.butTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTatCa.ForeColor = System.Drawing.Color.White;
            this.butTatCa.Location = new System.Drawing.Point(135, 65);
            this.butTatCa.Name = "butTatCa";
            this.butTatCa.Size = new System.Drawing.Size(145, 32);
            this.butTatCa.TabIndex = 5;
            this.butTatCa.Text = "Hiển thị tất cả";
            this.butTatCa.UseVisualStyleBackColor = false;
            this.butTatCa.Click += new System.EventHandler(this.butTatCa_Click);
            //
            // grpDanhSach
            //
            this.grpDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDanhSach.Controls.Add(this.lblTongSo);
            this.grpDanhSach.Controls.Add(this.dgvSinhVien);
            this.grpDanhSach.Location = new System.Drawing.Point(18, 446);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1214, 266);
            this.grpDanhSach.TabIndex = 3;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách sinh viên";
            //
            // lblTongSo
            //
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Location = new System.Drawing.Point(14, 26);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(132, 19);
            this.lblTongSo.TabIndex = 0;
            this.lblTongSo.Text = "Tổng số: 0 sinh viên";
            //
            // dgvSinhVien
            //
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AllowUserToDeleteRows = false;
            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(242, 247, 252);
            this.dgvSinhVien.AlternatingRowsDefaultCellStyle = alternatingStyle;
            this.dgvSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSinhVien.AutoGenerateColumns = false;
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSinhVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvSinhVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaSV, this.colHoTen, this.colNgaySinh, this.colGioiTinh,
                this.colEmail, this.colDienThoai, this.colDiem, this.colTenLop, this.colTrangThai });
            this.dgvSinhVien.Location = new System.Drawing.Point(14, 54);
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.RowHeadersVisible = false;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(1186, 198);
            this.dgvSinhVien.TabIndex = 1;
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);
            //
            // colMaSV
            //
            this.colMaSV.DataPropertyName = "MaSV";
            this.colMaSV.FillWeight = 85F;
            this.colMaSV.HeaderText = "Mã SV";
            this.colMaSV.MinimumWidth = 45;
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.ReadOnly = true;
            this.colMaSV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colHoTen
            //
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.FillWeight = 135F;
            this.colHoTen.HeaderText = "Họ và tên";
            this.colHoTen.MinimumWidth = 45;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colHoTen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colNgaySinh
            //
            this.colNgaySinh.DataPropertyName = "NgaySinh";
            dateStyle.Format = "dd/MM/yyyy";
            this.colNgaySinh.DefaultCellStyle = dateStyle;
            this.colNgaySinh.FillWeight = 85F;
            this.colNgaySinh.HeaderText = "Ngày sinh";
            this.colNgaySinh.MinimumWidth = 45;
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.ReadOnly = true;
            this.colNgaySinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colGioiTinh
            //
            this.colGioiTinh.DataPropertyName = "GioiTinh";
            this.colGioiTinh.FillWeight = 65F;
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.MinimumWidth = 45;
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            this.colGioiTinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colEmail
            //
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.FillWeight = 160F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 45;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colDienThoai
            //
            this.colDienThoai.DataPropertyName = "SoDienThoai";
            this.colDienThoai.FillWeight = 100F;
            this.colDienThoai.HeaderText = "Điện thoại";
            this.colDienThoai.MinimumWidth = 45;
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.ReadOnly = true;
            this.colDienThoai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colDiem
            //
            this.colDiem.DataPropertyName = "Diem";
            pointStyle.Format = "0.0";
            this.colDiem.DefaultCellStyle = pointStyle;
            this.colDiem.FillWeight = 50F;
            this.colDiem.HeaderText = "Điểm";
            this.colDiem.MinimumWidth = 45;
            this.colDiem.Name = "colDiem";
            this.colDiem.ReadOnly = true;
            this.colDiem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colTenLop
            //
            this.colTenLop.DataPropertyName = "TenLop";
            this.colTenLop.FillWeight = 170F;
            this.colTenLop.HeaderText = "Lớp";
            this.colTenLop.MinimumWidth = 45;
            this.colTenLop.Name = "colTenLop";
            this.colTenLop.ReadOnly = true;
            this.colTenLop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // colTrangThai
            //
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.FillWeight = 95F;
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 45;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // lblFooter
            //
            this.lblFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFooter.AutoSize = true;
            this.lblFooter.ForeColor = System.Drawing.Color.DimGray;
            this.lblFooter.Location = new System.Drawing.Point(18, 725);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(709, 19);
            this.lblFooter.TabIndex = 4;
            this.lblFooter.Text = "Chọn một dòng để xem, sửa, xóa. Dữ liệu lưu trong bộ nhớ và mất khi đóng ứng dụng.";
            //
            // errProvider
            //
            this.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProvider.ContainerControl = this;
            //
            // FrmSinhVien
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.ClientSize = new System.Drawing.Size(1250, 760);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.lblFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1266, 799);
            this.Name = "FrmSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sinh viên | Bài thực hành 3 - Tách Layer";
            this.Load += new System.EventHandler(this.FrmSinhVien_Load);
            this.Shown += new System.EventHandler(this.FrmSinhVien_Shown);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.pnlGioiTinh.ResumeLayout(false);
            this.pnlGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).EndInit();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemTu)).EndInit();
            this.grpDanhSach.ResumeLayout(false);
            this.grpDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Panel pnlGioiTinh;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.NumericUpDown numDiem;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button butThem;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butLamMoi;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label lblLocLop;
        private System.Windows.Forms.ComboBox cboLocLop;
        private System.Windows.Forms.Label lblDiemTu;
        private System.Windows.Forms.NumericUpDown numDiemTu;
        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.Button butTimKiem;
        private System.Windows.Forms.Button butTatCa;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.BindingSource studentSource;
    }
}

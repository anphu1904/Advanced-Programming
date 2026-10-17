using System;
using System.Windows.Forms;

namespace QuanLySinhVien.View
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Chốt chặn cuối cùng: ngoại lệ chưa được xử lý ở form nào cũng được báo cho người dùng.
            Application.ThreadException += (s, e) =>
                MessageBox.Show(e.Exception.Message, "Lỗi không mong muốn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            ApplicationConfiguration.Initialize();
            Application.Run(new frmSinhVien());
        }
    }
}

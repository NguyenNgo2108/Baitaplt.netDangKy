using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DangKy
{
    public partial class Form1 : Form
    {
        private ErrorProvider errorProvider;
        public Form1()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra định dạng email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(tbEmail.Text, emailPattern))
            {
                errorProvider.SetError(tbEmail, "Email không đúng định dạng.");
            }
            else
            {
                errorProvider.SetError(tbEmail, "");
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra mật khẩu
            string password = tbPassword.Text;
            if (password.Length < 1 || !Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 1 ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu tất cả đều đúng, thông báo thành công
            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

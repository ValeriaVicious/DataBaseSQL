using System.Drawing;
using System.Windows.Forms;


namespace DataBaseSQL
{
    public partial class RegisterForm : Form
    {
        #region Fields

        private Point _lastPoint;

        #endregion


        #region ClassLifeCycles

        public RegisterForm()
        {
            InitializeComponent();
            nameTextBox.Text = Constants.AddName;
            surnameTextBox.Text = Constants.AddSurname;
            userLoginTextBox.Text = Constants.AddLogin;
            passwordTextBox.Text = Constants.AddPassword;
        }

        #endregion


        #region Methods

        private void ToCloseFormAutorizationLabel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _lastPoint.X;
                Top += e.Y - _lastPoint.Y;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }


        #endregion

        private void NameTextBox_Enter(object sender, System.EventArgs e)
        {
            if (nameTextBox.Text == Constants.AddName)
            {
                nameTextBox.Text = string.Empty;
                nameTextBox.ForeColor = Color.Black;
            }
        }

        private void NameTextBox_Leave(object sender, System.EventArgs e)
        {
            if (nameTextBox.Text == string.Empty)
            {
                nameTextBox.Text = Constants.AddName;
                nameTextBox.ForeColor = Color.Gray;
            }
        }

        private void SurnameTextBox_Leave(object sender, System.EventArgs e)
        {
            if (surnameTextBox.Text == string.Empty)
            {
                surnameTextBox.Text = Constants.AddSurname;
                surnameTextBox.ForeColor = Color.Gray;
            }
        }

        private void SurnameTextBox_Enter(object sender, System.EventArgs e)
        {
            if (surnameTextBox.Text == Constants.AddSurname)
            {
                surnameTextBox.Text = string.Empty;
                surnameTextBox.ForeColor = Color.Black;
            }
        }

        private void UserLoginTextBox_Enter(object sender, System.EventArgs e)
        {
            if (userLoginTextBox.Text == Constants.AddLogin)
            {
                userLoginTextBox.Text = string.Empty;
                userLoginTextBox.ForeColor = Color.Black;
            }
        }

        private void UserLoginTextBox_Leave(object sender, System.EventArgs e)
        {
            if (userLoginTextBox.Text == string.Empty)
            {
                userLoginTextBox.Text = Constants.AddLogin;
                userLoginTextBox.ForeColor = Color.Gray;
            }
        }

        private void PasswordTextBox_Enter(object sender, System.EventArgs e)
        {
            if (passwordTextBox.Text == Constants.AddPassword)
            {
                passwordTextBox.Text = string.Empty;
                passwordTextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordTextBox_Leave(object sender, System.EventArgs e)
        {
            if (passwordTextBox.Text == string.Empty)
            {
                passwordTextBox.Text = Constants.AddPassword;
                passwordTextBox.ForeColor = Color.Gray;
            }
        }
    }
}

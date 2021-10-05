using DataBaseSQL.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace DataBaseSQL
{
    public partial class LoginForm : Form
    {
        #region Fields

        private RegisterForm _registerForm;
        private DataBase _dataBase;
        private DataTable _table;
        private MySqlDataAdapter _adapter;
        private MainForm _mainForm;

        private Point _lastPoint;
        private string _loginUser;
        private string _passwordUser;

        #endregion


        #region ClassLifeCycles

        public LoginForm()
        {
            InitializeComponent();
            _registerForm = new RegisterForm();
            _dataBase = new DataBase();
            _table = new DataTable();
            _adapter = new MySqlDataAdapter();
            _mainForm = new MainForm();
            loginTextBox.Text = Constants.AddLogin;
            passwordTextBox.Text = Constants.AddPassword;
        }

        #endregion


        #region Methods

        private void ToCloseFormAutorizationLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToCloseFormAutorizationLabel_MouseEnter(object sender, EventArgs e)
        {
            toCloseFormAutorizationLabel.ForeColor = Color.Blue;
        }

        private void ToCloseFormAutorizationLabel_MouseLeave(object sender, EventArgs e)
        {
            toCloseFormAutorizationLabel.ForeColor = Color.Transparent;
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


        private void LoginButton_Click(object sender, EventArgs e)
        {
            _loginUser = loginTextBox.Text;
            _passwordUser = passwordTextBox.Text;

            MySqlCommand command = new MySqlCommand($"SELECT * FROM `users` WHERE `Login` =  @userLogin AND `Password` = @userPassword", _dataBase.GetConnection());
            command.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = _loginUser;
            command.Parameters.Add("@userPassword", MySqlDbType.VarChar).Value = _passwordUser;

            _adapter.SelectCommand = command;
            _adapter.Fill(_table);

            if (_table.Rows.Count > 0)
            {
                Hide();
                _mainForm.Show();
            }
            else
            {
                MessageBox.Show("Данные введены неверно");
            }
        }

        private void LoginTextBox_Enter(object sender, EventArgs e)
        {
            if (loginTextBox.Text == Constants.AddLogin)
            {
                loginTextBox.Text = string.Empty;
                loginTextBox.ForeColor = Color.Black;
            }
        }

        private void UserLoginTextBox_Leave(object sender, System.EventArgs e)
        {
            if (loginTextBox.Text == string.Empty)
            {
                loginTextBox.Text = Constants.AddLogin;
                loginTextBox.ForeColor = Color.Gray;
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
        #endregion

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            Hide();
            _registerForm.Show();
        }
    }

}

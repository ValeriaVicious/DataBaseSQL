using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace DataBaseSQL
{
    public partial class RegisterForm : Form
    {
        #region Fields

        private Point _lastPoint;
        private string _nameOfUser;
        private string _surnameOfUser;
        private string _loginOfUser;
        private string _passwordOfUser;

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

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            if (nameTextBox.Text == Constants.AddName)
            {
                MessageBox.Show("Вы должны ввести имя пользователя.");
                return;
            }

            if (surnameTextBox.Text == Constants.AddSurname)
            {
                MessageBox.Show("Вы должны ввести фамилию пользователя.");
                return;
            }

            if (userLoginTextBox.Text == Constants.AddLogin)
            {
                MessageBox.Show("Вы должны ввести логин пользователя.");
                return;
            }

            if (passwordTextBox.Text == Constants.AddPassword)
            {
                MessageBox.Show("Вы должны ввести пароль пользователя.");
                return;
            }

            if (IsUserExists())
            {
                return;
            }

            _nameOfUser = nameTextBox.Text;
            _surnameOfUser = surnameTextBox.Text;
            _loginOfUser = userLoginTextBox.Text;
            _passwordOfUser = passwordTextBox.Text;

            DataBase dataBase = new DataBase();
            MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO `users` (`Login`, `Password`, `Name`, `Surname`) VALUES (@userLogin, @userPassword, @userName, @userSurname)", dataBase.GetConnection());
            mySqlCommand.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = _loginOfUser;
            mySqlCommand.Parameters.Add("@userPassword", MySqlDbType.VarChar).Value = _passwordOfUser;
            mySqlCommand.Parameters.Add("@userName", MySqlDbType.VarChar).Value = _nameOfUser;
            mySqlCommand.Parameters.Add("@userSurname", MySqlDbType.VarChar).Value = _surnameOfUser;

            dataBase.OpenConnection();

            if (mySqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация прошла успешно.");
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан.");
            }

            dataBase.CloseConnection();
        }

        public bool IsUserExists()
        {
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand($"SELECT * FROM `users` WHERE `Login` =  @userLogin", dataBase.GetConnection());
            command.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = _loginOfUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существвует.\nВведите другой.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AutorizationLabel_Click(object sender, System.EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}

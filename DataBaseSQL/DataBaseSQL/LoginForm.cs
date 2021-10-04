using System;
using System.Drawing;
using System.Windows.Forms;


namespace DataBaseSQL
{
    public partial class LoginForm : Form
    {
        #region Fields

        private Point _lastPoint;

        #endregion


        #region ClassLifeCycles

        public LoginForm()
        {
            InitializeComponent();
        }

        #endregion


        #region Methods

        private void ToCloseFormAutorizationLabel_Click(object sender, EventArgs e)
        {
            Close();
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

        #endregion
    }
}

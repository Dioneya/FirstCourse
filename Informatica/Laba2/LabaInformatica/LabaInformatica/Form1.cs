using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabaInformatica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void passwordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheck.Checked)
            {
                passwordBox.PasswordChar = (char)0;
            }
            else
            {
                passwordBox.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = "Dioneya";
            string password = "123";

            if (loginBox.Text == login && passwordBox.Text == password)
            {
                MessageBox.Show("Ты вошёл сука!!");
            }
            else
            {
                MessageBox.Show("Давай по новой Миша, всё хуйня");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

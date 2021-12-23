using Fontys_Hub;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rondit
{
    public partial class LoginForm : Form
    {
        Database db = new Database();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(int.Parse(db.ExecuteScalar($"SELECT COUNT (*) FROM dbo.Gebruiker WHERE Gebruikersnaam = '{tbUsername.Text}' AND Wachtwoord = '{tbPassword.Text}'")) == 1)
            {
                MessageBox.Show("Ge bent ingelogd matjuuuuhh");
            }
            else
            {
                MessageBox.Show("Je gebruikersnaam of wachtwoord is fout matjeeee");
            }
        }

        private void llRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm rf = new RegisterForm(new LoginForm());
            rf.Show();
            this.Hide();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

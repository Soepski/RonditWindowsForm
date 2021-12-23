using Fontys_Hub;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rondit
{
    public partial class RegisterForm : Form
    {
        Database db = new Database();
        LoginForm lf;
        public RegisterForm(LoginForm lf)
        {
            this.lf = lf;
            InitializeComponent();
        }

        private void tbRegister_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            string repeatPassword = tbRepeatPassword.Text;

            if (db.ExecuteNonQuery($"INSERT INTO dbi413096.dbo.Gebruiker (ID, Gebruikersnaam, Email, Wachtwoord) VALUES ('2', '{username}', '{email}', '{password}');") == 1)
            {
                MessageBox.Show("yoooo ge hebt een account matje");
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lf.Show();
        }
    }
}

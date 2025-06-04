using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace QLST
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string role = quyenCB.Text;

            if (new BLL_Account().CheckLogin(user, txtPassword.Text, role))
            {
                this.Close();
                System.Threading.Thread newThread = new System.Threading.Thread(() =>
                {
                    Application.Run(new frmMain(user, role));
                });
                newThread.SetApartmentState(System.Threading.ApartmentState.STA);
                newThread.Start();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnVisible_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            // Change the image of the button based on the password visibility
            if (txtPassword.UseSystemPasswordChar)
            {
                btnVisible.Image = Properties.Resources.invisible_24;
            }
            else
            {
                btnVisible.Image = Properties.Resources.visible_24;
            }
        }
    }
}

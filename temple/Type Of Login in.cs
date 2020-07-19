using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temple
{
    public partial class Type_Of_Login_in : Form
    {
        public Type_Of_Login_in()
        {
            InitializeComponent();
        }

        private void Type_Of_Login_in_Load(object sender, EventArgs e)
        {

        }

        private void png_lead_to_login_window_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.Show();
          
        }
    }
}

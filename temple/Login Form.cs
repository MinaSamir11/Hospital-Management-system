using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace temple
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        int i = 0;
        private void Btn_login_in_Click(object sender, EventArgs e)
        {
            SqlConnection ss = new SqlConnection(@"Data Source=DESKTOP-27NJV8M\MYDATABASE;Initial Catalog=MinaData;Integrated Security=True");
            string query = "select *from LoginDB WHERE UserName = '" + textBox1.Text.Trim() + "' and password= '" + textBox2.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, ss);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
           
            if(dtbl.Rows.Count==1)
            {
                if (i == 0)
                {
                    MainForm objform1 = new MainForm(textBox1.Text);
                    this.Hide();
                    i++;
                    objform1.Show();      
                }
            }
            else
            {
                MessageBox.Show("اسم المستخدم او كلمه السر خاطئه ", "Wrong UserName or password ");
            }
        }
        private void Btn_Exit_login_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

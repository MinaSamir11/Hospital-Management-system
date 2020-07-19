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
using Bunifu.Framework.UI;
using System.IO;
namespace temple
{

    public partial class Registration_patient : Form
    {
        MainForm form1;         //insizlazed to copy main object to pass to function
        int price;
        string user;
        private static int flag = 0;
        public Registration_patient(MainForm form11, string userr)   //constructor
        {
            InitializeComponent();
            form1 = form11;
            user = userr;


        }
        void Generate_Debit_Card_num()
        {
            var now = DateTime.Now;
            var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            int uniqueId = (int)(zeroDate.Ticks / 1000000);
            textBox1.Text = uniqueId.ToString();


        }
        static class Sequence
        {
            public static int _value = -1;
            private static readonly object m_lock = new object();

            public static int Next
            {
                get
                {
                    lock (m_lock)
                    {
                        if (_value == Int32.MaxValue)
                            _value = -1;

                        return ++_value;
                    }
                }
            }
        }
        public void Registration_patient_FormClosed(object sender, FormClosedEventArgs e) //when form closed do this -->
        {
            this.Dispose();
            this.Close();
            GC.Collect();
            System.GC.Collect();
        }
        public void PictureBox1_Click(object sender, EventArgs e)   // close tab button
        {
            this.Dispose();
            this.Close();
            form1.Access_btn_and_Exit(false, 0);
        }

        private void PictureBox2_Click(object sender, EventArgs e)    // minmize window
        {
            timer3.Start();
            bunifuTransition2.HideSync(Panel_parent);
            form1.Access_btn_and_Exit(false, 1);

        }
        public void Show_form_anmition()
        {
            Panel_parent.Visible = true;
            this.Show();
        }
        private void Txt_First_Name_Leave(object sender, EventArgs e)
        {
            if (Txt_First_Name.Text.Length != 0)
                Txt_First_Name.LineIdleColor = Color.FromArgb(74, 240, 99);
            else
            {
                Txt_First_Name.LineIdleColor = Color.Red;
            }

        }
        private void Txt_First_Name_Enter_1(object sender, EventArgs e)
        {
            if (Txt_First_Name.Text == "")
            {
                Txt_First_Name.ResetText();
                Required_field1.Visible = false;
                Error_icon.Visible = false;
                Error.Visible = false;
            }
        }

        private void Txt_Secund_Name_OnValueChanged_1(object sender, EventArgs e)
        {
            Required_field2.Visible = false;
            Error_icon.Visible = false;
            Error.Visible = false;
        }
        private void Txt_Secund_Name_Leave(object sender, EventArgs e)
        {
            if (Txt_Secund_Name.Text.Length != 0)
                Txt_Secund_Name.LineIdleColor = Color.FromArgb(74, 240, 99);
            else
            {
                Txt_Secund_Name.LineIdleColor = Color.Red;
            }
        }
        private void Txt_Secund_Name_Enter_1(object sender, EventArgs e)
        {
            if (Txt_Secund_Name.Text == "")
                Txt_Secund_Name.ResetText();
        }
        private void Txr_Familly_Name_OnValueChanged_1(object sender, EventArgs e)
        {
            Required_field3.Visible = false;
            Error_icon.Visible = false;
            Error.Visible = false;
        }

        private void Txr_Familly_Name_Leave(object sender, EventArgs e)
        {
            if (Txr_Familly_Name.Text.Length != 0)
                Txr_Familly_Name.LineIdleColor = Color.FromArgb(74, 240, 99);
            else
            {
                Txr_Familly_Name.LineIdleColor = Color.Red;
            }
        }

        private void Txr_Familly_Name_Enter_1(object sender, EventArgs e)
        {
            if (Txr_Familly_Name.Text == "")
                Txr_Familly_Name.ResetText();
        }
        private void Txt_Age_OnValueChanged_1(object sender, EventArgs e)
        {
            Required_field4.Visible = false;
            Error_icon.Visible = false;
            Error.Visible = false;
        }

        private void Txt_Age_Leave(object sender, EventArgs e)
        {
            if (Txt_Age.Text.Length != 0)
                Txt_Age.LineIdleColor = Color.FromArgb(74, 240, 99);
            else
            {
                Txt_Age.LineIdleColor = Color.Red;
            }
        }

        private void Txt_Age_Enter_1(object sender, EventArgs e)
        {
            if (Txt_Age.Text == "")
                Txt_Age.ResetText();
        }
        private void Txt_Phone_No_OnValueChanged_1(object sender, EventArgs e)
        {
            Required_field5.Visible = false;
            Error_icon.Visible = false;
            Error.Visible = false;
        }

        private void Txt_Phone_No_Leave(object sender, EventArgs e)
        {
            if (Txt_Phone_No.Text.Length != 0)
                Txt_Phone_No.LineIdleColor = Color.FromArgb(74, 240, 99);
            else
            {
                Txt_Phone_No.LineIdleColor = Color.Red;
            }
        }
        private void Txt_Phone_No_Enter_1(object sender, EventArgs e)
        {
            if (Txt_Phone_No.Text == "")
                Txt_Phone_No.ResetText();
        }
        private void ComboBox1_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Required_field6.Visible = false;
            Error_icon.Visible = false;
            Error.Visible = false;
        }

        private void ComboBox1_Type_Leave(object sender, EventArgs e)
        {
            if (comboBox1_Type.Text.Length == 0)
                Required_field6.Visible = true;

        }

        int s;
        private void ComboBox2_Type_of_discover_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int a = int.Parse(txt_id.Text);

            if (comboBox2_Type_of_discover.Text == "")
            {

                Txt_Price.Text = "0";
            }
            else if (comboBox2_Type_of_discover.Text == "باطنه ")
            {
                Txt_Price.Text = "40 جنيه";
                Required_field7.Visible = false;
                Error_icon.Visible = false;
                Error.Visible = false;
                string path = Environment.CurrentDirectory + "data1";

                if (!File.Exists(path))
                {
                    File.CreateText(path);
                    MessageBox.Show("Create Successful");
                }
                using (StreamReader ss = new StreamReader(@"C:\Users\menas\source\repos\temple\temple\bin\Debug\data1.txt"))
                {
                    s = int.Parse(ss.ReadLine()) + 1;
                    textBox1.Text = "B : " + s.ToString();
                    price = 40;
                }
            }
            else if (comboBox2_Type_of_discover.Text == "نساء والتوليد")
            {
                Txt_Price.Text = "70 جنيه";
                Required_field7.Visible = false;
                Error_icon.Visible = false;
                Error.Visible = false;

                string path = Environment.CurrentDirectory + "data2";

                if (!File.Exists(path))
                {
                    File.CreateText(path);
                    MessageBox.Show("Create Successful");
                }

                using (StreamReader ss = new StreamReader(@"C:\Users\menas\source\repos\temple\temple\bin\Debug\data2.txt"))
                {
                    s = int.Parse(ss.ReadLine()) + 1;
                    textBox1.Text = "C : " + s.ToString();
                    price = 70;

                }
            }
            else if (comboBox2_Type_of_discover.Text == "اسنان ")
            {
                Txt_Price.Text = "45 جنيه";
                Required_field7.Visible = false;
                Error_icon.Visible = false;
                Error.Visible = false;

                string path = @"C:\Users\menas\source\repos\temple\temple\bin\Debug\data3";
                if (!File.Exists(path))
                {
                    File.CreateText(path);
                }
                using (StreamWriter sss = new StreamWriter(path))
                {
                    sss.Write(0);
                    sss.Close();
                }
                using (StreamReader ss = new StreamReader(@"C:\Users\menas\source\repos\temple\temple\bin\Debug\data3"))
                {
                    s = int.Parse(ss.ReadLine()) + 1;
                    textBox1.Text = "D : " + s.ToString();
                    ss.Close();
                    price = 45;
                }

            }
            else if (comboBox2_Type_of_discover.Text == "جلديه")
            {

                Txt_Price.Text = "50 جنيه";
                Required_field7.Visible = false;
                Error_icon.Visible = false;
                Error.Visible = false;
                if (a != flag)
                {
                    flag = a;
                    textBox1.Text = "E : " + Sequence.Next.ToString();
                    price = 50;
                }
                else
                {
                    textBox1.Text = "E : " + Sequence._value;
                    price = 50;
                }


            }
            else if (comboBox2_Type_of_discover.Text == "عظام")
            {

                Txt_Price.Text = "65 جنيه";
                Required_field7.Visible = false;
                Error_icon.Visible = false;
                Error.Visible = false;
                if (a != flag)
                {
                    flag = a;
                    textBox1.Text = "F : " + Sequence.Next.ToString();
                    price = 65;
                }
                else
                {
                    textBox1.Text = "F : " + Sequence._value;
                    price = 65;
                }

            }
        }

        private void ComboBox2_Type_of_discover_Leave(object sender, EventArgs e)
        {

            if (comboBox2_Type_of_discover.Text.Length == 0)
                Required_field7.Visible = true;
        }
        private void ComboBox4_Name_of_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Required_field8.Visible = false;
            Error_icon.Visible = false;
            Error.Visible = false;
        }
        private void ComboBox4_Name_of_Doctor_Leave(object sender, EventArgs e)
        {
            if (comboBox4_Name_of_Doctor.Text.Length == 0)
                Required_field8.Visible = true;
        }
        private void Registration_patient_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();

            SqlConnection ss = new SqlConnection(@"Data Source=PROJECT\MYDATABASE;Initial Catalog=MinaData;Integrated Security=True");
            string query = " select patient_iD from Patient_Table where Patient_iD = (select max(Patient_iD) from Patient_Table);";
            SqlDataAdapter sda = new SqlDataAdapter(query, ss);
            DataTable table = new DataTable();
            sda.Fill(table);
            int x = Int32.Parse(table.Rows[0][0].ToString()) + 1;
            txt_id.Text = x.ToString();
            Txt_First_Name.LineIdleColor = Color.Red;
            Txt_Secund_Name.LineIdleColor = Color.Red;
            Txr_Familly_Name.LineIdleColor = Color.Red;
            Txt_Age.LineIdleColor = Color.Red;
            Txt_Phone_No.LineIdleColor = Color.Red;


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            //  bunifuDatepicker1.Value = dt;
            Txt_Date_time.Text = string.Format("{0:dd/MM/yyyy  hh:mmtt }", dt);

        }
        private void Timer2_Tick_1(object sender, EventArgs e)
        {
            if (Panel_parent.Visible == false)
                bunifuTransition1.ShowSync(Panel_parent);
            else
            {
                timer2.Stop();
            }
        }
        private void Timer3_Tick_1(object sender, EventArgs e)
        {

            if (Panel_parent.Visible == false)
            {
                this.Hide();
            }
            else
            {
                timer3.Stop();
            }
        }

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            int x = 0;
            PictureBox[] required_fieldd = new PictureBox[8];
            required_fieldd[0] = Required_field1;
            required_fieldd[1] = Required_field2;
            required_fieldd[2] = Required_field3;
            required_fieldd[3] = Required_field4;
            required_fieldd[4] = Required_field5;
            required_fieldd[5] = Required_field6;
            required_fieldd[6] = Required_field7;
            required_fieldd[7] = Required_field8;
            BunifuMaterialTextbox[] txt = new BunifuMaterialTextbox[6];
            // TextBox[] txt = new TextBox[6];
            txt[0] = Txt_First_Name;
            txt[1] = Txt_Secund_Name;
            txt[2] = Txr_Familly_Name;
            txt[3] = Txt_Age;
            txt[4] = Txt_Phone_No;
            txt[5] = Txt_Date_time;
            for (int i = 0; i <= 7; i++)
            {
                if (i >= 5)
                {
                    if (comboBox1_Type.Text.Length == 0 && i == 5)
                    {
                        Error_icon.Visible = true;
                        Error.Visible = true;
                        required_fieldd[i].Visible = true;
                        x++;
                    }
                    if (comboBox2_Type_of_discover.Text.Length == 0 && i == 6)
                    {
                        Error_icon.Visible = true;
                        Error.Visible = true;
                        required_fieldd[i].Visible = true;
                        x++;
                    }
                    if (comboBox4_Name_of_Doctor.Text.Length == 0 && i == 7)
                    {
                        Error_icon.Visible = true;
                        Error.Visible = true;
                        required_fieldd[i].Visible = true;
                        x++;
                    }
                }
                if (i <= 5)
                {
                    //if (i == 5 && txt[i].Text == "")
                    //{
                    //    Error_icon.Visible = true;
                    //    Error.Visible = true;
                    //    required_fieldd[i + 3].Visible = true;
                    //    x++;

                    //}
                    if (txt[i].Text == "" && i != 5)
                    {
                        Error_icon.Visible = true;
                        Error.Visible = true;
                        required_fieldd[i].Visible = true;
                        x++;
                    }
                }
            }
            //   int c = 0;
            if (x == 0)    // save into DataBase 
            {
                DialogResult result1 = MessageBox.Show(" حفظ ومتابعه  ",
                   " تأكد علي ان  كافة البيانات المريض جميعها صحيحه ",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result1 == DialogResult.Yes)
                {
                    DateTime test = new DateTime();
                    test = DateTime.Now;
                    txt[5].Text = string.Format("{0:dd/M/yyyy  hh:mmtt}", test);
                    SqlConnection connect = new SqlConnection(@"Data Source=PROJECT\MYDATABASE;Initial Catalog=MinaData;Integrated Security=True");
                    string query = "INSERT INTO Patient_Table (FirstName,FatherName,FamilyName,Age,Address,PhoneNumber,Sex,Detection,DoctorName,DateBooked,Descption,Price_of_discover,User_Name)VALUES('" + this.Txt_First_Name.Text + "'," +
                        "'" + this.Txt_Secund_Name.Text + "','" + this.Txr_Familly_Name.Text + "','" + this.Txt_Age.Text + "','" + this.Txt_Address.Text + "','" + this.Txt_Phone_No.Text + "','" + this.comboBox1_Type.Text + "','" + this.comboBox2_Type_of_discover.Text + "','" + this.comboBox4_Name_of_Doctor.Text + "','" + txt[5].Text + "','" + this.richTextBox1_Description.Text + "','" + this.price + "','" + this.user + "');";
                    SqlDataAdapter sda = new SqlDataAdapter(query, connect);
                    DataTable table = new DataTable();
                    sda.Fill(table);
                    Txt_First_Name.ResetText();
                    Txt_First_Name.LineIdleColor = Color.Red;
                    Txt_Secund_Name.ResetText();
                    Txt_Secund_Name.LineIdleColor = Color.Red;
                    Txr_Familly_Name.ResetText();
                    Txr_Familly_Name.LineIdleColor = Color.Red;
                    Txt_Age.ResetText();
                    Txt_Age.LineIdleColor = Color.Red;
                    Txt_Address.ResetText();
                    Txt_Phone_No.ResetText();
                    Txt_Phone_No.LineIdleColor = Color.Red;
                    comboBox1_Type.Text = "";
                    comboBox2_Type_of_discover.Text = "";
                    comboBox4_Name_of_Doctor.Text = "";
                    richTextBox1_Description.Clear();
                    Txt_Price.Clear();
                    using (StreamWriter increase_Teller = new StreamWriter(@"C:\Users\menas\source\repos\temple\temple\bin\Debug\data1.txt"))
                    {
                        increase_Teller.Write(s);
                    }
                    MessageBox.Show("تم حفظ البيانات بنجاح", "عمليه ناجحه");

                    query = " select patient_iD from Patient_Table where Patient_iD = (select max(Patient_iD) from Patient_Table);";
                    SqlDataAdapter sdaa = new SqlDataAdapter(query, connect);
                    sdaa.Fill(table);
                    x = Int32.Parse(table.Rows[0][0].ToString()) + 1;
                    txt_id.Clear();
                    textBox1.Text = "00000";
                    txt_id.Text = x.ToString();
                }
                else
                {
                    return;
                }
            }
        }

        private void Registration_patient_Activated(object sender, EventArgs e)
        {
            form1.Access_btn_and_Exit(true, 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;

namespace temple
{
    public partial class MainForm : Form
    {
        
        Registration_patient Object;
        string user;
        public MainForm(string user1)
        {
            InitializeComponent();
            user = user1;
        }
        //public void DisplayImage()

        //{
        //    PictureBox imageControl = new PictureBox
        //    {
        //        Name = "Exit",
        //        Location = new Point(1170, 14),
        //        Size = new Size(18, 18)
        //    };
        //    imageControl.BringToFront();

        //    imageControl.BackColor = Color.FromArgb(41, 39, 40);
        //    imageControl.SizeMode = PictureBoxSizeMode.StretchImage;
        //    imageControl.Cursor = Cursors.Default;
        //    Controls.Add(imageControl);

        //    imageControl.Image = Image.FromFile(@"C:\Users\menas\source\repos\temple\temple\close-150192_960_720.png");
        //    imageControl.Click += new System.EventHandler(picturebox1_Click);
        //}
        //private void picturebox1_Click(object sender, EventArgs e)
        //{

        //    // this.object1.delete_Register_form(1);



        //    //  this.Controls.Remove(Reg_patient);


        //}

        //public void dynamc_button()
        //{

        //    DisplayImage();

        //    Button Reg_patient = new Button();
        //    Reg_patient = new Button
        //    {
        //        Font = new Font("Niagara Solid", 13F),
        //        Location = new Point(1078, 10),

        //        Name = "button2",
        //        Text = "تسجيل بيانات المرضي",
        //        BackColor = System.Drawing.Color.FromArgb(41, 39, 40),
        //        Cursor = Cursors.Hand,

        //        FlatStyle = FlatStyle.Standard,
        //        ForeColor = Color.WhiteSmoke,
        //        RightToLeft = RightToLeft.Yes,
        //        Size = new Size(115, 59),
        //        TabIndex = 15,
        //        UseVisualStyleBackColor = false
        //    };
        //    Reg_patient.BringToFront();
        //    Reg_patient.Click += new EventHandler(button2_Click);
        //    Controls.Add(Reg_patient);

        //    ////////////////////////////// add picture

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //object1 = new testt();             // running perfect
        //    //  this. object1.create_object_from_form(1);

        //}           /// not interested


        public void Access_btn_and_Exit(bool TrueOrFalse, int i)
        {
            if (i != 1)
            {
               this.Exit1.Visible = TrueOrFalse;
               this.Btn1.Visible = TrueOrFalse;
               this.panel8.Visible = TrueOrFalse;
                Object = null;         
            }
            if(i == 1)
               this.panel8.Visible = TrueOrFalse; ;

        }
        
        private void Btn_reg_patient_Click(object sender, EventArgs e)
        {
            if (!Btn1.Visible)
            {
                Exit1.Visible = true;
                Btn1.Visible = true;
                Object = new Registration_patient(this,user);
               
                Object.Show();

            }
            else if (Btn1.Visible && !Object.Visible)
            {
                Object.Show_form_anmition();
            }
        }

        private void Png_turn_off_Click(object sender, EventArgs e)  // Turn Off Application
        { 
            if (Btn1.Visible)
            {
                Object.TopMost = false;
            }

            else
            {
                DialogResult result1 = MessageBox.Show("هل تريد الخروج من البرنامج",
                    "تحذير",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,MessageBoxDefaultButton.Button2,MessageBoxOptions.RtlReading);
                if (result1 == DialogResult.Yes)
                    Application.Exit();
                else
                {
                    return;
                }
            }

            DialogResult result2 = MessageBox.Show("برجاء العلم ان هناك نوافذ مفتوحه لم تتم حفظها بعد هل تريد الخروج من البرنامج؟",
                   "تحذير",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (result2 == DialogResult.Yes)
                Application.Exit();
            else
            {
                Object.TopMost = true;
            }
        }

        private void Png_logout_Click(object sender, EventArgs e)   // Log Out 
        {
            LoginForm objformMain = new LoginForm();
            objformMain.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)  ///القائمه
        {
            if(Btn1.Visible)
                  Object.Hide();

        }


        private void Btn1_Click(object sender, EventArgs e)  //  tab task button
        {
            if(!Object.Visible)
            {
                Object.Show_form_anmition();
            }
        }

        private void Exit1_Click(object sender, EventArgs e)   // tabmm task exit button
        {
            Object.Dispose();
            Object.Dispose();
            Object.Close();
            Object = null;
            GC.Collect();
            System.GC.Collect();
            panel8.Visible = false;
            Exit1.Visible = false;
            Btn1.Visible = false;
        }


        private void Btn_reg_patient_MouseMove(object sender, MouseEventArgs e)
        {
            panel8.Visible = true;
        }

        private void Btn_reg_patient_MouseLeave(object sender, EventArgs e)
        {
            if(!Btn1.Visible)
            panel8.Visible = false;
        
        }

        private void Btn_Info_Patient_MouseMove(object sender, MouseEventArgs e)
        {
          //  panel9.Visible = true;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
             GC.Collect();
        }

        private void MainForm_Load(object sender, EventArgs e)           //time
        {
            timer_tick.Start();
        }

        private void Timer_tick_Tick(object sender, EventArgs e)       //Main timemm
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            txt_System_time.Visible = true;
            txt_System_time.Text = string.Format("{0:hh:mm:sstt \n dd/MM/yyyy }", dt);
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace NDPProje
{
    public partial class Form1 : Form
    {

        public List<PictureBox> tumHedefler = new List<PictureBox>();  //uçaklar listesi
        public List<PictureBox> tumAtesler = new List<PictureBox>();   //mermiler listesi
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();    
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();  
        System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();  
        System.Windows.Forms.Timer timer4 = new System.Windows.Forms.Timer();  
        System.Windows.Forms.Timer timer5 = new System.Windows.Forms.Timer();  

        public Form1()
        {

            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //5 farklı zamanlayıca değer verilmesi
            timer.Interval = 40;                            
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            timer2.Interval = 2178;
            timer2.Tick += new EventHandler(Timer_Tick2);
            timer2.Start();

            timer3.Interval = 30;
            timer3.Tick += new EventHandler(Timer_Tick3);
            timer3.Start();

            timer4.Interval = 10;
            timer4.Tick += new EventHandler(Timer_Tick4);
            timer4.Start();

            timer5.Interval = 10;
            timer5.Tick += new EventHandler(Timer_Tick5);
            timer5.Start();

        }

        void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Hareket();
            timer.Start();
        }
        void Timer_Tick2(object sender, EventArgs e)
        {
            timer2.Stop();
            YeniUcak();
            timer2.Start();
        }

        void Timer_Tick3(object sender, EventArgs e)
        {
            timer3.Stop();
            Ates();
            timer3.Start();
        }
        void Timer_Tick4(object sender, EventArgs e)
        {
            timer4.Stop();
            Kontrol();
            timer4.Start();
        }
        void Timer_Tick5(object sender, EventArgs e)
        {
            timer5.Stop();
            Kontrol2();
            timer5.Start();
        }

        public void Hareket()   
        {
            foreach (PictureBox pic in tumHedefler)
            {
                pic.Invoke((MethodInvoker)(() => pic.Location = new Point(pic.Location.X, pic.Location.Y + 5)));
            }

        }
         
        public void YeniUcak()    
        {

            Random random = new Random();

            PictureBox pic = new PictureBox();
            pic.Image = Properties.Resources.images;
            tumHedefler.Add(pic);
            this.Controls.Add(pic);
            pic.Location = new Point(random.Next(0, 600), 0);

        }

        public void Ates()   
        {
            foreach (PictureBox pic1 in tumAtesler)
            {
                pic1.Invoke((MethodInvoker)(() => pic1.Location = new Point(pic1.Location.X, pic1.Location.Y - 10)));
            }
        }

        public void Kontrol()     
        {
            for (int i = 0; i < tumHedefler.Count; i++)
            {
                PictureBox pic1 = tumHedefler[i];

                for (int j = 0; j < tumAtesler.Count; j++)
                {
                    PictureBox pic2 = tumAtesler[j];

                    if ((pic1.Location.Y - pic2.Location.Y) <= 30 &&   
                        (pic1.Location.Y - pic2.Location.Y) >= -30 &&
                        (pic1.Location.X - pic2.Location.X) >= -70 &&
                        (pic1.Location.X - pic2.Location.X) <= 10)
                    {
                        tumHedefler.Remove(pic1); 
                        tumAtesler.Remove(pic2);
                        this.Controls.Remove(pic1); 
                        this.Controls.Remove(pic2);
                        j = tumAtesler.Count + 1;
                        i = tumHedefler.Count + 1;
                    }
                }

            }

        }
        public void Kontrol2()    
        {
            for (int i = 0; i < tumHedefler.Count ; i++)
            {
                PictureBox picture = tumHedefler[i];

                if (picture.Location.Y >= 400)
                    this.Close();

            }

        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)  
        {
            PictureBox picture = new PictureBox();
            picture.Image = Properties.Resources.index;
            tumAtesler.Add(picture);
            this.Controls.Add(picture);
            picture.Location = new Point(
                pictureBox1.Location.X + 30, 400);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)  
        {
            if (e.KeyCode == Keys.Left)
            {
                if (this.pictureBox1.Location.X > pictureBox1.Width / 2)
                {
                    this.pictureBox1.Location = new Point(
                  this.pictureBox1.Location.X - 10, this.pictureBox1.Location.Y);
                }

            }
            else if (e.KeyCode == Keys.Right)
            {

                if (this.pictureBox1.Location.X < 1000 - pictureBox1.Size.Width - 10)
                {
                    this.pictureBox1.Location = new Point(
                this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y);
                }
            }

        }
    }
}

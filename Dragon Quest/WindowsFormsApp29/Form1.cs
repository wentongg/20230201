using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp29
{
    public partial class Form1 : Form
    {
        Random rd = new Random();
       
        int herostate = 0;
        int dinosuarlife = 100;
        int herolife = 100;
        bool keyup = true;
        bool start = false; //開始遊戲

        public Form1()
        {
            InitializeComponent();
            int[] dinosuar = new int[3];
            int kk;
            int dinosuarstate = 0;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox1.ReadOnly = true; //不讓使用者輸入文字           
            Random rd = new Random();           
            Application.DoEvents();            
            Application.DoEvents();
            pictureBox2.Image = imageList1.Images[0];
            label4.Text = "0";
            label3.Text = dinosuarstate.ToString();               
            System.Threading.Thread.Sleep(500);
            Application.DoEvents();
            textBox1.Visible = false; //先把訊息框隱藏
            
            if (pictureBox1.Image == imageList1.Images[3])
            {
                dinosuarstate = 2020220;
                label3.Text = dinosuarstate.ToString();
            }
            

        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(start == true) //開始遊戲才能移動
            {
                int herostate = 0;
                label1.Text = e.KeyCode.ToString();
                label2.Text = e.KeyValue.ToString();
                if (label2.Text == "65")
                {
                    pictureBox2.Image = imageList1.Images[2];
                    herostate = 1;
                    label4.Text = herostate.ToString();
                    keyup = false;
                }
                else
                {
                    if (label2.Text == "83")
                    {
                        pictureBox2.Image = imageList1.Images[1];
                        herostate = 2;
                        label4.Text = herostate.ToString();
                        keyup = false;
                    }

                }
            }
            
           

          

        }

       
        private void timer1_Tick(object sender, EventArgs e) //恐龍自動攻擊
        {
            int kk;
            int dinosuarstate;
            kk = rd.Next(3, 6);
            pictureBox1.Image = imageList1.Images[kk];

            if (kk == 3)
            {
                dinosuarstate = 0;
                label5.Text = dinosuarstate.ToString();
            }

            if (kk == 4)
            {
                dinosuarstate = 1;
                label5.Text = dinosuarstate.ToString();
            }

            if (kk == 5)
            {
                dinosuarstate = 2;
                label5.Text = dinosuarstate.ToString();
            }
        }

        

        

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (dinosuarlife < 60)
                label6.ForeColor = Color.Red;
            if (herolife < 60)
                label7.ForeColor = Color.Red;

            if (label4.Text == "1"&&label5.Text == "0")
            {
                dinosuarlife -= 7;
                label6.Text = dinosuarlife.ToString();
                textBox1.AppendText("勇者對惡龍造成7點傷害" + "\r\n");
            }
            else
            {
                if(label4.Text == "1" && label5.Text == "1") //恐龍的防禦是1
                {
                    dinosuarlife -= 3;
                    label6.Text = dinosuarlife.ToString();
                    textBox1.AppendText("勇者對惡龍造成3點傷害" + "\r\n");
                }
                else
                {
                    if(label4.Text == "1" && label5.Text == "2")
                    {
                        dinosuarlife -= 0;
                        label6.Text = dinosuarlife.ToString();
                        textBox1.AppendText("惡龍抵擋下了攻擊" + "\r\n");
                    }
                }
            }


            if (label4.Text == "0" && label5.Text == "2")//恐龍2是攻擊
            {
                herolife -= 7;
                label7.Text = herolife.ToString();
                textBox1.AppendText("惡龍對勇者造成7點傷害" + "\r\n");
            }
            else
            {
                if (label4.Text == "1" && label5.Text == "2") //恐龍的防禦是1
                {
                    herolife -= 3;
                    label7.Text = herolife.ToString();
                    textBox1.AppendText("惡龍對勇者造成3點傷害" + "\r\n");
                }
                else
                {
                    if (label4.Text == "2" && label5.Text == "2")
                    {
                        herolife -= 0;
                        label7.Text = herolife.ToString();
                        textBox1.AppendText("勇者抵擋下了攻擊!" + "\r\n");
                    }
                }
            }

            DialogResult result;

            if(Convert.ToInt32( label6.Text) <= 0)
            {
                textBox1.Visible = false;
                textBox1.Clear();
                label6.Text = 0.ToString();                                                         //讓血量=0
                start = false;                                                                      //停止動作
                timer5.Enabled = false;
                timer1.Enabled = false;
                MessageBox.Show( "勇者!", "The winner is");
                timer5.Enabled = false;
               
                

                result = MessageBox.Show("挑戰超究極?", "贏了!!!",MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    dinosuarlife = 100;
                    herolife = 100;
                    label6.Text = "100";
                    label7.Text = "100";
                    label6.ForeColor = Color.Black;
                    label7.ForeColor = Color.Black;
                    timer1.Interval = 150;
                    timer1.Enabled = true;
                    timer5.Enabled = true;
                    start = true;
                    textBox1.Visible = true;
                }
                
            }
            else
            {
                if(Convert.ToInt32( label7.Text) <= 0)
                {
                    textBox1.Visible = false;
                    textBox1.Clear();
                    label7.Text = 0.ToString();
                    start = false;
                    timer5.Enabled = false;
                    timer1.Enabled = false;
                    MessageBox.Show( "惡龍!", "The winner is");
                    timer5.Enabled = false;
                    
                    

                    result = MessageBox.Show("再玩一場?", "輸了QQ", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        dinosuarlife = 100;
                        herolife = 100;
                        label6.Text = "100";
                        label7.Text = "100";
                        label6.ForeColor = Color.Black;
                        label7.ForeColor = Color.Black;
                        timer1.Enabled = true;
                        timer5.Enabled = true;
                        start = true;
                        textBox1.Visible = true;
                    }
                    
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyup = true;
            pictureBox2.Image = imageList1.Images[0];
            herostate = 0;
            label4.Text = herostate.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            this.Controls.Remove(button1);//按鈕會導致無法偵測鍵盤事件
            timer1.Enabled = true;
            timer5.Enabled = true;
            start = true;
            textBox1.Visible = true; //訊息框打開
        }

        
    }
}

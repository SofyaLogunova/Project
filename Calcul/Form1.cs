using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcul
{
    public partial class Form1 : Form
    {

        double FirstNumber;
        string Operation;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(textBox1.Text);
            textBox1.Text = " ";
            Operation = "+";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(textBox1.Text);
            textBox1.Text = " ";
            Operation = "*";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(textBox1.Text);
            textBox1.Text = " ";
            Operation = "/";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FirstNumber = Convert.ToDouble(textBox1.Text);
            textBox1.Text = " ";
            Operation = "-";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double SecondNumber;
            double Result;

            SecondNumber = Convert.ToDouble(textBox1.Text);

            if (Operation == "+")
            {
                Result = (FirstNumber + SecondNumber);
                textBox1.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "-")
            {
                Result = (FirstNumber - SecondNumber);
                textBox1.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "*")
            {
                Result = (FirstNumber * SecondNumber);
                textBox1.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "/")
            {
                if (SecondNumber == 0)
                {
                    textBox1.Text = "Cannot divide by zero";

                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    textBox1.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }






        ///////////время

        int a;//часы
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox9.Text);
        }
        int b;//мигуты
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            b = Convert.ToInt32(textBox10.Text);
        }
        int c;//секунды
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            c = Convert.ToInt32(textBox11.Text);
        }
        int w;//часы
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            w = Convert.ToInt32(textBox12.Text);
        }
        int d;//минуты
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            d = Convert.ToInt32(textBox13.Text);
        }
        int s;//секунды
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            s = Convert.ToInt32(textBox14.Text);
        }
        int chas;
        int min;
        int sec;
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
    
            
        }

        private void button17_Click(object sender, EventArgs e)

        {
            chas = a - w;
            min = b - d;
            sec = c - s;

            textBox15.Text = textBox15.Text + chas + " час ";
            textBox15.Text = textBox15.Text + min + " минут ";
            textBox15.Text = textBox15.Text + sec + " секунд ";
        }




        //даты

        int i; //год (input("Год: " ))
        int j;// int (input("Месяц: " ))
        int r;// int (input("День: " ))


        int u; // int (input("Год: "))
        int q;// int (input("Месяц: "))
        int h; // int (input("День: "))


        int gg;//day
        int year;
        int mon;

        //1 year
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            i = Convert.ToInt32(textBox2.Text);
        }
        //1 mounth
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            j = Convert.ToInt32(textBox3.Text);
        }
        // 1 day
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            r = Convert.ToInt32(textBox4.Text);
        }
        //2 year
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            u = Convert.ToInt32(textBox5.Text);
        }
        //2 mon
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            q = Convert.ToInt32(textBox6.Text);
        }

        //2 day
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            h = Convert.ToInt32(textBox7.Text);
        }
        int k;
        private void button18_Click(object sender, EventArgs e)
        {//jan
            if (j == 1)
            {
                if (r > 0 & r < 32)
                {
                    if(r > h)
                    {
                        gg = r - h;
                    }
                    else if  (r <= h){
                        int k = r - h;
                        gg = 31 + k;
                    }
                }
            }//fevrali
            else if (j == 2)
            {
                if (i % 4 == 0)
                {
                    if (r > 0 & r < 30)
                    {
                        if (r > h)
                        {
                            gg = r - h;
                        }
                        else if (r <= h)
                        {
                            k = r - h;
                            gg = 31 + k;
                        }
                    }
                } 
            }//mart
            else if (j == 3)
            {
                if (r > 0 & r < 32)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        if (i % 4 ==0)
                        {
                            k = r - h;
                            gg = 29 + k;
                        }
                    }
                    else { k = r - h; gg = 28 + k; }
                }
            }
            //apr

            else if (j == 4)
            {
                if (r > 0 & r < 31)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 31 + k;
                    }
                     
                }
            }
            //may
            else if (j == 5)
            {
                if (r > 0 & r < 32)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 30 + k;
                    }

                }
            }
            //jul
            else if (j == 6)
            {
                if (r > 0 & r < 31)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 31 + k;
                    }

                }
            }
            //jule
            else if (j == 7)
            {
                if (r > 0 & r < 32)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 31 + k;
                    }

                }
            }
            //aug
            else if (j == 8)
            {
                if (r > 0 & r < 32)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 31 + k;
                    }

                }
            }
            //sep
            else if (j == 9)
            {
                if (r > 0 & r < 31)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 31 + k;
                    }

                }
            }
            //oc
            else if (j == 10)
            {
                if (r > 0 & r < 32)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 30 + k;
                    }

                }
            }
            //no
            else if (j == 11)
            {
                if (r > 0 & r < 31)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 31 + k;
                    }

                }
            }
            //dec
            else if (j == 12)
            {
                if (r > 0 & r < 32)
                {
                    if (r > h)
                    {
                        gg = r - h;
                    }
                    else if (r <= h)
                    {
                        k = r - h;
                        gg = 30 + k;
                    }

                }
            }

            year = i - u;
            mon = j - q;

            if (j < q )
            {
                year--;
                int l = j - q;
                mon = 12 + l;
            }

            textBox8.Text = textBox8.Text + year + " год ";
            textBox8.Text = textBox8.Text + mon + " месяц ";
            textBox8.Text = textBox8.Text + gg + " день ";

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox15.Clear();
        }
    }
       
    }


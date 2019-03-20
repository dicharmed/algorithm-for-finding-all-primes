using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace решето
{
    public partial class Form1 : Form
    {
        
        static bool[] q;
        static int N;
        static bool Yes = false;
        static string t;
        delegate void SetText(string text);
        public Form1()
        {
            InitializeComponent();
        }
        private void Set(string text)
        {
            if (this.textBox2.InvokeRequired)
            {
                SetText d = new SetText(Set);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }
        static void f()
        {
            if (Yes == false)
            {
                for (int i = 2; i < N; i++)
                {
                    q[i] = true;
                }
                for (int i = 2; i < Math.Sqrt(N) + 1; ++i)
                {
                    if (q[i])
                    {
                        for (int j = i * i; j < N; j += i)
                        {
                            q[j] = false;
                        }
                    }
                }
                for (int i = 2; i < N; i++)
                {
                    if (q[i])
                    {
                        t += Convert.ToString(i);
                        t += " ";
                    }
                }

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            N = Convert.ToInt32(textBox1.Text);
            q = new bool[N];
            Thread Thd = new Thread(f);
            Thd.Start();
            button2.Visible = true;
            textBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yes = true;
            Set(t);
            Yes = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeExample_DZ
{
    public partial class Form1 : Form
    {
        string path = "text.txt";
        List<object> remind_lst = new List<object>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = DateTime.Now;
            var txt = textBox1.Text + "\n" + dt.ToString() + "\n";          
            remind_lst.Add(txt);
            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.Write(txt);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                int readLen;
                while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                {
                    textBox1.Text = temp.GetString(b, 0, readLen);
                }    
            }
        }
    }
}

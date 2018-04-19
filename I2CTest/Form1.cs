using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I2CTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            I2CGaugeControl.Open();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Temperature: " + (((ushort) I2CGaugeControl.Temperature) - 20) + " C";
            label2.Text = "Charge: " + (ushort)I2CGaugeControl.Charge + "%";

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint t1 = Convert.ToUInt16(textBox1.Text);
            uint t2 = Convert.ToUInt16(textBox2.Text);
            richTextBox1.Text = bytesToString(I2CGaugeControl.ReadDataFlash((byte) t1, (byte) t2));
        }

        private string bytesToString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            if (bytes != null)
            {
                foreach (byte b in bytes)
                {
                    ushort val = (ushort)b;
                    sb.Append(b + " ");
                }
            }

            return sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = I2CGaugeControl.VerifyBattery().ToString();
        }
    }
}

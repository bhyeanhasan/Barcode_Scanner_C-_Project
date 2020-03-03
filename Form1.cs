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
using ZXing;

namespace Image_view
{
    public partial class BarcodeScanner : Form
    {

        String currentdir = "";

        public BarcodeScanner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box  
                    pictureBox1.Image = new Bitmap(open.FileName);
                    // image file path  
                    textBox1.Text = open.FileName;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Problem Detected");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            try
            {
                Result result = Reader.Decode((Bitmap)pictureBox1.Image);
                string decoded = result.ToString().Trim();
                textBox2.Text = decoded;
            }
            catch(Exception)
            {
                MessageBox.Show("Problem in Barcode");
            }
        }
    }
}

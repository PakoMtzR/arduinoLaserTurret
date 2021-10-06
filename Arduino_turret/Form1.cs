using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Arduino_turret
{
    public partial class Form1 : Form
    {
        public Stopwatch watch { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watch = Stopwatch.StartNew();
            if (!port.IsOpen) port.Open();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            writeToPort(new Point(e.X, e.Y));
        }

        public void writeToPort(Point coordenates)
        {
            if (watch.ElapsedMilliseconds > 40)
            {
                watch = Stopwatch.StartNew();
                port.Write(String.Format("X{0}Y{1}", (180 - (coordenates.X * 180 / Size.Width)), (coordenates.Y * 180 / Size.Width)));
            }   
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (port.IsOpen) port.Close();
        }
    }
}

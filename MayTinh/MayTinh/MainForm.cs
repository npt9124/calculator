using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayTinh
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator form1 = new Calculator();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculator form2 = new Calculator();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopWatch stopWatch = new StopWatch();
            stopWatch.Show();
            DateTime time = DateTime.Now;
        }
    }
}

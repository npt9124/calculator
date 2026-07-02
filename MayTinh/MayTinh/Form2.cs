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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            display2.ReadOnly = true;
            display2.TextAlign = HorizontalAlignment.Right;
        }

        private void InsertAtCursor( string value)
        {
            int pos = display2.SelectionStart;
            if (display2.Text == "0")
            {
                display2.Text = "";
            }
            display2.Text = display2.Text.Insert(pos, value);
            display2.SelectionStart = pos + value.Length;
            display2.Focus();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            InsertAtCursor("0");
            display2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertAtCursor("1");
            display2.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            InsertAtCursor("2");
            display2.Focus();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            InsertAtCursor("3");
            display2.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            InsertAtCursor("4");
            display2.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertAtCursor("5");
            display2.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InsertAtCursor("6");
            display2.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InsertAtCursor("7");
            display2.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InsertAtCursor("8");
            display2.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InsertAtCursor("9");
            display2.Focus();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            display2.Clear();
            display2.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int pos = display2.SelectionStart;
            if( pos > 0)
            {
                display2.Text = display2.Text.Remove(pos - 1, 1);
                display2.SelectionStart = pos - 1;
            }
            if (display2.Text == "")
            {
                display2.Text = "0";
            }
            display2.Focus();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            int pos = display2.SelectionStart;
            if (pos > 0)
            {
                display2.SelectionStart = pos- 1;
            }
            display2.Focus();

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            int pos = display2.SelectionStart;
            if(pos > 0)
            {
                display2.SelectionStart = pos + 1;
            }
            display2.Focus();
        }

        private void buttonOpenPr_Click(object sender, EventArgs e)
        {
            InsertAtCursor("(");
            display2.Focus();
        }

        private void buttonClosePr_Click(object sender, EventArgs e)
        {
            InsertAtCursor(")");
            display2.Focus();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            InsertAtCursor("+");
            display2.Focus();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            InsertAtCursor("-");
            display2.Focus();
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            InsertAtCursor("*");
            display2.Focus();
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            InsertAtCursor("/");
            display2.Focus();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            InsertAtCursor(".");
            display2.Focus();
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            InsertAtCursor("%");
            display2.Focus();
        }
        private string Percentage(string exp)
        {
            return exp.Replace("%", "*0.01");
        }

        private string Power(string exp)
        {
            var part = exp.Split('^');
            double baseNumber = Convert.ToDouble(new DataTable().Compute(part[0], ""));
            double exponent = Convert.ToDouble(new DataTable().Compute(part[1], ""));
            return Math.Pow(baseNumber, exponent).ToString();
        }
        private string SquareRootExpression(string before, string after)
        {
            int count = 0;
            int endIndex = -1;
            for(int i = 0;i <after.Length;i++)
            {
                if (after[i] == '(') count++;
                if (after[i] == ')') count--;
                if(count == 0)
                {
                    endIndex = i;
                    break;
                }    
            }
            string expression = after.Substring(1, endIndex - 1);
            string remaining = after.Substring(endIndex + 1);
            double value = Convert.ToDouble(new DataTable().Compute(expression, ""));
            double result = Math.Sqrt(value);
            return before + result;
        }
        private string SquareRootNumber(string before, string after)
        {
            int i = 0;
            while(i < after.Length && (char.IsDigit(after[i]) || after[i] == '.'))
            {
                i++;
            }
            string number = after.Substring(0,i);
            string remaining = after.Substring(i);
            double value = Convert.ToDouble(number);
            double result = Math.Sqrt(value);
            return before + result.ToString() + remaining;
        }
        private string SquareRoot(string exp)
        {
            while (exp.Contains("√"))
            {
                int index = exp.IndexOf("√");
                string before = exp.Substring(0, index);
                string after = exp.Substring(index + 1);
                if (after.StartsWith("("))
                exp = SquareRootExpression(before, after); 
                else
                exp = SquareRootNumber(before, after); 
            }
            return exp;
        }
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                string exp = display2.Text;
                exp = Percentage(exp);
                if(exp.Contains("^"))
                {
                    display2.Text = Power(exp);
                    return;
                }
                exp = SquareRoot(exp);
                var result = new DataTable().Compute(exp, "");
                display2.Text = result.ToString();
                display2.SelectionStart = display2.Text.Length;
                display2.Focus();
            }
            catch
            {
                MessageBox.Show(" Biểu thức không hợp lệ");
            }

        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            InsertAtCursor("√");
            display2.Focus();
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            InsertAtCursor("^");
            display2.Focus();
        }
    }


}

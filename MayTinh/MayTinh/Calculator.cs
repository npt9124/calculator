using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayTinh
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            display.ReadOnly = true;
            display.Focus();
            display.TextAlign = HorizontalAlignment.Right;
        }
        private void button0_Click(object sender, EventArgs e)
        {
            InsertAtCursor("0");
            display.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertAtCursor("1");
            display.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            InsertAtCursor("2");
            display.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertAtCursor("3");
            display.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            InsertAtCursor("4");
            display.Focus();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            InsertAtCursor("5");
            display.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InsertAtCursor("6");
            display.Focus();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            InsertAtCursor("7");
            display.Focus();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            InsertAtCursor("8");
            display.Focus();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            InsertAtCursor("9");
            display.Focus();
        }
        private void ngoac1_Click(object sender, EventArgs e)
        {
            InsertAtCursor("(");
            display.Focus();
        }
        private void ngoac2_Click(object sender, EventArgs e)
        {
            InsertAtCursor(")");
            display.Focus();
        }
        private void dot_Click(object sender, EventArgs e)
        {
            InsertAtCursor(".");
            display.Focus();
        }
        private void btnplus_Click(object sender, EventArgs e)
        {
            InsertAtCursor("+");
            display.Focus();
        }
        private void btMinus_Click(object sender, EventArgs e)
        {
            InsertAtCursor("-");
            display.Focus();
        }
        private void btnMul_Click(object sender, EventArgs e)
        {
            InsertAtCursor("*");
                display.Focus();
        }
        private void btDiv_Click(object sender, EventArgs e)
        {
            InsertAtCursor("/");
            display.Focus();
        }

        private void del_Click(object sender, EventArgs e)
        {
            display.Focus();
            int pos = display.SelectionStart;

            if (pos > 0 && display.Text.Length > 0)
            {
                display.Text = display.Text.Remove(pos - 1, 1);
                display.SelectionStart = pos - 1;
            }
            if (display.Text == "")
            {
                display.Text = "0";
            }
        }
        private string ProcessPercentage(string exp)
        {
            return exp.Replace("%", "*0.01");
        }
        private string ProcessPower(string exp)
        {
            var parts = exp.Split('^');

            double baseNum =
                Convert.ToDouble(new DataTable().Compute(parts[0], ""));

            double exponent =
                Convert.ToDouble(new DataTable().Compute(parts[1], ""));

            return Math.Pow(baseNum, exponent).ToString();
        }
        private string ProcessSquareRootExpression(string before, string after)
        {
            int count = 0;
            int endIndex = -1;

            for (int i = 0; i < after.Length; i++)
            {
                if (after[i] == '(') count++;
                if (after[i] == ')') count--;

                if (count == 0)
                {
                    endIndex = i;
                    break;
                }
            }

            string expression =
                after.Substring(1, endIndex - 1);

            string remaining =
                after.Substring(endIndex + 1);

            double value =
                Convert.ToDouble(
                    new DataTable().Compute(expression, "")
                );

            double result = Math.Sqrt(value);

            return before + result.ToString() + remaining;
        }

        private string ProcessSquareRootNumber(string before, string after)
        {
            int i = 0;

            while (i < after.Length &&
                  (char.IsDigit(after[i]) || after[i] == '.'))
            {
                i++;
            }

            string number = after.Substring(0, i);
            string remaining = after.Substring(i);

            double value = Convert.ToDouble(number);

            double result = Math.Sqrt(value);

            return before + result.ToString() + remaining;
        }
        private string ProcessSquareRoot(string exp)
        {
            while (exp.Contains("√"))
            {
                int index = exp.IndexOf("√");

                string before = exp.Substring(0, index);
                string after = exp.Substring(index + 1);

                if (after.StartsWith("("))
                    exp = ProcessSquareRootExpression(before, after);
                else
                    exp = ProcessSquareRootNumber(before, after);
            }
            return exp;
        }

        private void ShowResult(string result)
        {
            display.Text = result;
            display.SelectionStart = display.Text.Length;
            display.Focus();
        }
        private void btEqual_Click(object sender, EventArgs e)
        {
            try
            {
                string exp = display.Text;

                exp = ProcessPercentage(exp);

                if (exp.Contains("^"))
                {
                    display.Text = ProcessPower(exp);
                    return;
                }

                exp = ProcessSquareRoot(exp);

                var result = new DataTable().Compute(exp, "");

                ShowResult(result.ToString());
            }
            catch
            {
                MessageBox.Show("Biểu thức không hợp lệ!");
            }
        }


        private void btReturn_Click(object sender, EventArgs e)
        {
            display.Clear();
        }

        private void btnCbh_Click(object sender, EventArgs e)
        {
            InsertAtCursor("√");
            display.Focus();

        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            InsertAtCursor("^");
            display.Focus();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
           InsertAtCursor("%");
            display.Focus();
        }
        private void InsertAtCursor(string value)
        {
            display.Focus();
            int pos = display.SelectionStart;

            if (display.Text == "0")
                display.Text = "";

            display.Text = display.Text.Insert(pos, value);
            display.SelectionStart = pos + value.Length;
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
            int pos = display.SelectionStart;

            if (pos > 0)
                display.SelectionStart = pos - 1;
                display.Focus();
        }

        private void btnright_Click(object sender, EventArgs e)
        {
            int pos = display.SelectionStart;

            if (pos < display.TextLength)
                display.SelectionStart = pos + 1;

            display.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string ToggleSign(string expression)
        {
            if (expression.EndsWith(")"))
            {
                int start = expression.LastIndexOf("(-");

                if (start >= 0)
                {
                    int end = expression.LastIndexOf(")");

                    string number = expression.Substring(start + 2,end - start - 2);

                    return expression.Substring(0, start) + number;
                }
            }

            int pos = expression.Length - 1;

            while (pos >= 0 &&
                  (char.IsDigit(expression[pos]) || expression[pos] == '.'))
            {
                pos--;
            }

            string before = expression.Substring(0, pos + 1);
            string numberPart = expression.Substring(pos + 1);

            if (string.IsNullOrEmpty(numberPart))
                return expression;

            return before + "(-" + numberPart + ")";
        }
        private void MinusPlus(object sender, EventArgs e)
        {
            display.Text = ToggleSign(display.Text);
            display.SelectionStart = display.Text.Length;
            display.Focus();
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            InsertAtCursor("%");
            display.Focus();
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            InsertAtCursor("√");
            display.Focus();
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            InsertAtCursor("^");
            display.Focus();
        }
    }
}

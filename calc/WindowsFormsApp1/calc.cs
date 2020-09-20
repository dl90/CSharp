using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class calc : Form
    {
        protected List<string> ops = new List<string>();
        protected string currNum = "";

        public calc()
        {
            InitializeComponent();
            textBox1.Text = "";
        }

        private void addDigit(string arg)
        {
            textBox1.Text += arg;
            currNum += arg;
        }

        private void addOperator(string arg)
        {
            ops.Add(currNum);
            ops.Add(arg);
            currNum = "";
            textBox1.Text += $" {arg} ";
        }

        private long convert(string arg)
        {
            long n;
            bool parsed = long.TryParse(arg, out n);

            if(parsed)
            {
                return n;
            }
            else
            {
                return 0;
            }
        }

        private string solve(List<string> arg)
        {
            string[] operations = { "*", "/", "%", "+", "-" };
            int idx;
            long left = 0;
            long right = 0;
            long res = 0;

            foreach (string op in operations)
            {
                while (arg.Contains(op))
                {
                    idx = arg.FindIndex(x => x == op);

                    if (idx == 0 || idx == arg.Count)
                    {
                        break;
                    }

                    left = convert(arg[idx - 1]);
                    right = convert(arg[idx + 1]);

                    // System.Diagnostics.Debug.WriteLine(left);
                    // System.Diagnostics.Debug.WriteLine(right);

                    switch (op)
                    {
                        case "*":
                            res = left * right;
                            break;

                        case "/":
                            res = left / right;
                            break;

                        case "%":
                            res = left % right;
                            break;

                        case "+":
                            res = left + right;
                            break;

                        case "-":
                            res = left - right;
                            break;
                    }

                    arg.RemoveRange(idx - 1, 3);
                    arg.Insert(idx - 1, res.ToString());
                }
            }

            ops.Clear();
            currNum = "";
            return res.ToString();
        }

        private void num_1_Click(object sender, EventArgs e)
        {
            addDigit("1");
        }

        private void num_2_Click(object sender, EventArgs e)
        {
            addDigit("2");
        }

        private void num_3s_Click(object sender, EventArgs e)
        {
            addDigit("3");
        }

        private void num_4_Click(object sender, EventArgs e)
        {
            addDigit("4");
        }

        private void num_5_Click(object sender, EventArgs e)
        {
            addDigit("5");
        }

        private void num_6_Click(object sender, EventArgs e)
        {
            addDigit("6");
        }

        private void num_7_Click(object sender, EventArgs e)
        {
            addDigit("7");
        }

        private void num_8_Click(object sender, EventArgs e)
        {
            addDigit("8");
        }

        private void num_9_Click(object sender, EventArgs e)
        {
            addDigit("9");
        }

        private void num_0_Click(object sender, EventArgs e)
        {
            addDigit("0");
        }

        private void enter_Click(object sender, EventArgs e)
        {
            ops.Add(currNum);
            textBox1.Text = solve(ops);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                int len = textBox1.Text.Length - 1;
                textBox1.Text = textBox1.Text.Substring(0, len);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            addOperator("+");
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            addOperator("-");
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            addOperator("*");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            addOperator("/");
        }
    }
}

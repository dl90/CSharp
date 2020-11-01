using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace week_08_lab
{
    public partial class Calculator : Form
    {

        private string curNum = "";
        private List<string> ops = new List<string>();

        public Calculator()
        {
            InitializeComponent();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            output.Text = "";
            curNum = "";
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {
            if (output.Text.Length > 0)
            {
                output.Text = output.Text.Substring(0, output.Text.Length - 1);
            }
        }

        private void addDigit(char arg)
        {
            output.Text += arg;
            curNum += arg;
        }

        private void addOperator(char arg)
        {
            ops.Add(curNum);
            ops.Add(arg.ToString());
            curNum = "";
            output.Text += $" {arg} ";
        }

        private void num_Click(object sender, EventArgs e)
        {
            string str = sender.ToString();
            addDigit(str[str.Length - 1]);
        }

        private void operator_Click(object sender, EventArgs e)
        {
            string str = sender.ToString();
            addOperator(str[str.Length - 1]);
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            ops.Add(curNum);
            string result = Logic.solve(ops);
            curNum = result;
            output.Text = result;

            ops.Clear();
            System.Diagnostics.Debug.WriteLine($"res: {result}");
        }
    }
}

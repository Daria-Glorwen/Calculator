using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double numOne = 0;
        double numTwo = 0;
        string operation = null;
        bool sciMode = false;
        const int widthSmall = 450;
        const int widthLarge = 740;

        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.BackColor = Color.Bisque;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            string buttonName = null;
            Button button = null;

            Display.Text = "0";

            for (int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }

        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0.";
                }
                else
                {
                    Display.Text += ".";
                }
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "0";
            }

            Display.Text = s;

        }

        private void Operation_click (object sender, EventArgs e) 
        {
            Button button = (Button)sender;
            operation = button.Text;
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
        }


        private void buttonSign_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(Display.Text);
            number *= -1;
            Display.Text = Convert.ToString(number);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Display.Text = "+";
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result = 0;
            numTwo = Convert.ToDouble(Display.Text);
            if (operation == "+")
            {
                result = numOne + numTwo;
            }
            else if (operation == "-")
            {
                result = numOne - numTwo;
            }
            else if (operation == "*")
            {
                result = numOne * numTwo;
            }
            else if (operation == "/")
            {
                result = numOne / numTwo;
            }
            else if (operation == "^x")
            {
                result = Math.Pow(numOne, numTwo);
            }

            Display.Text = result.ToString();
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {

        }

        private void buttonSci_Click(object sender, EventArgs e)
        {
            if (sciMode )
            {
                this.Width = widthSmall;
                buttonSci.Text = "Scientific OFF";
            }
            else
            {
                this.Width = widthLarge;
                buttonSci.Text = "Scientific ON";
            }
            sciMode = !sciMode;
        }
    }
}

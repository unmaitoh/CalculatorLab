using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class ExtendForm : Form
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private RpnCalculatorEngine engine;
        public ExtendForm()
        {
            InitializeComponent();
            engine = new RpnCalculatorEngine();
        }

        private string getLastInString(string str)
        {
            if (str.Length == 1)
                return str;
            return str.Substring(str.Length - 1);
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (lblDisplay.Text  == "0")
            {
                lblDisplay.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            lblDisplay.Text += " " + ((Button)sender).Text + " ";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = lblDisplay.Text;
            if (getLastInString(current) == " ")
            {
                lblDisplay.Text = current.Substring(0, current.Length - 3);
            } else
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
            }
            if (lblDisplay.Text == "")
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            isContainDot = false;
            isNumberPart = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            engine.testStackMethod();
            string result = engine.Process(lblDisplay.Text);
            if (result == "E")
            {
                lblDisplay.Text = "Error";
            } else
            {
                lblDisplay.Text = result;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplay.Text;
            if (current == "0")
            {
                lblDisplay.Text = "-";
            } else if (getLastInString(current) == "-")
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text == "")
                {
                    lblDisplay.Text = "0";
                }
            } else
            {
                lblDisplay.Text = current + "-";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(!isContainDot)
            {
                isContainDot = true;
                lblDisplay.Text += ".";
            }
        }
    }
}

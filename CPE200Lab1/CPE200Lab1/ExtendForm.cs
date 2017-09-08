﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace CPE200Lab1
{
    public partial class ExtendForm : Form
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private CalculatorEngine engine;
        private RpnCalculatorEngine rpn;
        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            rpn = new RpnCalculatorEngine();
        }

        private bool isOperator(char ch)
        {
            switch(ch) {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = lblDisplay.Text;
           // if (current[current.Length - 1] != ' ')
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            // check if the last one == operator
            string current = lblDisplay.Text;
            if (current[current.Length - 1] == ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
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
            isSpaceAllowed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string current = lblDisplay.Text;
            string result = rpn.Method(current);
           
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
            } else if (current[current.Length - 1] == '-')
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
            isSpaceAllowed = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if(!isContainDot)
            {
                isContainDot = true;
                lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text == "Error")
            {
                return;
            }
            if(isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
            }
            isContainDot = false;
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = lblDisplay.Text;
            if (current[current.Length - 1] != ' ')
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            }
        }
    }
}



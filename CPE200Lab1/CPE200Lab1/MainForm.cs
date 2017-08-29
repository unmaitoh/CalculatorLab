﻿using System;
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
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;

        private Calculate calculator = new Calculate();

        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }

       /* private string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch(operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if(secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                   
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if(parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    secondOperand = Convert.ToDouble(lblDisplay.Text.Trim('%')).ToString() ;
                    firstOperand = (Convert.ToDouble(secondOperand) / 100 * Convert.ToDouble(firstOperand)).ToString();
                    secondOperand = Convert.ToDouble(0).ToString();
                    lblDisplay.Text = firstOperand.ToString();
                    break;
                case "1/x":
                    return (Convert.ToDouble(1.0 / Convert.ToDouble(firstOperand))).ToString();
            }
            return "E";
        }*/

        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length == 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text == "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "%":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "1/x":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                case "√":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
            }
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;

            string result = calculator.calculate(operate, firstOperand, secondOperand);
            if (result == "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length == 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length == 8)
            {
                return;
            }
            if(lblDisplay.Text[0] == '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost == '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text == "" || lblDisplay.Text == "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void btnmodeM_Click(object sender, EventArgs e)
        {


        }

       

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}

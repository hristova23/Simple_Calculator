using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcEx
{
    public partial class Form1 : Form
    {
        double value = 0;
        string operation = "";
        bool operatorClicked = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if(textBox1.Text == "0" && btn.Text!= ".")
                textBox1.Text = "";

            if (operatorClicked)
            {
                textBox1.Clear();
                operatorClicked = false;
            }

            textBox1.Text += btn.Text;
        }
        private void operator_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (operatorClicked)
            {
                lblResult.Text = lblResult.Text.Remove(lblResult.Text.Length - 1, 1) + btn.Text;
            }
            else
            {
                value = double.Parse(textBox1.Text);
                lblResult.Text += value.ToString();
                lblResult.Text += $" {btn.Text}";
            }

            operation = btn.Text;
            operatorClicked = true;
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
           switch (operation)
                {
                case"+":
                        textBox1.Text = (value + double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (value - double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (value * double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (value / double.Parse(textBox1.Text)).ToString();
                    break;
           }
            lblResult.Text = "";
        }
        private void bntClearEntry_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void bntClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            value = 0;
            lblResult.Text = "";
        }
    }
}

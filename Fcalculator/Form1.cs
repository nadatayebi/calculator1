using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Fcalculator
{
    public partial class Form1 : Form
    {
        
        //fields
        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;

        
        public Form1()
        {
            InitializeComponent();
        }
        //methodes

        private void btnNum_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || enterValue)
                textBox1.Text = string.Empty;
            enterValue = false;
            RJButton button = (RJButton)sender;
            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                {
                    textBox1.Text += button.Text;
                }

            }
            else
                textBox1.Text += button.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rjButton5_Click(object sender, EventArgs e)
        {

        }

        private void rjButton7_Click(object sender, EventArgs e)
        {

        }

        private void rjButton9_Click(object sender, EventArgs e)
        {

        }

        private void btnMathOperations_Click(object sender, EventArgs e)
        {
            if (result != 0) btnEqual.PerformClick();
            else result = Double.Parse(textBox1.Text);
            RJButton button = (RJButton)sender;
            operation = button.Text;
            enterValue = true;
            if (textBox1.Text != "0")
            {
                txtDisplay.Text = fstNum = $"{result}{operation}";
                textBox1.Text = string.Empty;
            }
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            else if (textBox1.Text == string.Empty)
                textBox1.Text = "0";

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            secNum = textBox1.Text;
            txtDisplay.Text = $"{txtDisplay.Text}{textBox1.Text}=";
            if (textBox1.Text != string.Empty)
            {
                if (textBox1.Text == "0")
                    txtDisplay.Text = string.Empty;
                switch (operation)
                {
                    case "+":
                        textBox1.Text = (result + double.Parse(textBox1.Text)).ToString();
                        richTextBoxHistoryDisplay.AppendText($"{fstNum}{secNum}={textBox1.Text}\n");
                        break;
                    case "-":
                        textBox1.Text = (result - double.Parse(textBox1.Text)).ToString();
                        richTextBoxHistoryDisplay.AppendText($"{fstNum}{secNum}={textBox1.Text}\n");
                        break;
                    case "×":
                        textBox1.Text = (result * double.Parse(textBox1.Text)).ToString();
                        richTextBoxHistoryDisplay.AppendText($"{fstNum}{secNum}={textBox1.Text}\n");
                        break;
                    case "÷":
                        textBox1.Text = (result / double.Parse(textBox1.Text)).ToString();
                        richTextBoxHistoryDisplay.AppendText($"{fstNum}{secNum}={textBox1.Text}\n");
                        break;
                    default:txtDisplay.Text = $"{textBox1.Text}=";
                        break;

                }
                result = double.Parse(textBox1.Text);
                operation = string.Empty;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

            if (panelHistory.Height <= 5)
            {
                panelHistory.Height = 366;
            }
            else if (panelHistory.Height > 5)
            {
                panelHistory.Height = 5;
            }
        }

        private void richBoxHistoryDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            txtDisplay.Text = string.Empty;
            result = 0;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void mathOper(object sender, EventArgs e)
        {
            RJButton button = (RJButton)sender;
            operation = button.Text;
            switch (operation)
            {
                case "√":
                    txtDisplay.Text = $"√({textBox1.Text})";
                    textBox1.Text = Convert.ToString(Math.Sqrt(double.Parse(textBox1.Text)));
                    break;

                case "^2":
                    txtDisplay.Text = $"({textBox1.Text})^2";
                    textBox1.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text));
                    break;
                case "⅟":
                    txtDisplay.Text = $"⅟({textBox1.Text})";
                    textBox1.Text = Convert.ToString(1.0 / Convert.ToDouble(textBox1.Text));
                    break;
                case "%":
                    txtDisplay.Text = $"%({txtDisplay.Text})";
                    textBox1.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) / Convert.ToDouble(100));
                    break;
                case "2":
                    textBox1.Text = Convert.ToString(-1*Convert.ToDouble(textBox1.Text));
                    break;


            }
            richTextBoxHistoryDisplay.AppendText($"{txtDisplay.Text}{textBox1.Text}\n");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (!(richTextBoxHistoryDisplay.Text == string.Empty))
            {
                richTextBoxHistoryDisplay.Clear();
            }
            else
                MessageBox.Show("no history");
        }

        
    }
}

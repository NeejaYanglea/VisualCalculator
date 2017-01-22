using System;
using System.Linq;
using System.Windows.Forms;

namespace VisualCalculator
{
    public partial class Form1 : Form
    {
        private bool startSecondNumber = false;
        private bool firstNumberAdded = false;
        private bool deleteOnType = false;
        private Calculator c = new Calculator();

        public Form1()
        {
            InitializeComponent();
            c.DecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
        }

        private void writeNumber(char num)
        {
            if (startSecondNumber)
            {
                textBox1.Text = "";
                startSecondNumber = false;
            }

            if (textBox1.Text == "0" || deleteOnType)
                textBox1.Text = "";

            if (textBox1.Text.Length >= c.MaxLenghtFloat)
                return;

            textBox1.Text += num;
            deleteOnType = false;
            buttonPoint.Text = c.DecimalSeparator.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            writeNumber('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeNumber('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            writeNumber('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            writeNumber('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            writeNumber('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            writeNumber('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            writeNumber('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            writeNumber('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            writeNumber('9');
        }

        private void button0_Click(object sender, EventArgs e)
        {
            writeNumber('0');
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(c.DecimalSeparator))
                writeNumber(c.DecimalSeparator);
        }

        private void buttonCanc_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text[0] != '-')
                textBox1.Text = "-" + textBox1.Text;
            else if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Remove(0, 1);
        }

        private void setOperation(char op)
        {
            c.FirstNumber = textBox1.Text;
            c.Operation = op;
            startSecondNumber = true;
            firstNumberAdded = true;
            deleteOnType = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            setOperation('+');
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            setOperation('-');
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            setOperation('*');
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            setOperation('/');
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            if (firstNumberAdded)
            {
                c.SecondNumber = textBox1.Text;

                addOperationToResults();
                string result = c.Calculate();
                addOperationToResults(result);
                deleteOnType = true;
                textBox1.Text = result;
                softReset();
            }
            else
            {
                addOperationToResults($"{textBox1.Text} = {textBox1.Text}");
                deleteOnType = true;
                softReset();
            }
        }

        private void addOperationToResults()
        {
            results.Items.Add($"{c.FirstNumber} {c.Operation}");
            results.Items.Add($"{c.SecondNumber} =");
            results.Items.Add("------------------------------------");
        }
        private void addOperationToResults(string result)
        {
            results.Items.Add($"{result}   ");
            results.Items.Add("");
        }

        private void buttonCancAll_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void softReset()
        {
            c.Reset();
            firstNumberAdded = false;
            startSecondNumber = false;
        }

        private void reset()
        {
            softReset();
            textBox1.Text = "";
            deleteOnType = false;
        }
    }
}

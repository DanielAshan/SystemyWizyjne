using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        enum Operations {add, substract, multiply, divide, modulo, sinus, cosinus, square, squareroot }

        Operations selectedOperation;
        int workingTime = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
     
        }

        private void add_To_History_List()
        {
            String historyRecord = "";
            historyRecord += firstNumberField.Text + " " + selectedOperation.ToString() + " " + secondNumberField.Text + " = " + resultField.Text;
            var listViewItem = new ListViewItem(historyRecord);
            historyList.Items.Add(listViewItem);
        }

        private void execute_Task()
        {

            double numberOne, numberTwo, result;
            numberOne = numberTwo = result = 0;

            try
            {
                numberOne = Convert.ToDouble(firstNumberField.Text);
                numberTwo = Convert.ToDouble(secondNumberField.Text);
            }
            catch (Exception e)
            {
                throw new Exception("Cannot convert text to number" + e.ToString());
            }

            switch (selectedOperation)
            {
                case Operations.add:
                    result = numberOne + numberTwo;
                    break;
                case Operations.substract:
                    result = numberOne + numberTwo;
                    break;
                case Operations.multiply:
                    result = numberOne * numberTwo;
                    break;
                case Operations.divide:
                    result = numberOne / numberTwo;
                    break;
                case Operations.modulo:
                    result = numberOne % numberTwo;
                    break;
                case Operations.sinus:
                    result = Math.Sin(numberOne);
                    break;
                case Operations.cosinus:
                    result = Math.Cos(numberOne);
                    break;
                case Operations.square:
                    result = Math.Pow(numberOne, 2);
                    break;
                case Operations.squareroot:
                    result = Math.Sqrt(numberOne);
                    break;
                default:
                    break;
            }

            resultField.Text = result.ToString();
            add_To_History_List();
        }

        private void check_Operation_Radio()
        {
            switch (selectedOperation)
            {
                case Operations.add:
                    addOperationRadio.Select();
                    break;
                case Operations.substract:
                    substractOperationRadio.Select();
                    break;
                case Operations.multiply:
                    multiplyOperationRadio.Select();
                    break;
                case Operations.divide:
                    divideOperationRadio.Select();
                    break;
                case Operations.modulo:
                    moduloOperationRadio.Select();
                    break;
                case Operations.sinus:
                    sinusOperationRadio.Select();
                    break;
                case Operations.cosinus:
                    cosinusOperationRadio.Select();
                    break;
                case Operations.square:
                    squareOperationRadio.Select();
                    break;
                case Operations.squareroot:
                    squarerootOperationRadio.Select();
                    break;
                default:
                    break;
            }
        }

        private void select_Operation(Operations opName)
        {
            selectedOperation = opName;
            check_Operation_Radio();
       }

        private void add_Character(char number)
        {
            if (firstNumberRadio.Checked)
            {
                firstNumberField.Text += number;
            }
            else if (secondNumberRadio.Checked)
            {
                secondNumberField.Text += number;
            }
        }

        private void zeroNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('0');
        }

        private void commaCharButton_Click(object sender, EventArgs e)
        {
            add_Character('.');
        }

        private void oneNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('1');
        }

        private void twoNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('2');
        }

        private void threeNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('3');
        }

        private void fourNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('4');
        }

        private void fiveNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('5');
        }

        private void sixNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('6');
        }

        private void sevenNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('7');
        }

        private void eightNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('8');
        }

        private void nineNumberButton_Click(object sender, EventArgs e)
        {
            add_Character('9');
        }

        private void addOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.add);
        }

        private void substractOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.substract);
        }

        private void multiplyOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.multiply);
        }

        private void divideOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.divide);
        }

        private void moduloOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.modulo);
        }

        private void squareOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.square);
        }

        private void sqrtOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.squareroot);
        }

        private void cosinusOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.cosinus);
        }

        private void sinusOperationButton_Click(object sender, EventArgs e)
        {
            select_Operation(Operations.sinus);
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            execute_Task();
        }

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            historyList.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            workingTime++;          
            toolStripStatusLabel1.Text = string.Format("Program is working for {0} seconds", workingTime);
            statusStrip1.Refresh();
        }
    }
}

using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private char _operation;
        private bool _isScreenClear;
        private int _firstNumber;


        public Form1()
        {
            InitializeComponent();
            InitializeNumberButtons();
            InitializeOperaionButtons();
        }
        private void InitializeNumberButtons()
        {
            Button[] numberButtons = new Button[]
            {
                numberOneButton, numberTwoButton, numberTreeButton,
                numberFourButton, numberFiveButton, numberSixButton,
                numberSevenButton, numberEightButton, numberNineButton,
                numberZeroButton
            };

            foreach (var button in numberButtons)
            {
                button.Click += NumberButton_Click;
            }
        }
        private void InitializeOperaionButtons()
        {
            Button[] operationButtons = new Button[]
            {
                plusButton, minusButton, multiplicationButton,
                dividingButton
            };

            foreach (var button in operationButtons)
            {
                button.Click += OperationButton_Click;
            }
        }
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string clickValue = clickedButton.Text;
            PrintClickedValue(clickValue);
        }

        private void PrintClickedValue(string clickValue)
        {
            if (_isScreenClear)
            {
                resualtScreenLabel.Text = "";
                _isScreenClear = false;
            }

            if (resualtScreenLabel.Text == "0")
                resualtScreenLabel.Text = "";

            resualtScreenLabel.Text += clickValue;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string clickValue = clickedButton.Text;

            _operation = _operation = clickValue[0];
            _isScreenClear = true;
            _firstNumber = Convert.ToInt32(resualtScreenLabel.Text);
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            int _secondNumber = Convert.ToInt32(resualtScreenLabel.Text);
            int sonuc;

            switch (_operation)
            {
                case '+':
                    sonuc = _firstNumber + _secondNumber;
                    break;
                case '-':
                    sonuc = _firstNumber - _secondNumber;
                    break;
                case 'X':
                    sonuc = _firstNumber * _secondNumber;
                    break;
                case '/':
                    sonuc = _firstNumber / _secondNumber;
                    break;

                default:
                    sonuc = 0;
                    break;
            }

            resualtScreenLabel.Text = Convert.ToString(sonuc);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resualtScreenLabel.Text = "0";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCalculator
{
    class Calculator
    {
        public int MaxLenghtInt = 9;
        public int MaxLenghtFloat = 39;
        public string FirstNumber = "0";
        public string SecondNumber = "0";
        public char Operation = '0';
        public char DecimalSeparator = '.';

        public void Reset()
        {
            FirstNumber = "0";
            SecondNumber = "0";
            Operation = '0';
        }
        public string Calculate()
        {
            switch (Operation)
            {
                case '+':
                    return add();
                case '-':
                    return subtract();
                case '*':
                    return multiply();
                case '/':
                    return division();
                default:
                    return null;
            }
        }

        private int discordSign()
        {
            if (FirstNumber.Contains("-") && !SecondNumber.Contains("-"))
                return -1;
            else if (!FirstNumber.Contains("-") && SecondNumber.Contains("-"))
                return 1;
            return 0;
        }

        private string add()
        {
            if (discordSign() == -1)
            {
                FirstNumber = FirstNumber.Remove(0, 1);
                string app = FirstNumber;
                FirstNumber = SecondNumber;
                SecondNumber = app;
                return subtract();
            }
            else if (discordSign() == 1)
            {
                SecondNumber = SecondNumber.Remove(0, 1);
                return subtract();
            }
            int max = Math.Max(FirstNumber.Length, SecondNumber.Length);
            if (max > MaxLenghtInt - 1 || FirstNumber.Contains(DecimalSeparator) || SecondNumber.Contains(DecimalSeparator))
                return (float.Parse(FirstNumber) + float.Parse(SecondNumber)).ToString();
            else
                return (Convert.ToInt64(FirstNumber) + Convert.ToInt64(SecondNumber)).ToString();
        }

        private string subtract()
        {
            if (discordSign() == -1)
            {
                SecondNumber = "-" + SecondNumber;
                return add();
            }
            else if (discordSign() == 1)
            {
                SecondNumber = SecondNumber.Remove(0, 1);
                return add();
            }
            if (FirstNumber.Length > MaxLenghtInt || SecondNumber.Length > MaxLenghtInt || FirstNumber.Contains(DecimalSeparator) || SecondNumber.Contains(DecimalSeparator))
                return (float.Parse(FirstNumber) - float.Parse(SecondNumber)).ToString();
            else
                return (Convert.ToInt64(FirstNumber) - Convert.ToInt64(SecondNumber)).ToString();
        }

        private string multiply()
        {
            if (FirstNumber.Length + SecondNumber.Length > MaxLenghtInt || FirstNumber.Contains(DecimalSeparator) || SecondNumber.Contains(DecimalSeparator))
                return (float.Parse(FirstNumber) * float.Parse(SecondNumber)).ToString();
            else
                return (Convert.ToInt64(FirstNumber) * Convert.ToInt64(SecondNumber)).ToString();
        }

        private string division()
        {
            try
            {
                float result = float.Parse(FirstNumber) / float.Parse(SecondNumber);
                if (float.IsInfinity(result))
                    throw new DivideByZeroException();
                return (result).ToString();
            }
            catch (DivideByZeroException)
            {
                return "can't divide by zero";
            }
        }
    }

}

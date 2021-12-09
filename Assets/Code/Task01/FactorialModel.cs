

using System;

namespace MSuhinin.Factorial
{
    public class FactorialModel 
    {
        int inputDigit;
        int factorial;
        int sumDigit;
        int maxDigit;

        public int InputDigit { get => inputDigit; set=>inputDigit=value; }
        public int Factorial { get => factorial; set => factorial = value; }
        public int SumDigit { get => sumDigit; set => sumDigit = value; }
        public int MaxDigit { get => maxDigit; set => maxDigit = value; }

        public FactorialModel(int inputDigit, int factorial, int sumDigit, int maxDigit)
        {
            InputDigit = inputDigit;
            Factorial = factorial;
            SumDigit = sumDigit;
            MaxDigit = maxDigit;
        }     
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSuhinin.Factorial
{
    public class FactorialController:IFactorial
    {
        IView view;
        FactorialModel factorialModel;
        int input = 0;
        Int32 factorial = 1;
        int sum = 0;
        int max = 0;

        public FactorialController(IView view, FactorialModel factorialModel)
        {
            this.view = view;
            this.FactorialModel = factorialModel;
        }
        public FactorialModel FactorialModel { get => factorialModel; set => factorialModel = value; }
        public void CalcFactorial()
        {
            input = view.InputDigit;
            for (int i = 1; i <= input; i++)
            {
                factorial = factorial * i;
                sum = sum + i;
                if (i % 2 == 0)
                {
                    max = i;
                }
            }
        }
        public void UpdateModel()
        {
            FactorialModel.InputDigit = view.InputDigit;
            FactorialModel.Factorial = factorial;
            FactorialModel.MaxDigit = max;
            FactorialModel.SumDigit = sum;
        }
    }
}

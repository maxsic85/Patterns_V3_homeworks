using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSuhinin.Factorial
{
    public class FactorialCalculation : IFactorialCalculation
    {
        IView view;
        FactorialModel factorialModel;
        int input = 0;
        Int32 CalcResultFactorial = 1;
        int CalcResultSum = 0;
        int CalcResultMax = 0;

        public FactorialCalculation (IView view, FactorialModel factorialModel)
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
                CalcResultFactorial = CalcResultFactorial * i;
                CalcResultSum = CalcResultSum + i;
                if (i % 2 == 0)
                {
                    CalcResultMax = i;
                }
            }
        }
        public void UpdateModel()
        {
            FactorialModel.InputDigit = view.InputDigit;
            FactorialModel.Factorial = CalcResultFactorial;
            FactorialModel.MaxDigit = CalcResultMax;
            FactorialModel.SumDigit = CalcResultSum;
        }
    }
}

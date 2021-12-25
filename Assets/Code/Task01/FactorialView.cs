using System;
using UnityEngine;

namespace MSuhinin.Factorial
{
    public class FactorialView : MonoBehaviour, IView
    {
        public int inputDigit;
        public int InputDigit { get => inputDigit; set => inputDigit = (inputDigit >= 0 && inputDigit<13) ? value : throw new ArgumentOutOfRangeException("Incorrect Input"); }
        public void ShowGreeting()
        {
            Debug.Log("¬ведите число в диапазоне от 0 до 13");
        }
        public int GetInput()
        {
            return InputDigit=inputDigit;
        }
        public void ShowResult(IFactorial factorialController)
        {
            Debug.Log($" inputDigit {factorialController.FactorialModel.InputDigit}");
            Debug.Log($" Factorial {factorialController.FactorialModel.Factorial}");
            Debug.Log($" Sum {factorialController.FactorialModel.SumDigit}");
            Debug.Log($" Max {factorialController.FactorialModel.MaxDigit}");

        }
    }
}

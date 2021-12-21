using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSuhinin.Factorial
{
    public interface IView
    {
        public int InputDigit { get; set; }
        void ShowGreeting();
        int GetInput();
        void ShowResult(IFactorialCalculation factorialController);
    }

}

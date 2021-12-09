using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSuhinin.Factorial
{
    public class Starter : MonoBehaviour
    {
        FactorialController factorialController;
        IView view;
        void Start()
        {
            view = FindObjectOfType<FactorialView>();
            view.ShowGreeting();
            view.GetInput();
            factorialController = new FactorialController(view, new FactorialModel(0, 0, 0, 0));
            factorialController.CalcFactorial();
            factorialController.UpdateModel();
            view.ShowResult(factorialController);
        }
    }
}

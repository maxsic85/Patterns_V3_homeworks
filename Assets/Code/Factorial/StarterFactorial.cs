using UnityEngine;

namespace MSuhinin.Factorial
{
    public class StarterFactorial : MonoBehaviour
    {
        IFactorialCalculation factorialCalculation;
        IView view;
        void Start()
        {
            view = FindObjectOfType<FactorialView>();
            view.ShowGreeting();
            view.GetInput();
            factorialCalculation = new FactorialCalculation(view, new FactorialModel());
            factorialCalculation.CalcFactorial();
            factorialCalculation.UpdateModel();
            view.ShowResult(factorialCalculation);
        }
    }
}

namespace MSuhinin.Factorial
{
    public interface IFactorialCalculation
    {
        FactorialModel FactorialModel { get; set; }
        void CalcFactorial();
        void UpdateModel();
    }
}
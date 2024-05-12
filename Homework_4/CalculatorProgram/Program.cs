using CalculatorProgram;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

UserCommunicator.CalculatorGreeting();
bool isOneMoreCalculation = true;

while (isOneMoreCalculation)
{
    Console.Write("Input any expression: ");
    string expression = (Console.ReadLine() ?? string.Empty).ToLower();

    string[] expressionArr = ExpressionProcessor.GetExpressionElements(expression);

    string action = expressionArr[0];
    double result;
    if (action == "sin")
    {
        int num = int.Parse(expressionArr[1]);
        result = Calculator.Sin(num);
    } 
    else if (action == "cos")
    {
        int num = int.Parse(expressionArr[1]);
        result = Calculator.Cos(num);
    }    
    else 
    {
        int num1 = int.Parse(expressionArr[1]);
        int num2 = int.Parse(expressionArr[2]);
        result = Calculator.Calculate(num1, num2, action);
    }
    

    UserCommunicator.CalculatorFinishing(result);
    isOneMoreCalculation = UserCommunicator.CalculatorContinuing();
    Console.WriteLine();
}

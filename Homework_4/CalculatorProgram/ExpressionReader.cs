using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    internal class ExpressionProcessor
    {
        public static string[] GetExpressionElements(String expression)
        {
            string reExpressionSimple = @"^[0-9]+[\+-/\*\^]{1}[0-9]+$";
            string reExpressionSinCos = @"^(cos)|(sin)\([0-9]+\)$";
            Regex reReplace = new Regex(@"\s+");
            expression = reReplace.Replace(expression, "");

            if (Regex.IsMatch(expression, reExpressionSimple))
            {
                return GetSimpleExpressionElements(expression);
            } 
            else if (Regex.IsMatch(expression, reExpressionSinCos))
            {
                return GetSinCosElements(expression);
            }
            else
            {
                throw new ArgumentException("You should input simple expression!");
            }    

        }


        public static string[] GetSimpleExpressionElements(string expression)
        {
            string reSymbol = @"[\+\*\^/-]";
            string actionSymbol = Regex.Match(expression, reSymbol).Value;
            string[] numArr = expression.Split(actionSymbol);

            string[] expressionArr = new string[numArr.Length + 1];
            Array.ConstrainedCopy(numArr, 0, expressionArr, 1, numArr.Length);
            expressionArr[0] = actionSymbol;
            return expressionArr;
        }

        public static string[] GetSinCosElements(string expression)
        {
            string reSymbol = @"(cos)|(sin)";
            string reNum = @"[0-9]+";
            string actionSymbol = Regex.Match(expression, reSymbol).Value;
            string strNum = Regex.Match(expression, reNum).Value;
            string[] expressionArr = new string[2];
            expressionArr[0] = actionSymbol;
            expressionArr[1] = strNum;
            return expressionArr;
        }
    }
}

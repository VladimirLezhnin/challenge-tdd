using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixCalculator
    {
        public static string Calculate(string postfixExpression)
        {
            if (postfixExpression == "") return "0";
            if (postfixExpression == null) throw new FormatException();

            var splited = postfixExpression.Split();

            if (splited.Length == 1) 
            {
                try
                {
                    int num = int.Parse(splited[0]);
                } 
                catch
                {
                    throw new FormatException();
                }
                return splited[0];
            }

            var digits = new List<int>();

            foreach (var item in splited) {
                int num;
                if (int.TryParse(item, out num)) {
                    digits.Add(num);
                } 
                else
                {
                    if (digits.Count < 2) throw new FormatException();
                    switch (item)
                    {
                        case "+":
                            digits[0] += digits[1];
                            digits.RemoveAt(1);
                            break;
                        case "-":
                            digits[0] -= digits[1];
                            digits.RemoveAt(1);
                        
                            break;
                        case "*":
                            digits[0] *= digits[1];
                            digits.RemoveAt(1);

                            break;
                        case "/":
                            digits[0] /= digits[1];
                            digits.RemoveAt(1);

                            break;
                        default:
                            throw new FormatException();
                    }
                }
            }

            if (digits.Count>1) throw new FormatException();
            
            return digits[0].ToString();
        }
    }
}

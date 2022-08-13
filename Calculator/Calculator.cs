using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Calculator
{
    class Calculator
    {
        string displayStr { get; set; } = "0";
        string calcStr { get; set; } = "0";
        string operation { get; set; } = null;

        public void Press(string key)
        {
            if (key.Length > 1) return;
            //Checks if key pressed is a number or not
            int numericValue;
            bool isNumber = int.TryParse(key, out numericValue);

            //Checks if key pressed is operand
            bool isOperation = CheckIsOperation(char.Parse(key));

            //Checks if the first digit is 0, if yes, it replaces it with the pressed key
            if(isNumber)
            {
                if(displayStr.Length == 1 && displayStr == "0")
                {
                    displayStr = key;
                    calcStr = calcStr.Length == 1 ? key : calcStr;
                    return;    
                }

                if (operation != null)
                {
                    calcStr += key;
                    displayStr = key;
                    operation = null;
                }
                else
                {
                    displayStr += key;
                    calcStr = calcStr.Length == 1 && calcStr[0] == '0'? key : calcStr + key;
                }
            }

            else
            {
                if(isOperation)
                {
                    operation = key;
                    if(!CheckIsOperation(calcStr[calcStr.Length - 1]) && calcStr[0]!= '0')
                    {
                        calcStr += operation;
                    }
                }
                else
                {
                    if(key == "C")
                    {
                        displayStr = "0";
                        calcStr = "0";
                        operation = null;
                    }

                    else if(key == "=")
                    {
                        displayStr = calcStr;
                        calcStr = "0";
                        DataTable dt = new DataTable();
                        displayStr = dt.Compute(displayStr, "").ToString();
                    }

                    else
                    {
                        return;
                    }
                }
            }


        }

        public string GetDisplay()
        {
            return 5 >= displayStr.Length ? displayStr : displayStr.Substring(displayStr.Length - 5);
        }

        private bool CheckIsOperation(char key)
        {
            return (key == '-' || key == '+' || key == '*' || key == '/') ? true : false;
        }
    }
}

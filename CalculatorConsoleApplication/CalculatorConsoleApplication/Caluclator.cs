using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsoleApplication
{
    public class Caluclator : ICaluclator
    {
        //Arithmetic Operator Constants
        private const string OPERATORPLUS = "+";
        private const string OPERATORMINUS = "-";
        private const string OPERATORMULTIPLY = "*";
        private const string OPERATORDIVSION = "/";

        #region Public Methods
        /// <summary>
        /// Methos is used to split the input and calculate value
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>string message</returns>
        public string Caluclation(string input)
        {
            string message;
            try
            {
                if (ValidateInput(input, out message) && message == string.Empty)
                {
                    /*Variables declaration*/
                    int sOutput, output;

                    //split the input value with operator to get numbers
                    string[] splitInput = input.Split(new Char[] { '+', '-', '*', '/' });

                    //split the input value with number to get operators
                    string[] splitsigns = input.Split(new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, StringSplitOptions.RemoveEmptyEntries);


                    int firstNum = int.Parse(splitInput[0].ToString()) != 0? int.Parse(splitInput[0].ToString()):0;
                    int secondNum = int.Parse(splitInput[1].ToString()) != 0 ? int.Parse(splitInput[1].ToString()) : 0;
                    int thirdNum = int.Parse(splitInput[2].ToString()) != 0 ? int.Parse(splitInput[2].ToString()) : 0;

                    string firstOperator = splitsigns[0] != string.Empty? splitsigns[0]:string.Empty;
                    string secondOperator = splitsigns[1] != string.Empty ? splitsigns[1] : string.Empty;

                    //As per arithmetic operators precedence (*) and (/) are first
                    if (firstOperator == "*" || firstOperator == "/")
                    {
                        sOutput = CaluclationExecution(firstOperator, firstNum, secondNum);
                        output = CaluclationExecution(secondOperator, sOutput, thirdNum);
                        Console.WriteLine("Result: "+ output);

                    }
                    else if (firstOperator == "-" || firstOperator == "+")
                    {
                        sOutput = CaluclationExecution(secondOperator, secondNum, thirdNum);
                        output = CaluclationExecution(firstOperator, firstNum, sOutput);
                        Console.WriteLine("Result: " + output);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return message;

        }

        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Method is used to perform the operation based on Arithmetic Operator
        /// </summary>
        /// <param name="opt">Arithmetic Operator</param>
        /// <param name="num1">integer</param>
        /// <param name="num2">integer</param>
        /// <returns>integer</returns>
        private int CaluclationExecution(string opt, int num1, int num2)
        {
            int fOutput;
            try
            {
                switch (opt)
                {
                    case OPERATORMULTIPLY:
                        fOutput = num1 * num2;
                        break;
                    case OPERATORDIVSION:
                        fOutput = num1 / num2;
                        break;
                    case OPERATORPLUS:
                        fOutput = num1 + num2;
                        break;
                    case OPERATORMINUS:
                        fOutput = num1 - num2;
                        break;
                    default:
                        fOutput = 0;
                        break;
                }
                return fOutput;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Method is used to validate the input value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        private bool ValidateInput(string input, out string message)
        {
            bool isvalid = true;
            message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    bool isoperatorexists = false;
                    int temp;
                    for (var i = 0; i < input.Length; i++)
                    {
                        //Check the input have atleast one arithmetic operator
                        if (input[i].ToString() == OPERATORPLUS || input[i].ToString() == OPERATORMINUS ||
                            input[i].ToString() == OPERATORMULTIPLY || input[i].ToString() == OPERATORDIVSION)
                        {
                            isoperatorexists = true;
                        }

                        //Check the input have numeric or not
                        else if (!int.TryParse(input[i].ToString(), out temp))
                        {

                            message = "Input value does not contains a numeric value";
                            break;
                        }
                    }

                    if (!isoperatorexists)
                    {
                        message = "Please enter a valid input for caluclation ex: 2*3+5";
                    }

                }
                else
                {
                    isvalid = false;
                    message = "Please Enter Input";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isvalid;
        }

        #endregion
    }
}

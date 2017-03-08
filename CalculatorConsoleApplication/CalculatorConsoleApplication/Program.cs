using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Variables declaration*/
            string input = string.Empty;
            string message = string.Empty;

            Console.WriteLine("Please enter your input ");
            input = Console.ReadLine();

            Caluclator cal = new Caluclator();

            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    if (input.Split(',').Count() > 1)
                    {
                        string[] splitInputList = input.Split(',');

                        foreach (string val in splitInputList)
                        {
                            try
                            {
                                message = cal.Caluclation(val);
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    else
                    {
                        message = cal.Caluclation(input);
                    }
                    Console.WriteLine(message);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}


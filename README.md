# Project name:
CalculatorConsoleApplication
# Description:
This application will allow users to perform single and batch calculations for only three numbers.
# Internal Design:
Leveraged Interface implementation for future extension of application with out disturbing main components.
Created Interface Icalculator with abstract method calculation which takes as input a string .
Parses input and stores digits and operators in string array and execute the calculation with arithmetic precedence.
#Assumptions:
No unary operators or parentheses passed in input.



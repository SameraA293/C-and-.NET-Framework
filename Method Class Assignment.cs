using System;

namespace MathApp
{
    // Define a class named Calculator
    class Calculator
    {
        // Define a void method that takes two integers as parameters
        public void ProcessNumbers(int number1, int number2)
        {
            // Perform a math operation on the first integer (e.g., multiply by 2)
            int result = number1 * 2;

            // Display the result of the math operation
            Console.WriteLine("Result of math operation on first number: " + result);

            // Display the second integer to the screen
            Console.WriteLine("Second number is: " + number2);
        }
    }

    // Main class containing the entry point of the application
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the Calculator class
            Calculator calc = new Calculator();

            // Call the method, passing in two numbers directly
            calc.ProcessNumbers(5, 10); // This will multiply 5 by 2 and display 10

            // Call the method, specifying the parameters by name
            calc.ProcessNumbers(number1: 7, number2: 20); // This will multiply 7 by 2 and display 20

            // Keep the console window open until a key is pressed
            Console.ReadKey();
        }
    }
}
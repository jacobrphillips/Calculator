class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        int numberOfTimesUsed = 0;

        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Declare variables and then initialize to zero.
            double num1 = 0;
            double num2 = 0;
            double result = 0;


            // Boolean value to use as the while loop's conditional.
            bool run = true;
            while (run)
            {
                

                // Ask the user to type the first number.
                Console.WriteLine("Type a number, and then press Enter");

                // Record user input from Console into string variable.
                string input1 = Console.ReadLine();

                // If the user's input can be converted from string to double, then the boolean value for the while loop's conditional is set to false, ending the loop. 
                // Else, it notifies the user to please enter a numerical value.
                if (double.TryParse(input1, out num1))
                {
                    run = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a numerical value.");
                }
            }

            // Ask the user to type the second number.
            bool run2 = true;
            while (run2)
            {
                Console.WriteLine("Type another number, and then press Enter");

                string input2 = Console.ReadLine();

                if (double.TryParse(input2, out num2))
                {
                    run2 = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a numerical value.");
                }
            }


            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string operation = Console.ReadLine();
            numberOfTimesUsed++;

            try
            {
                result = Calculator.DoOperation(num1, num2, operation);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }else
                {
                    Console.WriteLine("Your result: {0}", result);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception error occured trying to do the math.\n - Details " + e.Message);
            }
            Console.WriteLine($"The calculator has been used {numberOfTimesUsed} number of times");
            Console.WriteLine("------------------------------\n");

            // Wait for the user to respond before closing 
            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: " );
            if(Console.ReadLine() == "n")
            {
                endApp = true;
            }
            Console.WriteLine("\n");
        }
        return;
    }
}

class Calculator
{
    public static double DoOperation(double num1, double num2, string operation)
    {
        double result = double.NaN;

        switch (operation)
        {
            case "a":
                result = num1 + num2;
                Console.WriteLine($"Your equation: {num1} + {num2}");
                break;
            case "s":
                result = num1 - num2;
                Console.WriteLine($"Your equation: {num1} - {num2}");
                break;
            case "m":
                result = num1 * num2;
                Console.WriteLine($"Your equation: {num1} * {num2}");
                break;
            case "d":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                Console.WriteLine($"Your equation: {num1} / {num2}");
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
        return result;

    }
}
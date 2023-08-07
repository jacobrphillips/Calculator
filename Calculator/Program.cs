using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        int numberOfTimesUsed = 0;
        List<double> listOfAllCalculations = new List<double>();
        double num1 = 0;

        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            double result = 0;
            // Boolean value to use as the while loop's conditional.
            bool run = true;
            while (run)
            {
                if (num1 > 0)
                {
                    run = false;
                }
                else
                {
                    // Ask the user to type the first number.
                    Console.WriteLine("Type a number, and then press Enter");
                    string input1 = Console.ReadLine();

                    // If the user's input can be converted from string to double, then the boolean value for the while loop's conditional is set to false, ending the loop. 
                    // Else, it notifies the user to please enter a numerical value.
                    if (double.TryParse(input1, out num1))
                    {
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a numerical value.");
                    }
                }
            }

            // Ask the user to type the second number.
            bool run2 = true;
            double num2 = 0;
            while (run2)
            {
                Console.WriteLine("Type another number, and then press Enter");
                string input2 = Console.ReadLine();

                if (double.TryParse(input2, out num2))
                {
                    run2 = false;
                }
                else
                {
                    Console.WriteLine("Please enter a numerical value.");
                }
            }

            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");
            string operation = Console.ReadLine().Trim().ToLower();
            numberOfTimesUsed++;

            try
            {
                result = Calculator.DoOperation(num1, num2, operation);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else
                {
                    Console.WriteLine("Your result: {0}", result);
                    listOfAllCalculations.Add(result);
                    Console.WriteLine($"Your result has been added to your recent calculations list.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception error occurred trying to do the math.\n - Details " + e.Message);
            }

            Console.WriteLine($"The calculator has been used {numberOfTimesUsed} number of times");

            // Ask if the user wants to continue or exit the app
            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            string exitInput = Console.ReadLine().Trim().ToLower();
            if (exitInput == "n")
            {
                endApp = true;
            }
            Console.WriteLine("\n");

            // Check if there are any previous calculations to show
            if (listOfAllCalculations.Count > 0)
            {
                Console.WriteLine("Would you like to view your previous calculation totals? Press 'y' then Enter to proceed, if not then press any key to continue to use the calculator.");
                string viewPreviousTotals = Console.ReadLine().Trim().ToLower();

                if (viewPreviousTotals == "y")
                {
                    Console.WriteLine("Here are your previous calculations:");
                    double[] arrayOfAllCalculations = listOfAllCalculations.ToArray();
                    int placeInList;

                    for (int i = 0; i < arrayOfAllCalculations.Length; i++)
                    {
                        placeInList = i + 1;
                        Console.WriteLine($"{placeInList}. {arrayOfAllCalculations[i]}");
                    }

                    Console.WriteLine("\nWould you like to use a specific calculation total in your new calculation? Press 'o' for yes, 'p' for no.");
                    string decisionsAboutList = Console.ReadLine().Trim().ToLower();
                    if (decisionsAboutList == "o")
                    {
             
                        Console.WriteLine("Enter the index of the calculation total you want to use:");
                        string selectedIndex = Console.ReadLine();
                        if (int.TryParse(selectedIndex, out int index) && index > 0 && index <= arrayOfAllCalculations.Length)
                        {
                            num1 = arrayOfAllCalculations[index - 1];
                            Console.WriteLine($"Number 1 updated to the selected total: {num1}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid index of the calculation total.");
                        }
                    }
                    else if (decisionsAboutList == "p")
                    {
                        num1 = 0;
                        Console.WriteLine("\nWould you like to delete your previous calculations? Press 'y' to delete, Press 'n' to go back to the calculator.");
                        decisionsAboutList = Console.ReadLine().Trim().ToLower();

                        if (decisionsAboutList == "y")
                        {
                            listOfAllCalculations.Clear();
                            Console.WriteLine("You have deleted your previous calculations.");
                        }
                    }
                }
            }
        }
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

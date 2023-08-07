// Declare variables and then initialize to zero.
double num1 = 0;
double num2 = 0;

// Display title as the C# console calculator app.
Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");

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
    } else
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

// Use a switch statement to do the math.
switch (Console.ReadLine())
{
    case "a":
        Console.WriteLine($"Your result: {num1} + {num2} = {num1 + num2}");
        break;
    case "s":
        Console.WriteLine($"Your result: {num1} - {num2} = {num1 - num2}");
        break;
    case "m":
        Console.WriteLine($"Your result: {num1} * {num2} = {num1 * num2}");
        break;
    case "d":
        // Ask the user to enter a non-zero divisor until they do so.
        while (num2 == 0)
        {
            Console.WriteLine("Enter a non-zero divisor: ");
            num2 = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine($"Your result: {num1} / {num2} = {num1 / num2}");
        break;
    default:
        Console.WriteLine("Invalid Input");
        break;
}

// Wait for the user to respond.
Console.WriteLine("Press any key to close the Calculator console app...");
Console.ReadKey();

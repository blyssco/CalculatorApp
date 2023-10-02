using CalculatorLibrary;


class Program
{
    static void Main(string[] args)
    {
        int usageCount = 0;
        bool endApp = false;
        List<string> Calculations = new List<string>();

        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {

            string numInput1 = "";
            string numInput2 = "";
            double result = 0;


            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine();
            }


            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput2 = Console.ReadLine();
            }


            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tp - Power");
            Console.Write("Your option? ");

            string op = Console.ReadLine();

            try
            {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Your result: {0:0.##}\n", result);



                string CalculationToAdd = $"{cleanNum1} {op} {cleanNum2} = {result} ";
                Calculations.Add(CalculationToAdd);
                usageCount++;
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            Console.Write("Press 'n' and Enter to close the app,'L' to close and delete the history or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n")
            {
                foreach (string calculation in Calculations)
                {
                    Console.WriteLine(calculation);
                }
                Console.WriteLine($"You have used this calculator {usageCount} times, Bye bye");
                endApp = true;
            } else if (Console.ReadLine() == "l") 
            {
                Calculations.Clear();
                Console.WriteLine("Calculation history cleared.\n");
            }
            Console.WriteLine("\n"); 
        }
        return;
    }
}
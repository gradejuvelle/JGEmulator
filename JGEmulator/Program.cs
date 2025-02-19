using JGEmulator;

public class Program
{
    public static void Main(string[] args)
    {
        Computer myComputer = new Computer(1000); // Initial clock speed is irrelevant as it will be set by user input

        // User input loop
        while (true)
        {
            Console.WriteLine("Enter command (s: stop, r: run, t: step, x: reset, q: quit): ");
            var input = Console.ReadKey(true); // Read single key without displaying it
            switch (input.Key)
            {
                case ConsoleKey.S:
                    myComputer.ClockInstance.Stop();
                    Console.WriteLine("\nClock stopped.");
                    break;
                case ConsoleKey.R:
                    Console.WriteLine("\nEnter speed (ms) between 100 and 10000: ");
                    if (int.TryParse(Console.ReadLine(), out int newSpeed) && newSpeed >= 100 && newSpeed <= 10000)
                    {
                        myComputer.ClockInstance.SetSpeed(newSpeed);
                        myComputer.ClockInstance.Start();
//                        Console.WriteLine($"Clock running at {newSpeed} ms.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid speed input.");
                    }
                    break;
                case ConsoleKey.T:
                    myComputer.ClockInstance.Step();
                    break;
                case ConsoleKey.X:
                    myComputer.Reset();
                    Console.WriteLine("Computer Reset Started.");
                    break;
                case ConsoleKey.Q:
                    Console.WriteLine("\nExiting program.");
                    return; // Exit the program
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}

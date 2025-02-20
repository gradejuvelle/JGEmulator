using JGEmulator;

public class Program
{
    public static void Main(string[] args)
    {
        Computer myComputer = new Computer(1000); // Initial clock speed is irrelevant as it will be set by user input

        // User input loop
        while (true)
        {
            myComputer.DisplayMessage("Enter command (s: stop, r: run, t: step, x: reset, q: quit): ");
            var input = Console.ReadKey(true); // Read single key without displaying it
            switch (input.Key)
            {
                case ConsoleKey.S:
                    myComputer.ClockInstance.Stop();
                    myComputer.DisplayMessage("\nClock stopped.");
                    break;
                case ConsoleKey.R:
                    myComputer.DisplayMessage("\nEnter speed (ms) between 100 and 10000: ");
                    if (int.TryParse(Console.ReadLine(), out int newSpeed) && newSpeed >= 100 && newSpeed <= 10000)
                    {
                        myComputer.ClockInstance.SetSpeed(newSpeed);
                        myComputer.ClockInstance.Start();
//                        DisplayMessage($"Clock running at {newSpeed} ms.");
                    }
                    else
                    {
                        myComputer.DisplayMessage("Invalid speed input.");
                    }
                    break;
                case ConsoleKey.T:
                    myComputer.ClockInstance.Step();
                    break;
                case ConsoleKey.X:
                    myComputer.Reset();
                    break;
                case ConsoleKey.Q:
                    myComputer.DisplayMessage("\nExiting program.");
                    return; // Exit the program
                default:
                    myComputer.DisplayMessage("Unknown command.");
                    break;
            }
        }
    }
}

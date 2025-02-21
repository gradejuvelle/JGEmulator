using JGEmulator;

public class Program
{

    public static void Main(string[] args)
    {
        Computer myComputer = new Computer(1000); // Initial clock speed is irrelevant as it will be set by user input

        // User input loop
        while (true)
        {
            myComputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Enter command (s: stop, r: run, t: step, x: reset, q: quit): ", "USER"));
            var input = Console.ReadKey(true); // Read single key without displaying it
            switch (input.Key)
            {
                case ConsoleKey.S:
                    myComputer.Stop();
                    myComputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Clock stopped.", "USER"));
                    break;
                case ConsoleKey.R:
                    myComputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Enter speed (ms) between 100 and 10000: ", "USER"));
                    if (int.TryParse(Console.ReadLine(), out int newSpeed) && newSpeed >= 100 && newSpeed <= 10000)
                    {
                        myComputer.SetSpeed(newSpeed);
                        myComputer.Start();
                        myComputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Clock running at {newSpeed} ms.", "USER"));
                    }
                    else
                    {
                        myComputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Invalid speed input.", "USER"));
                    }
                    break;
                case ConsoleKey.T:
                    myComputer.Step();
                    break;
                case ConsoleKey.X:
                    myComputer.Reset();
                    break;
                case ConsoleKey.Q:
                    myComputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Exiting program.", "USER"));
                    return; // Exit the program
                default:
                    myComputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Unknown command.", "USER"));
                    break;
            }
        }
        
    }
}







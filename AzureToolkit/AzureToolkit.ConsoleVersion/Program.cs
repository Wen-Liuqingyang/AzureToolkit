using AzureToolkit.ConsoleVersion.Output;

namespace AzureToolkit.ConsoleVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Print.ShowHelp();
            }
            else
            {
                // Handle other commands
                switch (args[0].ToLower())
                {
                    case "help" or "--help" or "-h":
                        Print.ShowHelp();
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {args[0]}");
                        break;
                }
            }
        }
    }
}

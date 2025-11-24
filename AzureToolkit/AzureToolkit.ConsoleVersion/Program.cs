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
            }
        }
    }
}

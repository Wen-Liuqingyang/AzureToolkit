using AzureToolkit.ConsoleVersion.Output;

internal class Program
{
    private static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Print.ShowHelp();
            return 0;
        }
        else
        {
            try
            {
                //解析命令行参数
                string cmd = args[0].ToLower();

                return cmd switch
                {
                    "help" or "-h" or "--help" => Print.ShowHelp(),
                    _ => Print.ShowHelp(),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}
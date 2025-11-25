using AzureToolkit.Command.Get;

internal class Program
{
    private static int Main(string[] args)
    {
        GetHelp getHelp = new GetHelp();

        //没有参数时显示帮助信息
        if (args.Length == 0)
        {
            getHelp.PrintHelpMessage();
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
                    "get-help" => getHelp.Execute(args),
                    _ => getHelp.PrintHelpMessage(),
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
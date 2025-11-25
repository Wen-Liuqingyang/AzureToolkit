using AzureToolkit.Command.Get;
using AzureToolkit.Command.Math;

internal class Program
{
    private static int Main(string[] args)
    {
        //没有参数时显示帮助信息
        if (args.Length == 0)
        {
            GetHelp.PrintHelpMessage();
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
                    //命令在这里添加
                    "get-help" => GetHelp.Execute(args),
                    "math-add" => Add.Execute(args),
                    _ => GetHelp.PrintHelpMessage(),
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
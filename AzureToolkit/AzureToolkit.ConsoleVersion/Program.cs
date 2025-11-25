using AzureToolkit.Command.Get;
using AzureToolkit.Command.Math;
using AzureToolkit.Share;
internal class Program
{
    private static int Main(string[] args)
    {
        //获取版本号
        static int ShowVersion(string ver)
        {
            Output.WriteLineWithColor($"Azure Toolkit 版本: {ver}\n", ConsoleColor.Green);
            return 0;
        }

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
                    "get-version" => ShowVersion("0.1.0"),
                    "math-add" => MathAdd.Execute(args),
                    "math-solve-equaltion" => MathSolveEqualtion.Execute(args),
                    _ => GetHelp.ShowCommandNotFound(args[0]),
                };
            }
            catch (Exception ex)
            {
                Output.WriteLineWithColor($"Error: {ex.Message}", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~", ConsoleColor.Red);
                return 1;
            }
        }
    }
}
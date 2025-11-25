using AzureToolkit.Command.Math;
using AzureToolkit.Interface;
using AzureToolkit.Share;

namespace AzureToolkit.Command.Get
{
    public class GetHelp : ICommand
    {
        public static int PrintHelpMessage()
        {
            Console.WriteLine("用法:");
            Console.WriteLine($"get-help <command>\n");
            Output.WriteLineWithColor("Azure Toolkit 所有命令:", ConsoleColor.Green);
            Output.WriteLineWithColor("  命令          类别           描述", ConsoleColor.Green);
            Output.WriteLineWithColor("  --------------------------------------------------------", ConsoleColor.Green);
            Output.WriteLineWithColor("  \n--G--", ConsoleColor.Green);
            Output.WriteLineWithColor("  get-help      Get           获取命令帮助信息", ConsoleColor.White);
            Output.WriteLineWithColor("  get-version   Get           获取本程序版本信息", ConsoleColor.White);
            Output.WriteLineWithColor("  \n--M--", ConsoleColor.Green);
            Output.WriteLineWithColor("  math-add      Math          执行加法运算", ConsoleColor.White);
            return 0;
        }

        public static int Execute(string[] args)
        {
            string arg = string.Empty;

            // 检查参数数量
            if (args.Length > 2)
            {
                Output.WriteLineWithColor("参数过多，请检查输入。", ConsoleColor.Red);
                Output.WriteLineWithColor("未知参数: " + string.Join(" ", args[2..]), ConsoleColor.Red);
                return 1;
            }



            // 获取命令名称参数
            string commandName = args.Length == 2 ? args[1].ToLower() : string.Empty;

            return commandName switch
            {
                "get-help" => PrintHelpMessage(),
                "math-add" => Add.PrintHelpMessage(),
                "" => PrintHelpMessage(), // 没有指定具体命令时显示通用帮助
                _ => ShowCommandNotFound(commandName)
            };

        }

        private static int ShowCommandNotFound(string commandName)
        {
            Output.WriteLineWithColor($"错误：未找到命令 '{commandName}' 的帮助信息", ConsoleColor.Red);
            Output.WriteLineWithColor("使用 'get-help' 查看可用命令列表", ConsoleColor.Red);
            return 1;
        }
    }
}
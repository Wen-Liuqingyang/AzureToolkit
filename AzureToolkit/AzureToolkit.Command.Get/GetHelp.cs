using AzureToolkit.Command.Math;
using AzureToolkit.Interface;

namespace AzureToolkit.Command.Get
{
    public class GetHelp : ICommand
    {
        public static int PrintHelpMessage()
        {
            Console.WriteLine("用法:");
            Console.WriteLine($"get-help <command>\n");
            Console.WriteLine("Azure Toolkit 所有命令:");
            Console.WriteLine("  get-help          获取命令帮助信息");
            Console.WriteLine("  math-add          执行加法运算");
            return 0;
        }

        public static int Execute(string[] args)
        {
            string arg = string.Empty;

            // 检查参数数量
            if (args.Length > 2)
            {
                Console.WriteLine("参数过多，请检查输入。");
                Console.WriteLine("未知参数: " + string.Join(" ", args[2..]));
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
            Console.WriteLine($"错误：未找到命令 '{commandName}' 的帮助信息");
            Console.WriteLine("使用 'get-help' 查看可用命令列表");
            return 1;
        }
    }
}
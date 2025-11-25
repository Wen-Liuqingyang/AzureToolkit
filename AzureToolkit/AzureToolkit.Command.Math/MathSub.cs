using AzureToolkit.Interface;
using AzureToolkit.Share;

namespace AzureToolkit.Command.Math
{
    public class MathSub : ICommand
    {
        public static int Execute(string[] args)
        {
            if (TryParseArguments(args, out double num1, out double num2))
            {
                Console.WriteLine($"计算的结果是: {num1 - num2}");
            }
            return 0;
        }

        public static int PrintHelpMessage()
        {
            Console.WriteLine("\n描述:");
            Console.WriteLine("减法运算命令\n");
            Console.WriteLine("用法: math-sub [num1]<double> [num2]<double>");
            Console.WriteLine("参数:");
            Console.WriteLine("  [num1]<double>   第一个减数");
            Console.WriteLine("  [num2]<double>   第二个减数\n");
            return 0;
        }

        /// <summary>
        /// 检查math-sub的参数
        /// </summary>
        /// <param name="args">用户输入的东东</param>
        /// <param name="num1">第一个减数</param>
        /// <param name="num2">第二个减数</param>
        /// <returns></returns>
        private static bool TryParseArguments(string[] args, out double num1, out double num2)
        {
            num1 = 0;
            num2 = 0;

            if (args.Length != 3)
            {
                Output.WriteLineWithColor("错误：参数数量不正确。", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~杂鱼~连数数都不会~\n看看下面的用法吧:\n", ConsoleColor.Red);
                PrintHelpMessage();
                return false;
            }
            if (!double.TryParse(args[1], out num1))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[1]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (!double.TryParse(args[2], out num2))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[2]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            return true;
        }
    }
}

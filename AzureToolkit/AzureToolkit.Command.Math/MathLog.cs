using AzureToolkit.Interface;
using AzureToolkit.Share;

namespace AzureToolkit.Command.Math
{
    public class MathLog : ICommand
    {
        public static int PrintHelpMessage()
        {
            Console.WriteLine("对数运算命令\n");
            Console.WriteLine("用法: math-log [option] {[base]}<double> [natural]<double>");
            Console.WriteLine("选项:");
            Console.WriteLine("    --base    指定对数的底数");
            Console.WriteLine("    --base-e  指定对数的底数为e");
            Console.WriteLine("参数:");
            Console.WriteLine("    [base]       对数的底数（使用 --base-e时应省略）");
            Console.WriteLine("    [natural]    对数的真数\n");
            return 0;
        }

        public static int Execute(string[] args)
        {
            if (args.Length == 1)
            {
                Output.WriteLineWithColor("错误：缺少必要的选项与参数。", ConsoleColor.Red);
                Output.WriteLineWithColor("看看下面的用法吧:\n", ConsoleColor.Red);
                PrintHelpMessage();
                return 1;
            }
            if (args[1] == "--base")
            {
                if (TryParseArguments(args, out double num1, out double num2))
                {
                    Console.WriteLine($"计算的结果是: {System.Math.Log(num2, num1)}");
                }
            }
            else if (args[1] == "--base-e")
            {
                if (args.Length == 3 && args[2] == "e")
                {
                    Console.WriteLine($"计算的结果是: 1");
                }
                else if (TryParseArguments(args, out double num1))
                {
                    Console.WriteLine($"计算的结果是: {System.Math.Log(num1)}");
                }
            }
            else
            {
                Output.WriteLineWithColor("错误：缺少必要的选项。", ConsoleColor.Red);
                Output.WriteLineWithColor("看看下面的用法吧:\n", ConsoleColor.Red);
                PrintHelpMessage();
            }
            return 0;
        }

        /// <summary>
        /// 检查math-log在使用--base选项时的参数
        /// </summary>
        /// <param name="args">用户输入的东东</param>
        /// <param name="num1">底数</param>
        /// <param name="num2">真数</param>
        /// <returns></returns>
        private static bool TryParseArguments(string[] args, out double num1, out double num2)
        {
            num1 = 0;
            num2 = 0;

            if (args.Length != 4)
            {
                Output.WriteLineWithColor("错误：参数数量不正确。", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~杂鱼~连数数都不会~\n看看下面的用法吧:\n", ConsoleColor.Red);
                PrintHelpMessage();
                return false;
            }

            if (!double.TryParse(args[2], out num1))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[1]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (!double.TryParse(args[3], out num2))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[2]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (num1 <= 0 || num1 == 1)
            {
                Output.WriteLineWithColor("错误：对数的底数必须大于0且不等于1。", ConsoleColor.Red);
                Output.WriteLineWithColor("连对数定义都不知道，果然是杂鱼呢~", ConsoleColor.Red);
                return false;
            }
            if (num2 <= 0)
            {
                Output.WriteLineWithColor("错误：对数的真数必须大于0。", ConsoleColor.Red);
                Output.WriteLineWithColor("连对数定义都不知道，果然是杂鱼呢~", ConsoleColor.Red);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查math-log在使用--base-e选项时的参数
        /// </summary>
        /// <param name="args">用户输入的东东</param>
        /// <param name="num1">真数</param>
        /// <returns></returns>
        private static bool TryParseArguments(string[] args, out double num1)
        {
            num1 = 0;

            if (args.Length != 3)
            {
                Output.WriteLineWithColor("错误：参数数量不正确。", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~杂鱼~连数数都不会~\n看看下面的用法吧:\n", ConsoleColor.Red);
                PrintHelpMessage();
                return false;
            }

            if (!double.TryParse(args[2], out num1))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[2]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }

            if (num1 <= 0)
            {
                Output.WriteLineWithColor("错误：对数的真数数必须大于0。", ConsoleColor.Red);
                Output.WriteLineWithColor("连对数定义都不知道，果然是杂鱼呢~", ConsoleColor.Red);
                return false;
            }

            return true;
        }
    }
}

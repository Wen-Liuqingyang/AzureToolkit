using AzureToolkit.Interface;
using AzureToolkit.Share;

namespace AzureToolkit.Command.Math
{
    public class MathSolveEqualtion : ICommand
    {
        public static int Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Output.WriteLineWithColor("错误：缺少选项。", ConsoleColor.Red);
                Output.WriteLineWithColor("zako~\n", ConsoleColor.Red);
                return 1;
            }

            string option = args.Length > 0 ? args[1].ToLower() : string.Empty;

            if (option == "--degree-1")
            {
                if (TryParseArguments(args, out double k, out double b))
                {
                    double solution = -b / k;
                    Output.WriteLineWithColor($"方程的根为: x = {solution}", ConsoleColor.White);
                }
                return 0;
            }
            else if (option == "--degree-2")
            {
                if (TryParseArguments(args, out double a, out double b, out double c))
                {
                    double delta = Delta(a, b, c);
                    if (delta < 0)
                    {
                        Output.WriteLineWithColor("方程无实数根。", ConsoleColor.White);
                    }
                    else if (delta == 0)
                    {
                        double solution = -b / (2 * a);
                        Output.WriteLineWithColor($"方程有两个相等的实数根: x = {solution}", ConsoleColor.White);
                    }
                    else
                    {
                        double root1 = (-b + System.Math.Sqrt(delta)) / (2 * a);
                        double root2 = (-b - System.Math.Sqrt(delta)) / (2 * a);
                        Output.WriteLineWithColor($"方程有两个不同的实数根: x1 = {root1}, x2 = {root2}", ConsoleColor.White);
                    }
                }
                return 0;
            }
            else
            {
                Output.WriteLineWithColor("错误：未知的选项。", ConsoleColor.Red);
                return 1;
            }
        }

        /// <summary>
        /// 检查一次方程系数部分
        /// </summary>
        /// <param name="args">用户输入的东东</param>
        /// <param name="k">第一个系数</param>
        /// <param name="b">第二个系数</param>
        /// <returns></returns>
        private static bool TryParseArguments(string[] args, out double k, out double b)
        {
            k = 0;
            b = 0;

            if (args.Length != 4)
            {
                Output.WriteLineWithColor("错误：参数数量不正确。", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~杂鱼~连数数都不会~\n看看下面的用法吧:\n", ConsoleColor.Red);
                PrintHelpMessage();
                return false;
            }
            if (!double.TryParse(args[2], out k))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[1]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (!double.TryParse(args[3], out b))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[2]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (k == 0)
            {
                Output.WriteLineWithColor("错误：方程的最高次系数不能为零。", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~杂鱼~连一次函数一次项系数不能为零都不知道，杂鱼！重修初中数学吧~", ConsoleColor.Red);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 检查二次方程系数部分
        /// </summary>
        /// <param name="args">用户输入的东东</param>
        /// <param name="k">第一个系数</param>
        /// <param name="b">第二个系数</param>
        /// <param name="c">常数</param>
        /// <returns></returns>
        private static bool TryParseArguments(string[] args, out double a, out double b, out double c)
        {
            a = 0;
            b = 0;
            c = 0;

            if (args.Length != 5)
            {
                Output.WriteLineWithColor("错误：参数数量不正确。", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~杂鱼~连数数都不会~\n看看下面的用法吧:\n", ConsoleColor.Red);
                PrintHelpMessage();
                return false;
            }
            if (!double.TryParse(args[2], out a))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[2]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (!double.TryParse(args[3], out b))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[3]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (!double.TryParse(args[4], out c))
            {
                Output.WriteLineWithColor($"错误：无法将 '{args[4]}' 解析为数字。", ConsoleColor.Red);
                Output.WriteLineWithColor("再好好看看啊喂！", ConsoleColor.Red);
                return false;
            }
            if (a == 0)
            {
                Output.WriteLineWithColor("错误：方程的最高次系数不能为零。", ConsoleColor.Red);
                Output.WriteLineWithColor("杂鱼~杂鱼~连二次函数二次项系数不能为零都不知道，杂鱼！重修初中数学吧~", ConsoleColor.Red);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 二次方程判别式
        /// </summary>
        /// <param name="a">二次项系数</param>
        /// <param name="b">一次项系数</param>
        /// <param name="c">常数项</param>
        /// <returns></returns>
        private static double Delta(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        public static int PrintHelpMessage()
        {
            Console.WriteLine("\n描述:");
            Console.WriteLine("求解给定的数学方程。(目前只支持一次、二次方程)");
            Console.WriteLine("用法:");
            Console.WriteLine("math-solve-equaltion [option] [arg1]<double> [arg2]<double> ...\n");
            Console.WriteLine("选项:");
            Console.WriteLine("  --degree-1         指定方程的最高次数为1次");
            Console.WriteLine("  --degree-2         指定方程的最高次数为2次\n");
            Console.WriteLine("参数:");
            Console.WriteLine("  [arg]<double>   方程的系数与常数\n");
            Output.WriteLineWithColor("注意:", ConsoleColor.Green);
            Output.WriteLineWithColor("系数是方程化为一般式后的数字", ConsoleColor.Green);
            Output.WriteLineWithColor("例如: 方程 2x^2 + 3x + 1 = 0 的系数和常数为 2, 3, 1", ConsoleColor.Green);
            Output.WriteLineWithColor("例如: 方程 2x^2 + 3x + 1 = 1 的系数和常数为 2, 3, 0", ConsoleColor.Green);
            Output.WriteLineWithColor("请确保按照从高次到低次的顺序输入系数", ConsoleColor.Green);

            return 0;
        }
    }
}

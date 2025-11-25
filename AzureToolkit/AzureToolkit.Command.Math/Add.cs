using AzureToolkit.Interface;

namespace AzureToolkit.Command.Math
{
    public class Add : ICommand
    {
        public static int PrintHelpMessage()
        {
            Console.WriteLine("加法运算命令\n");
            Console.WriteLine("用法: math-add <num1> <num2>");
            return 0;
        }

        public static int Execute(string[] args)
        {
            // 检查参数数量

            TryParseArguments(args, out double num1, out double num2);

            return 0;
        }

        /// <summary>
        /// 检查math-add的参数
        /// </summary>
        /// <param name="args">用户输入的东东</param>
        /// <param name="num1">第一个加数</param>
        /// <param name="num2">第二个加数</param>
        /// <returns></returns>
        private static bool TryParseArguments(string[] args, out double num1, out double num2)
        {
            num1 = 0;
            num2 = 0;

            if (args.Length != 3)
            {
                Console.WriteLine("错误：参数数量不正确。");
                Console.WriteLine("杂鱼~杂鱼~连数数都不会~\n看看下面的用法吧:\n");
                PrintHelpMessage();
                return false;
            }
            if (!double.TryParse(args[1], out num1))
            {
                Console.WriteLine($"错误：无法将 '{args[1]}' 解析为数字。");
                Console.WriteLine("再好好看看啊喂！");
                return false;
            }
            if (!double.TryParse(args[2], out num2))
            {
                Console.WriteLine($"错误：无法将 '{args[2]}' 解析为数字。");
                Console.WriteLine("再好好看看啊喂！");
                return false;
            }
            return true;
        }
    }
}

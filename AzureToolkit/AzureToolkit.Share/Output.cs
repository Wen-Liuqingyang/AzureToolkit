namespace AzureToolkit.Share
{
    public class Output
    {
        /// <summary>
        /// 使用指定颜色输出信息，并在输出后重置颜色，使用Console.Write实现
        /// </summary>
        /// <param name="message">要输出的信息</param>
        /// <param name="color">输出颜色</param>
        public static void WriteWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{message}");
            Console.ResetColor(); // 每次使用后及时重置颜色
        }

        /// <summary>
        /// 使用指定颜色输出信息，并在输出后重置颜色，使用Console.WriteLine实现
        /// </summary>
        /// <param name="message">要输出的信息</param>
        /// <param name="color">输出颜色</param>
        public static void WriteLineWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{message}");
            Console.ResetColor(); // 每次使用后及时重置颜色
        }
    }
}

namespace AzureToolkit.ConsoleVersion.Output
{
    /// <summary>
    /// 用于程序所涉及的输出文本，以Console.WriteLine的形式进行输出
    /// </summary>
    public class Print
    {
        /// <summary>
        /// 输出帮助信息
        /// </summary>
        public static void ShowHelp()
        {
            Console.WriteLine("Usage: atk command [options]");

            Console.WriteLine("Command:");
            Console.WriteLine("    get-help, --help, -h      Get help information");
            Console.WriteLine("    get-resources             List all Azure resources");
        }
    }
}

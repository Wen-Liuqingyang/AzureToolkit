namespace AzureToolkit.ConsoleVersion.Output
{
    /// <summary>
    ///用于在控制台输出信息的类
    /// </summary>
    public class Print
    {
        /// <summary>
        /// 输出帮助信息到控制台
        /// </summary>
        public static int ShowHelp()
        {
            Console.WriteLine("Usage: atk command [options]");

            Console.WriteLine("Command:");
            Console.WriteLine("    get-help, --help, -h      Get help information");
            Console.WriteLine("    get-resources             List all Azure resources");
            return 0;
        }
    }
}

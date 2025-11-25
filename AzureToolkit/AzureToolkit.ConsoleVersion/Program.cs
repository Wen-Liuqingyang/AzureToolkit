

internal class Program
{
    private static int Main(string[] args)
    {
        //没有参数时显示帮助信息
        if (args.Length == 0)
        {

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
                    "help" or "-h" or "--help" => GetHelp.ShowHelp(),
                    _ => GetHelp.ShowHelp(),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}
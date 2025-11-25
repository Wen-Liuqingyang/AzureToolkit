using AzureToolkit.Interface;

namespace AzureToolkit.Command.Math
{
    public class Add : ICommand
    {
        public string Name => "math-add";

        public string Description => "执行加法运算";

        public int PrintHelpMessage()
        {
            Console.WriteLine("用法: math-add <num1> <num2>");
            return 0;
        }

        public int Execute(string[] args)
        {
            return 0;
        }
    }
}

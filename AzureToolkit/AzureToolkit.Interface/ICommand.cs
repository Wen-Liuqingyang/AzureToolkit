namespace AzureToolkit.Interface
{
    public interface ICommand
    {
        /// <summary>
        /// 命令具体实现
        /// </summary>
        abstract static int Execute(string[] args);

        /// <summary>
        /// 获取命令帮助信息
        /// </summary>
        /// <returns></returns>
        abstract static int PrintHelpMessage();
    }
}

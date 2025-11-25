namespace AzureToolkit.Interface
{
    public interface ICommand
    {
        /// <summary>
        /// 命令名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 命令描述
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 命令具体实现
        /// </summary>
        int Execute(string[] args);

        /// <summary>
        /// 获取命令帮助信息
        /// </summary>
        /// <returns></returns>
        int PrintHelpMessage();
    }
}

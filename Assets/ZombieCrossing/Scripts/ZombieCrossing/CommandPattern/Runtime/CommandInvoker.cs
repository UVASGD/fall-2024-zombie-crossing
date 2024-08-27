namespace ZombieCrossing.CommandPattern.Runtime
{
    /// <summary>
    /// Used to invoke all commands. 
    /// </summary>
    /// <remarks>
    /// Right now this doesn't do anything special, but is useful for processing all game commands.
    /// </remarks>
    public static class CommandInvoker
    {
        /// <summary>
        /// Executes the command. 
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public static void Execute(ICommand command)
        {
            command.Execute();
        }
    }
}
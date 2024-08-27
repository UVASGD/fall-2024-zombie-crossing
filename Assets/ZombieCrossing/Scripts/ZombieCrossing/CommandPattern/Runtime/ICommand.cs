namespace ZombieCrossing.CommandPattern.Runtime
{
    /// <summary>
    /// A single arbitrary command. 
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command. 
        /// </summary>
        public void Execute(); 
    }
}
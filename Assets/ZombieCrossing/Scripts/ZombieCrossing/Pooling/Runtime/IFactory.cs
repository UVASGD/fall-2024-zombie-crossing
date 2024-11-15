namespace ZombieCrossing.Pooling.Runtime
{
    /// <summary>
    /// Creates a single item.
    /// </summary>
    /// <typeparam name="T">The type of item created.</typeparam>
    /// <seealso cref="PoolBase{T,T,T}"/>
    public interface IFactory<out T> 
    {
        /// <summary>
        /// Creates and Initializes an item.
        /// </summary>
        public T CreateInstance();
    }
}
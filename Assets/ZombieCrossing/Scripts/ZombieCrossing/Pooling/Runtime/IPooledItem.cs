namespace ZombieCrossing.Pooling.Runtime
{
    /// <summary>
    /// The behavior of a single pooled item.
    /// </summary>
    /// <typeparam name="TArgs">The arguments used to allocate this item.</typeparam>
    /// <seealso cref="IFactory{T,T}"/>
    public interface IPooledItem<in TArgs>
    {
        /// <summary>
        /// Callback on retrieving this item from a pool.
        /// </summary>
        public void OnAllocate(TArgs args);
        
        /// <summary>
        /// Callback on releasing this item back to a pool.
        /// </summary>
        public void OnFree();

        /// <summary>
        /// Callback when the item was not able to be returned to the pool.
        /// </summary>
        public void OnFreeFailed();
    }
}
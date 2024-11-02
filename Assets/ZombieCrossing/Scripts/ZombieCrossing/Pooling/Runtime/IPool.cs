namespace ZombieCrossing.Pooling.Runtime
{
    /// <summary>
    /// Represents a collection that pools objects of T.
    /// </summary>
    /// <typeparam name="TArgs">The arguments used to allocate an instance of <see cref="T"/>.</typeparam>
    /// <typeparam name="T">Specifies the type of elements in the pool.</typeparam>
    public interface IPool<in TArgs, T>
    {
        /// <summary>
        /// Initializes the pool. 
        /// </summary>
        void Prewarm();

        /// <summary>
        /// Requests an member of <see cref="T"/> in the pool. 
        /// </summary>
        /// <returns><see cref="T"/> The member.</returns>
        T Allocate(TArgs args);

        /// <summary>
        /// Returns an element to the pool. 
        /// </summary>
        /// <param name="member">The member to return.</param>
        void Free(T member);
    }
}
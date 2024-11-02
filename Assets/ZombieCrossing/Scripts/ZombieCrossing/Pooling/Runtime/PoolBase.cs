using System.Collections.Generic;
using UnityEngine;

namespace ZombieCrossing.Pooling.Runtime
{
    /// <summary>
    /// A pool.
    /// </summary>
    /// <typeparam name="TFactory">The <see cref="IFactory{T}"/> that makes the item.</typeparam>
    /// <typeparam name="TArgs">The arguments used to allocate an instance of <see cref="T"/>.</typeparam>
    /// <typeparam name="T">The type of item this pool provides</typeparam>
    public abstract class PoolBase<TFactory, TArgs, T> : MonoBehaviour, IPool<TArgs, T> 
        // fixes "target runtime doesn't support covariant return types in overrides" error
        // and allows the factor to be serialized in base classes 
        where TFactory: IFactory<T> 
        where T: IPooledItem<TArgs>
    {
        /// <summary>
        /// The available members. 
        /// </summary>
        private LinkedList<T> availableMembers;
        
        /// <summary>
        /// The <see cref="IFactory{T}"/>. 
        /// </summary>
        protected abstract TFactory Factory { get; set; }
        
        /// <summary>
        /// Whether or not <see cref="Prewarm"/> has run. 
        /// </summary>
        public bool IsPrewarmed { get; private set; }
        
        /// <summary>
        /// The size beyond which the pool may not grow.
        /// </summary>
        [field: SerializeField]
        public int InitialPoolSize { get; private set; }
        
        /// <summary>
        /// The size beyond which the pool may not grow.
        /// </summary>
        [field: SerializeField]
        public int MaxPoolSize { get; private set; }

        /// <summary>
        /// Whether or not the pool has reached the <see cref="MaxPoolSize"/> and all its member are in use.
        /// </summary>
        public bool IsCompletelyInUse => availableMembers.Count == MaxPoolSize && inUseMemberPointer == 0;

        /// <summary>
        /// Creates an instance of <see cref="T"/>
        /// </summary>
        /// <returns><see cref="T"/> The instance.</returns>
        protected virtual T CreateInstance() 
        {
            return Factory.CreateInstance();
        } 

        /// <summary>
        /// Index of the leftmost item that has been allocated. 
        /// </summary>
        /// <remarks>
        /// Every item to the right of this can be allocated. 
        /// </remarks>
        private int inUseMemberPointer; 

        /// <summary>
        /// Initializes the pool. 
        /// </summary>
        /// <remarks>
        /// Pre-warming can only happen once for the lifetime of the object.
        /// </remarks>
        /// <typeparam name="TArgs">.</typeparam>
        public virtual void Prewarm()
        {
            MaxPoolSize = Mathf.Max(0, MaxPoolSize);
            InitialPoolSize = Mathf.Min(InitialPoolSize, MaxPoolSize);
            availableMembers = new LinkedList<T>();

            inUseMemberPointer = InitialPoolSize;
            
            if (IsPrewarmed)
            {
#if DEVELOPMENT_BUILD || UNITY_EDITOR || UNITY_ASSERTIONS
                Debug.LogWarning($"Pool {name} has already been prewarmed. Pre-warming can only happen once for the lifetime of the object.", this);
#endif
                return;
            }

            for (var i = 0; i < InitialPoolSize; i++)
            {
                availableMembers.AddLast(CreateInstance());
            }

            IsPrewarmed = true;
        }
        
        /// <summary>
        /// Requests a <see cref="T"/> member from the pool. 
        /// </summary>
        /// <typeparam name="TArgs">The arguments used to allocate the pooled item.</typeparam>
        /// <returns>
        /// A <see cref="T"/> member
        /// or default, if the <see cref="availableMembers"/> has grown beyond the <see cref="MaxPoolSize"/>.
        /// </returns>
        public virtual T Allocate(TArgs args)
        {
            if (IsCompletelyInUse) return default;

            T member;
            if (inUseMemberPointer > 0)
            {
                var firstNode = availableMembers.First;
                availableMembers.Remove(firstNode);
                member = firstNode.Value;
                inUseMemberPointer--;
            }
            else
            {
                member = CreateInstance();
            }
            
            availableMembers.AddLast(member);
            member.OnAllocate(args);
            
            return member;
        }
  
        /// <summary>
        /// Returns a <see cref="T"/> member to the pool. 
        /// </summary>
        /// <remarks>
        /// If the pool is at maximum capacity,
        /// the member will not be freed and <see cref="IPooledItem{T}.OnFreeFailed"/> will be called.
        /// </remarks>
        /// <param name="member">The member to return.</param>
        public virtual void Free(T member)
        {
            for(var node = availableMembers.First; node != null; node = node.Next)
            {
                if (!EqualityComparer<T>.Default.Equals(node.Value, member)) continue;
                
                availableMembers.Remove(node);
                availableMembers.AddFirst(node);
                inUseMemberPointer++;
                member.OnFree();
                
                return;
            }
            
            if (availableMembers.Count >= MaxPoolSize)
            {
                member.OnFreeFailed();
                return;
            }

            availableMembers.AddFirst(member);
            inUseMemberPointer++;
            member.OnFree();
        }

        // protected virtual void OnDisable()
        // {
        //     availableMembers.Clear();
        //     IsPrewarmed = false;
        // }
    }
}
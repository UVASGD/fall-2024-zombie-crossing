using System.Collections.Generic;
using UnityEngine;

namespace ZombieCrossing.Pooling.Runtime
{
    /// <summary>
    /// <inheritdoc cref="PoolBase{T,T,T}"/>.
    /// Contains the pooled item be children of a parent <see cref="Transform"/> and activates or
    /// deactivates then when in or out of use, respectively.
    /// </summary>
    public abstract class GameObjectPoolBase<TFactory, TArgs, T>: PoolBase<TFactory, TArgs, T> 
        where T : IPooledItem<TArgs>, IGameObjectProvider
        where TFactory: IFactory<T> 
    {
        /// <summary>
        /// The pool root. 
        /// </summary>
        [field: SerializeField]
        public Transform Parent { get; private set; }

        protected override T CreateInstance()
        {
            var member = base.CreateInstance();
            if (IsDefaultOrNullGameObject(member)) return member;
            member.gameObject.transform.SetParent(Parent);
            member.gameObject.SetActive(false);
            return member;
        }

        private static bool IsDefaultOrNullGameObject(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default) || value.gameObject == null;
        }

//         protected override void OnDisable()
//         {
//             base.OnDisable();
// #if UNITY_EDITOR
//             DestroyImmediate(parent.gameObject);
// #else 
//             Destroy(parent.gameObject);
// #endif
//         }
    }
}
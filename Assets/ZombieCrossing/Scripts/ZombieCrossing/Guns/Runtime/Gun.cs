using UnityEngine;
using ZombieCrossing.ParticleSystem.Runtime;

namespace ZombieCrossing.Guns.Runtime
{
    /// <summary>
    /// Describes a single gun. 
    /// </summary>
    [CreateAssetMenu(fileName = nameof(Gun), menuName = "ScriptableObjects/Guns/Gun")]
    public class Gun : ScriptableObject
    {
        /// <summary>
        /// The <see cref="GameObject"/> that represents the bullet source, meaning that, somewhere in its
        /// hierarchy, there should be a <see cref="ParticlePoolSystem"/> component. 
        /// </summary>
        [SerializeField] private GameObject bulletSourcePrefab;
        
        /// <summary>
        /// The origin of the <see cref="bulletSourcePrefab"/>. 
        /// </summary>
        [SerializeField] private Transform bulletSourceOrigin; 
    }
}
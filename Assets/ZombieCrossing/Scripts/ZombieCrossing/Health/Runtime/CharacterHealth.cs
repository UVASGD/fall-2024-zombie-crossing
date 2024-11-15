using UnityEngine;

namespace ZombieCrossing.Health.Runtime
{
    public class CharacterHealth: MonoBehaviour
    {
        public float Health { get; private set; }

        /// <summary>
        /// Takes damage 
        /// </summary>
        /// <param name="damage">The amount of damage to take</param>
        /// <param name="direction">The direction from which the damage was taken (e.g. to incur knockback).</param>
		public void TakeDamage(float damage, Vector3 direction)
		{
			// TODO - implement 
		}
    }
}
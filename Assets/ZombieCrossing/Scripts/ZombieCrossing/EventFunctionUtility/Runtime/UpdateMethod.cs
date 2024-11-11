namespace EventFunctionUtility.Runtime
{
    /// <summary>
    /// A <see cref="UnityEngine.MonoBehaviour"/> update method. 
    /// </summary>
    public enum UpdateMethod
    {
        /// <summary>
        /// <see cref="UnityEngine.MonoBehaviour"/> Update.
        /// </summary>
        Update, 
        
        /// <summary>
        /// <see cref="UnityEngine.MonoBehaviour"/> FixedUpdate.
        /// </summary>
        FixedUpdate, 
        
        /// <summary>
        /// <see cref="UnityEngine.MonoBehaviour"/> LateUpdate.
        /// </summary>
        LateUpdate, 
    }
}
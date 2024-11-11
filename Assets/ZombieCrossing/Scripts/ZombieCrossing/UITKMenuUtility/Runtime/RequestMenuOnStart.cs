using Mushakushi.MenuFramework.Runtime.ExtensionFramework;
using UnityEngine;

namespace ZombieCrossing.UITKMenuUtility.Runtime
{
    /// <summary>
    /// Immediately opens a <see cref="Menu"/> on <see cref="Start"/>. 
    /// </summary>
    public class RequestMenuOnStart: MonoBehaviour
    {
        [SerializeField] private MenuEventChannel menuEventChannel; 
        [SerializeField] private Menu menu;

        private void Start()
        {
            menuEventChannel.RaiseOnOpenRequested(menu);
        }
    }
}
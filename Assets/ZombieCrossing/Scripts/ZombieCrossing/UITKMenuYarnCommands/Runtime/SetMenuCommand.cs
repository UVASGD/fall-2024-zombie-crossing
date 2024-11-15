using Mushakushi.MenuFramework.Runtime.ExtensionFramework;
using UnityEngine;
using ZombieCrossing.CommandPattern.Runtime;

namespace ZombieCrossing.UITKMenuYarnCommands.Runtime
{
    public class SetMenuCommand: MonoBehaviour, ICommand
    {
        [SerializeField] private Menu menu;
        [SerializeField] private YarnCommandHandlerOpenMenu yarnCommandHandlerOpenMenu;
        
        public void Execute()
        {
            yarnCommandHandlerOpenMenu.menu = menu;
        }
    }
}
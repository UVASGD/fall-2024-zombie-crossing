using Mushakushi.MenuFramework.Runtime.ExtensionFramework;
using UnityEngine;
using YarnSpinnerUtility.Runtime.Commands;

namespace ZombieCrossing.UITKMenuYarnCommands.Runtime
{
    public class YarnCommandHandlerOpenMenu: MonoBehaviour
    {
        [SerializeField] private YarnCommandDispatcher commandDispatcher;
        [SerializeField] private MenuEventChannel menuEventChannel;
        [HideInInspector] public Menu menu; 

        private void Start()
        {
            commandDispatcher.AddCommandHandler("open_menu", HandleOpenMenu);
        }

        private void HandleOpenMenu()       
        {
            menuEventChannel.RaiseOnOpenRequested(menu);
            commandDispatcher.dialogueParser.TryContinue();
        }
    }
}
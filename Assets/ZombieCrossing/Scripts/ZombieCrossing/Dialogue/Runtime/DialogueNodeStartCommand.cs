using UnityEngine;
using YarnSpinnerUtility.Runtime;
using ZombieCrossing.CommandPattern.Runtime;

namespace ZombieCrossing.Dialogue.Runtime
{
    public class DialogueNodeStartCommand: MonoBehaviour, ICommand
    {
        [SerializeField] public new Collider collider;
        [SerializeField] public DialogueParser dialogueParser;
        [SerializeField] public string node; 
        
        public void Execute()
        {
            if (dialogueParser.IsDialogueRunning || !collider.enabled) return;
            collider.enabled = false;
            dialogueParser.SetNode(node);
            dialogueParser.TryContinue();
        }
    }
}
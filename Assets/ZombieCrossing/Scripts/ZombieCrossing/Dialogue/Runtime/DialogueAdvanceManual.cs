using UnityEngine;
using YarnSpinnerUtility.Runtime;
using YarnSpinnerUtility.Runtime.Output;
using ZombieCrossing.Input.Runtime;

namespace ZombieCrossing.Dialogue.Runtime
{
    public class DialogueAdvanceManual: MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private DialogueParser dialogueParser;
        [SerializeField] private LineViewController lineViewController;

        public void OnEnable()
        {
            inputHandler.OnInteract += HandleDialogueAdvance; 
        }
        
        public void OnDisable()
        {
            inputHandler.OnInteract -= HandleDialogueAdvance; 
        }

        private void HandleDialogueAdvance()
        {
            if (!lineViewController.TryCancelViewUpdate()) dialogueParser.TryContinue();
        }
    }
}
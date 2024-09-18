using UnityEngine;
using UnityEngine.InputSystem;
using YarnSpinnerUtility.Runtime;
using YarnSpinnerUtility.Runtime.Output;

namespace YarnSpinnerUtility.Samples.Demo.Source
{
    public class DialogueAdvanceManual: MonoBehaviour
    {
        [SerializeField] private InputActionReference inputAction;
        [SerializeField] private DialogueParser dialogueParser;
        [SerializeField] private LineViewController lineViewController;

        public void OnEnable()
        {
            inputAction.action.Enable();
            inputAction.action.performed += HandleDialogueAdvance; 
        }
        
        public void OnDisable()
        {
            inputAction.action.Disable();
            inputAction.action.performed -= HandleDialogueAdvance; 
        }

        private void HandleDialogueAdvance(InputAction.CallbackContext callbackContext)
        {
            if (!lineViewController.TryCancelViewUpdate()) dialogueParser.TryContinue();
        }
    }
}
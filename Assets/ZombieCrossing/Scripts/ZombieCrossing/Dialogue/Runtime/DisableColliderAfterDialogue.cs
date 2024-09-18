using UnityEngine;
using YarnSpinnerUtility.Runtime;

namespace ZombieCrossing.Dialogue.Runtime
{
    public class DisableColliderAfterDialogue: MonoBehaviour
    {
        [SerializeField] private DialogueParser dialogueParser;
        [SerializeField] private new Collider collider;
        [SerializeField, Min(0), Tooltip("If this is zero, the collider will not be re-enabled.")] private float seconds; 

        private void OnEnable()
        {
            dialogueParser.OnDialogueCompleted += DisableInteractionForSecondsAsync;
        }

        private async void DisableInteractionForSecondsAsync()
        {
            collider.enabled = false;
            if (seconds == 0) return;

            await Awaitable.WaitForSecondsAsync(seconds);
            collider.enabled = true;
        }
    }
}
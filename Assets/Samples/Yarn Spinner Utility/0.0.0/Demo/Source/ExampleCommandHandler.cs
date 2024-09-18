using UnityEngine;
using YarnSpinnerUtility.Runtime.Commands;

namespace YarnSpinnerUtility.Samples.Demo.Source
{
    public class ExampleCommandHandler: MonoBehaviour
    {
        [SerializeField] private YarnCommandDispatcher commandDispatcher;

        private void Start()
        {
            commandDispatcher.AddCommandHandler<string, string, string>("this", HandleRandomDemoCommand);
        }

        private void HandleRandomDemoCommand(string a, string b, string c)
        {
            Debug.Log($"Wow, th{a} {c} w{b}s handled!");
            commandDispatcher.dialogueParser.TryContinue();
        }
    }
}
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using YarnSpinnerUtility.Runtime;
using YarnSpinnerUtility.Runtime.Output;

namespace YarnSpinnerUtility.Samples.Demo.Source
{
    [System.Serializable]
    public class OptionView: IView<DialogueOption[]>
    {
        [SerializeField] private DialogueParser dialogueParser;
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject dialogueOptionParent;

        private List<GameObject> instantiatedDialogueOptions = new();

        public GameObject CreateDialogueOption(DialogueOption dialogueOption)
        {
            var instance = Object.Instantiate(prefab, dialogueOptionParent.transform, false);
            if (!instance.TryGetComponent<Button>(out var button)) instance.AddComponent<Button>();
            button.onClick.AddListener(() =>
            { 
                dialogueParser.SetSelectedOption(dialogueOption);
                dialogueParser.TryContinue();
            });
            if (instance.GetComponentInChildren<TMP_Text>() is { } text)
            {
                text.text = dialogueOption.Line.Text.Text;
            }
            return instance;
        }

        public void Initialize() { }

        public async Awaitable Update(DialogueOption[] dialogueOptions, CancellationToken cancellationToken)
        {
            Clear();
            
            foreach (var dialogueOption in dialogueOptions)
            {
                instantiatedDialogueOptions.Add(CreateDialogueOption(dialogueOption));
            }
            
            await Task.CompletedTask;
        }

        public void Clear()
        {
            foreach (var option in instantiatedDialogueOptions)
            {
                Object.Destroy(option);
            }
        }
    }
}
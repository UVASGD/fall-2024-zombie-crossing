using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Yarn.Unity;
using YarnSpinnerUtility.Runtime.Output;

namespace YarnSpinnerUtility.Samples.Demo.Source
{
    [System.Serializable]
    public class LineViewCharacterName: IView<LocalizedLine>
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text text;

        public void Initialize()
        {
            text.text = string.Empty;
        }

        public async Awaitable Update(LocalizedLine localizedLine, CancellationToken cancellationToken)
        {
            var characterName = localizedLine.CharacterName;
            canvasGroup.alpha = string.IsNullOrEmpty(characterName) ? 0 : 1;
            text.text = localizedLine.CharacterName;
            await Task.CompletedTask;
        }

        public void Clear()
        {
            text.text = string.Empty;
        }
    }
}
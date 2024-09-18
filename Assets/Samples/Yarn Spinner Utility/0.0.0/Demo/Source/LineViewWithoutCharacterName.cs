using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Yarn.Unity;
using YarnSpinnerUtility.Runtime.Output;
using YarnSpinnerUtility.Runtime.UIEffects;

namespace YarnSpinnerUtility.Samples.Demo.Source
{
    [Serializable]
    public class LineViewWithoutCharacterName: IView<LocalizedLine>
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private float fadeSpread;
        [SerializeField] private float fadeSpeed;
        
        public void Initialize()
        {
            text.text = string.Empty;
        }

        public async Awaitable Update(LocalizedLine localizedLine, CancellationToken cancellationToken)
        {
            text.text = localizedLine.TextWithoutCharacterName.Text;
            try
            {
                await TextMeshProEffects.FadeInTextAsync(text, fadeSpread, fadeSpeed, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                text.alpha = 1;
                throw;
            }
        }

        public void Clear()
        {
            text.text = string.Empty;
        }
    }
}
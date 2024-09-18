using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Yarn.Unity;
using YarnSpinnerUtility.Runtime.Output;
using YarnSpinnerUtility.Runtime.UIEffects;

namespace YarnSpinnerUtility.Samples.Demo.Source
{
    [System.Serializable]
    public class FadeInCanvasView: IView<LocalizedLine>
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField, Min(0)] private float fadeDuration;

        public async void Initialize()
        {
            await IMGUIEffects.FadeAlpha(canvasGroup, 0, 1, fadeDuration);
        }

        public async Awaitable Update(LocalizedLine _, CancellationToken cancellationToken) => await Task.CompletedTask;

        public async void Clear()
        {
            await IMGUIEffects.FadeAlpha(canvasGroup, 1, 0, fadeDuration);
        }
    }
}
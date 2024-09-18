using System;
using System.Threading;
using UnityEngine;
using YarnSpinnerUtility.Runtime;
using YarnSpinnerUtility.Runtime.Output;

namespace YarnSpinnerUtility.Samples.Demo.Source
{
    public class DialogueAdvanceAutomatic: MonoBehaviour
    {
        [SerializeField] private DialogueParser dialogueParser;
        [SerializeField] private LineViewController lineViewController;
        [SerializeField] private float waitTime = 0.5f;

        private CancellationTokenSource cancellationTokenSource;
        private AwaitableCompletionSource<bool> completionSource;

        private void OnEnable()
        {
            lineViewController.OnViewUpdated += ContinueDialogue;
            lineViewController.OnViewCleared += HandleDialogueCompleted;
            
            cancellationTokenSource = new CancellationTokenSource();
        }

        private void OnDisable()
        {
            lineViewController.OnViewUpdated -= ContinueDialogue;
            lineViewController.OnViewCleared -= HandleDialogueCompleted;
            
            HandleDialogueCompleted();
        }

        private void HandleDialogueCompleted()
        {
            cancellationTokenSource.CancelAndDispose();
        }

        private void Start()
        {
            // example
            dialogueParser.SetNode("Start"); 
            dialogueParser.TryContinue();
        }

        private async void ContinueDialogue()
        {
            cancellationTokenSource.CancelAndDispose();
            cancellationTokenSource = new CancellationTokenSource();
            
            try
            {
                await Awaitable.WaitForSecondsAsync(waitTime, cancellationTokenSource.Token);
                dialogueParser.TryContinue();
            }
            catch (OperationCanceledException) { }
        }
    }
}
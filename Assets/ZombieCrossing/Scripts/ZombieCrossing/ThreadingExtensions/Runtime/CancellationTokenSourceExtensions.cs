using System;
using System.Threading;

namespace ZombieCrossing.ThreadingExtensions.Runtime
{
    public static class CancellationTokenSourceExtensions
    {
        public static void CancelAndDispose(this CancellationTokenSource cancellationTokenSource)
        {
            try
            {
                cancellationTokenSource.Cancel();
            }
            catch (ObjectDisposedException) { }
            cancellationTokenSource.Dispose();
        }
    }
}
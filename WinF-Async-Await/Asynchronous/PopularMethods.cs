using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinF_Async_Await.Asynchronous
{
    public class PopularMethods
    {
        public static async Task ConfigureAwaitState(bool state)
        {

            int threadId = Thread.CurrentThread.ManagedThreadId;

            await Task.Delay(1000).ConfigureAwait(state);

            threadId = Thread.CurrentThread.ManagedThreadId;
        }

        public static async Task TaskCompletedWhenCreate(CancellationTokenSource cancellationTokenSource)
        {
            
            try
            {
                await Task.WhenAll(TaskFromResult(1, 2), TaskFromCanceledOrCompleted(cancellationTokenSource.Token), TaskFromException());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
        }

        private static Task<int> TaskFromResult(int a, int b)
        {
            return Task.FromResult(a + b);
        }

        private static Task TaskFromCanceledOrCompleted(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return Task.FromCanceled(token);
            }
            return Task.CompletedTask;
        }

        private static Task TaskFromException()
        {
            return Task.FromException(new TimeoutException());
        }
    }
}

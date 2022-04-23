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
            await Task.WhenAll(TaskFromResult(1, 2), TaskFromCanceledOrCompleted(cancellationTokenSource.Token), TaskFromException());
            //await Task.WhenAny(TaskFromResult(1, 2), TaskFromCanceledOrCompleted(cancellationTokenSource.Token), TaskFromException());
            //Task.WaitAll(TaskFromResult(1, 2), TaskFromCanceledOrCompleted(cancellationTokenSource.Token), TaskFromException());
            //Task.WaitAny(TaskFromResult(1, 2), TaskFromCanceledOrCompleted(cancellationTokenSource.Token), TaskFromException());
        }

        private static Task<int> TaskFromResult(int a, int b)
        {
            Task.Delay(1000);
            MessageBox.Show($"{a} + {b} = {a+b}");
            return Task.FromResult(a + b);
        }

        private static Task TaskFromCanceledOrCompleted(CancellationToken token)
        {
            Task.Delay(2000);
            if (token.IsCancellationRequested)
            {
                MessageBox.Show("Task cancelled");
                return Task.FromCanceled(token);
            }
            MessageBox.Show("Task completed");
            return Task.CompletedTask;
        }

        private static Task TaskFromException()
        {
            return Task.FromException(new TimeoutException());
        }
    }
}

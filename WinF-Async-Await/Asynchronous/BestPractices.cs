using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinF_Async_Await.Asynchronous
{
    public class BestPractices
    {
        public static async Task AsyncWithException()
        {
            try
            {
                // will be caught exception
                await ThrowAsyncTask();
                
                // will not
                ThrowAsyncVoid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static async Task SumTask(int a, int b)
        {
            await SumWithTaskBad(a, b);
            await SumWithTaskGood(a, b);
            await SumWithTaskBetter(a, b);
        }

        private static Task<int> SumWithTaskBad(int a, int b)
        {
            return Task.Run(() => a + b);
        }

        private static Task<int> SumWithTaskGood(int a,int b)
        {
            return Task.FromResult(a + b);
        }

        private static ValueTask<int> SumWithTaskBetter(int a, int b)
        {
            return new ValueTask<int>(a + b);
        }

        private static async void ThrowAsyncVoid()
        {
            await Task.Delay(1000);
            throw new TimeoutException();
        }

        private static async Task ThrowAsyncTask()
        {
            await Task.Delay(1000);
            throw new TimeoutException();
        }

        private static void ThrowSyncVoid()
        {
            throw new TimeoutException();
        }

    }
}

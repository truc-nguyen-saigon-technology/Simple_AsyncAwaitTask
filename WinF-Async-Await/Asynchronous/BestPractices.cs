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

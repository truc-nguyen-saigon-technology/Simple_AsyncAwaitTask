using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAsyncAwait.Core.Asynchronous
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
                Console.WriteLine(ex);
            }
        }

        public static async Task SumTask(int a, int b, int timesClick)
        {
            switch (timesClick)
            {
                case 1:
                    await SumWithTaskBad(a, b);
                    break;
                case 2:
                    await SumWithTaskGood(a, b);
                    break;
                case 3:
                    await SumWithTaskBetter(a, b);
                    break;
                default:
                    break;
            }
        }

        private static Task<int> SumWithTaskBad(int a, int b)
        {
            return Task.Run(() =>
            {
                int sum = 0;

                for (int i = 0; i < 100000000; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        sum += a * b * sum;
                    }
                }

                Console.WriteLine("done 1 " + sum);
                return sum;
            });
        }

        private static Task<int> SumWithTaskGood(int a, int b)
        {
            int sum = 0;

            for (int i = 0; i < 100000000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sum += a * b * sum;
                }
            }
            Console.WriteLine("done 2 " + sum);

            return Task.FromResult(sum);
        }

        private static ValueTask<int> SumWithTaskBetter(int a, int b)
        {
            int sum = 0;

            for (int i = 0; i < 100000000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sum += a * b * sum;
                }
            }
            Console.WriteLine("done 3 " + sum);

            return new ValueTask<int>(sum);
        }
       
        private static async Task ThrowAsyncTask()
        {
            await Task.Delay(1000);
            throw new TimeoutException();
        }
      
        private static async void ThrowAsyncVoid()
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

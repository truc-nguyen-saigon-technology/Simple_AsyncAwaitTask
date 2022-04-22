using System.Threading;
using System.Threading.Tasks;

namespace WinF_Async_Await.Asynchronous
{
    public static class IntroTask
    {
        public static void TaskInstantiation()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            int threadId1, threadId2, threadId3, threadId4;

            Task task1 = new Task(() => { threadId1 = Thread.CurrentThread.ManagedThreadId; });
            task1.Start();
            task1.Wait(2000);

            Task task2 = Task.Factory.StartNew(() => { threadId2 = Thread.CurrentThread.ManagedThreadId; });
            task2.Wait(2000);

            Task task3 = Task.Run(() => { threadId3 = Thread.CurrentThread.ManagedThreadId; });
            task3.Wait(2000);

            Task task4 = new Task(() => { threadId4 = Thread.CurrentThread.ManagedThreadId; });
            task4.RunSynchronously();

        }

        public static async Task CommonWaysToCreateNewTask()
        {
            await Task.Run(() => { });
            await Task.Factory.StartNew(() => { }, TaskCreationOptions.LongRunning);

            int sum = await SumByFromResultAsync();
        }

        private static Task<int> SumByFromResultAsync() => Task.FromResult(1 + 2);


    }
}

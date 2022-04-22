using System.Threading.Tasks;

namespace WinF_Async_Await.Asynchronous
{
    public static class BlockUI
    {
        public static void BlockUI1()
        {
            //Thread.Sleep(2000);
            Task.Delay(2000).Wait();
        }

        public static void NonBlockUI1()
        {
            Task.Delay(2000);
        }

        public static Task NonBlockUI2()
        {
            return Task.Delay(2000);
        }

        public static async Task NonBlockUI3()
        {
            await Task.Delay(2000);
        }
    }
}

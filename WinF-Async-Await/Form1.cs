using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinF_Async_Await.Asynchronous;
using System.Threading;

namespace WinF_Async_Await
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer t;

        CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            btn_stop.Enabled = true;

            StartTimer();

            //BlockUI.BlockUI();
            //BlockUI.NonBlockUI1();
            //await BlockUI.NonBlockUI2();
            //await BlockUI.NonBlockUI3();

            //// Create & Execute Tasks
            //IntroTask.TaskInstantiation();
            //await IntroTask.CommonWaysToCreateNewTask();

            // Popular Methods
            //await PopularMethods.ConfigureAwaitState(false);

            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                cancellationTokenSource.CancelAfter(500);
                // About When and Wait
                await PopularMethods.TaskCompletedWhenCreate(cancellationTokenSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }


            // Best Practices
            //await BestPractices.AsyncWithException();

            //using (var cts = new CancellationTokenSource(1000))
            //{
            //    await PopularMethods.TaskCompletedWhenCreate(cts);
            //}

            //await BestPractices.SumTask(1, 2);

        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            //cancellationTokenSource?.Cancel();
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            t.Enabled = false;
        }

        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1;
            t.Tick += new EventHandler(timer1_Tick);
            t.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString("mm:ss.fff tt");
        }
    }
}

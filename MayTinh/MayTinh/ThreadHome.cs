using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayTinh
{
    public partial class ThreadHome : Form
    {
        public ThreadHome()
        {
            InitializeComponent();
        }
        private Thread thread;
        private bool stopThread = false;
        private CancellationTokenSource taskCTS;
        private CancellationTokenSource asyncCTS;
        private void RunThread()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (stopThread)
                    return;

                Invoke(new Action(() =>
                {
                    progressThread.Value = i;
                }));

                Thread.Sleep(10);
            }
        }

        private void startThread_Click_1(object sender, EventArgs e)
        {
            stopThread = false;
            progressThread.Value = 0;
            thread = new Thread(RunThread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void endThread_Click(object sender, EventArgs e)
        {
            stopThread = true;
            progressThread.Value = 0;
        }
        
        private async void startTask_Click(object sender, EventArgs e)
        {
            taskCTS = new CancellationTokenSource();
            progressTask.Value = 0;
            try
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        taskCTS.Token.ThrowIfCancellationRequested();

                        Invoke(new Action(() =>
                        {
                            progressTask.Value = i;
                        }));

                        Thread.Sleep(10);
                    }

                }, taskCTS.Token);
            }
            catch (OperationCanceledException)
            {
                progressTask.Invoke(new Action(() =>
                {
                    progressTask.Value = 0;
                }));
            }
        }

        private void endTask_Click(object sender, EventArgs e)
        {
            taskCTS?.Cancel();
            progressTask.Value = 0;
        }

        private void endAsync_Click(object sender, EventArgs e)
        {
            asyncCTS?.Cancel();
            progressAsync.Value = 0;
        }
        private async void startAsync_Click(object sender, EventArgs e)
        {
            asyncCTS = new CancellationTokenSource();
            progressAsync.Value = 0;

            try
            {
                for (int i = 0; i <= 100; i++)
                {
                    asyncCTS.Token.ThrowIfCancellationRequested();

                    progressAsync.Value = i;

                    await Task.Delay(10, asyncCTS.Token);
                }
            }
            catch (OperationCanceledException)
            {
                progressAsync.Value = 0;
            }
        }
    }
}

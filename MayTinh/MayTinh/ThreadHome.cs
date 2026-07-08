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
            this.FormClosing += ThreadHome_FormClosing;
        }
        private Thread thread;
        private bool threadRunning;
        private int valueThread = 0;
        private Task taskWorker;
        private CancellationTokenSource taskCTS;
        private int valueTask = 0;
        private CancellationTokenSource asyncCTS;
        private bool asyncRunning;
        private int valueAsync = 0;
        private void RunThread()
        {
            while (threadRunning)
            {
                if (IsDisposed)
                    return;
                BeginInvoke(new Action(() =>
                {
                    //Text = valueThread.ToString();
                    progressThread.Value = valueThread;
                }));
                valueThread ++;
                if (valueThread > 100) valueThread = 50;
                Thread.Sleep(50);
            }
        }

        private void startThread_Click(object sender, EventArgs e)
        {
            if (threadRunning) return;
            threadRunning = true;
            thread = new Thread(RunThread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void endThread_Click(object sender, EventArgs e)
        {
            threadRunning = false;
        }
        private async void startTask_Click(object sender, EventArgs e)
        {
            if (taskWorker != null && !taskWorker.IsCompleted) return;

            taskCTS = new CancellationTokenSource();

            taskWorker = Task.Run(() =>
            {
                while (!taskCTS.Token.IsCancellationRequested)
                {
                    if (IsDisposed) return;
                    BeginInvoke(new Action(() => {progressTask.Value = valueTask;}));
                    valueTask++;
                    if (valueTask > 100) valueTask = 0;
                    Thread.Sleep(50);
                }
            }, taskCTS.Token);
        }
        private void endTask_Click(object sender, EventArgs e)
        {
            taskCTS?.Cancel();
        }
        private async void startAsync_Click(object sender, EventArgs e)
        {
            if (asyncRunning) return;
            asyncRunning = true;
            asyncCTS = new CancellationTokenSource();
            try
            {
                while (asyncRunning)
                {
                    asyncCTS.Token.ThrowIfCancellationRequested();
                    valueAsync++;
                    if (valueAsync > 100) { valueAsync = 0; }
                    progressAsync.Value = valueAsync;
                    await Task.Delay(50, asyncCTS.Token);
                }
            }
            catch (OperationCanceledException){}
            finally
            {
                asyncRunning = false;
            }
        }
        private void endAsync_Click(object sender, EventArgs e)
        {
            asyncCTS?.Cancel();
        }
        private void ThreadHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadRunning = false;
            taskCTS?.Cancel();
            asyncCTS?.Cancel();
        }

        private void progressThread_Click(object sender, EventArgs e)
        {

        }
    }
}

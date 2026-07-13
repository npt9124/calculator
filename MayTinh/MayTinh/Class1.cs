using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayTinh
{
    internal class Class1
    {
        private Thread thread;
        private bool threadRunning;
        private int valueThread = 0;
        private Task taskWorker;
        private CancellationToken taskCTS;
        private int valueTask = 0;
        private CancellationToken asyncCTS;
        private bool asyncRunning;
        private int valueAsync = 0;

    }
}

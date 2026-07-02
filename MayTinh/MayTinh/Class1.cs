//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace MayTinh
//{
//    internal class Class1
//    {
//        long elapsedMilliseconds = 0;

//        bool isRunning = false;

//        int lap = 1;

//        long lastLapMilliseconds = 0;
//        private void UpdateDisplay()
//        {
//            long hours = elapsedMilliseconds / 3600000;
//            long minutes = (elapsedMilliseconds % 3600000) / 60000;
//            long seconds = (elapsedMilliseconds % 60000) / 1000;
//            long centiseconds = (elapsedMilliseconds % 1000) / 10;

//        }

//        private string FormatTime(long milliseconds)
//        {
//            long hours = milliseconds / 3600000;
//            long minutes = (milliseconds % 3600000) / 60000;
//            long seconds = (milliseconds % 60000) / 1000;
//            long centiseconds = (milliseconds % 1000) / 10;

//            return $"{hours:00}:{minutes:00}:{seconds:00}.{centiseconds:00}";
//        }

//    }
//    private void btnSave_Click(object sender, EventArgs e)
//        {
//            if (!timer1.Enabled)
//            {
//                MessageBox.Show("Đồng hồ chưa chạy!");
//                return;
//            }

//            long current = elapsedMilliseconds;

//            long lapTime = current - lastSaveMilliseconds;

//            dgvLap.Rows.Insert(
//                0,
//                lap,
//                FormatTime(lapTime),
//                FormatTime(current)
//            );

//            lastSaveMilliseconds = current;

//            lap++;
//        }
//        private void btnRestart_Click(object sender, EventArgs e)
//        {
//            timer1.Stop();

//            elapsedMilliseconds = 0;
//            lastSaveMilliseconds = 0;
//            lap = 1;

//            lblTime.Text = "00:00:00.00";

//            dgvLap.Rows.Clear();

//            btnStart.Text = "Start";
//        }
//    }
//}

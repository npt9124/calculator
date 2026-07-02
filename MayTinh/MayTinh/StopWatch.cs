using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Text.Json;

namespace MayTinh
{
    public partial class StopWatch : Form
    {
        public StopWatch()
        {
            InitializeComponent();
            //timer1.Interval = 10; comboBox.Items.Clear();
            comboBox.Items.AddRange(new object[] { "csv", "json", "txt", "ini" });
            comboBox.SelectedIndex = 0;
        }


        long elapsedMilliseconds = 0;
        bool isRunning = false;
        int lap = 1;
        long lastLapMilliseconds = 0;
        DateTime startTime;
        DateTime pauseTime;
        private void UpdateDisplay()
        {
            long hours = elapsedMilliseconds / 3600000;
            long minutes = (elapsedMilliseconds % 3600000) / 60000;
            long seconds = (elapsedMilliseconds % 60000) / 1000;
            long centiseconds = (elapsedMilliseconds % 1000) / 10;
            lblTime.Text = $"{hours:00}:{minutes:00}:{seconds:00}.{centiseconds:00}";
        }
        private String FormatTime(long milliseconds)
        {
            long hours = milliseconds / 3600000;
            long minutes = (milliseconds % 3600000) / 60000;
            long seconds = (milliseconds % 60000) / 1000;
            long centiseconds = (milliseconds % 1000) / 10;
            return $"{hours:00}:{minutes:00}:{seconds:00}.{centiseconds:00}";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(!isRunning)
            {
                if (elapsedMilliseconds == 0)
                {
                    startTime = DateTime.Now;
                }
                else
                {
                    startTime = DateTime.Now - TimeSpan.FromMilliseconds(elapsedMilliseconds);
                }    
                timer1.Start();
                DateTime time1 = DateTime.Now;
                isRunning = true;
                btnStart.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                isRunning = false;
                btnStart.Text = "Start";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!timer1.Enabled)
            {
                MessageBox.Show("Đồng hồ chưa chạy!");
                return;
            }
            long current = elapsedMilliseconds;
            long lapTime = current - lastLapMilliseconds;
            dataGridView1.Rows.Insert(0,lap,FormatTime(lapTime),FormatTime(current));
            lastLapMilliseconds = current;
            lap++;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            isRunning = false;

            elapsedMilliseconds = 0;

            lastLapMilliseconds = 0;

            lap = 1;
            startTime = DateTime.MinValue;
            pauseTime = DateTime.MinValue;

            lblTime.Text = "00:00:00.00";

            dataGridView1.Rows.Clear();

            btnStart.Text = "Start";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            elapsedMilliseconds = (long)(DateTime.Now - startTime).TotalMilliseconds;
            UpdateDisplay();
        }

        public class LapRecord
        {
            public int LapNumber { get; set; }
            public string LapTime { get; set; }
            public string TotalTime { get; set; }
        }
        public class StopWatchData
        {
            public long ElapsedMilliseconds { get; set; }
            public bool IsRunning { get; set; }
            public int Lap { get; set;  }
            public long LastLapMilliseconds { get; set; }
            public List<LapRecord> LapRecords { get; set; } = new List<LapRecord>();

        }
        private string GetFileFilter(string format)
        {
            switch (format)
            {
                case "csv": return "CSV files (*.csv)|*.csv";
                case "json": return "JSON files (*.json)|*.json";
                case "txt": return "Text files (*.txt)|*.txt";
                case "ini": return "INI files (*.ini)|*.ini";
                default: return "All files (*.*)|*.*";
            }
        }
        private string ExportToCsv(StopWatchData data)
        {
            var sb = new StringBuilder();
            sb.AppendLine("LapNumber,LapTime,TotalTime");
            foreach (var l in data.LapRecords)
                sb.AppendLine($"{l.LapNumber},{l.LapTime},{l.TotalTime}");
            return sb.ToString();
        }

        private string ExportToJson(StopWatchData data) =>
            JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

        private string ExportToTxt(StopWatchData data)
        {
            var sb = new StringBuilder();
            //sb.AppendLine($"ElapsedMilliseconds: {data.ElapsedMilliseconds}");
            //sb.AppendLine($"IsRunning: {data.IsRunning}");
            //sb.AppendLine($"Lap: {data.Lap}");
            //sb.AppendLine($"LastLapMilliseconds: {data.LastLapMilliseconds}");
            //sb.AppendLine("---LAPS---");
            foreach (var l in data.LapRecords)

                sb.AppendLine($"{l.LapNumber}\t{l.LapTime}\t{l.TotalTime}");
            return sb.ToString();
        }


        private string ExportToIni(StopWatchData data)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.LapRecords.Count; i++)
            {
                var l = data.LapRecords[i];
                sb.AppendLine($"Lap={i + 1}");
                sb.AppendLine($"Number={l.LapNumber}");
                sb.AppendLine($"LapTime={l.LapTime}");
                sb.AppendLine($"TotalTime={l.TotalTime}");
            }
            return sb.ToString();
        }

        private StopWatchData ImportFromCsv(string content)
        {
            var data = new StopWatchData();
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var stateValues = lines[1].Split(',');
            data.ElapsedMilliseconds = long.Parse(stateValues[0]);
            data.IsRunning = bool.Parse(stateValues[1]);
            data.Lap = int.Parse(stateValues[2]);
            data.LastLapMilliseconds = long.Parse(stateValues[3]);

            for (int i = 4; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length < 3) continue;
                data.LapRecords.Add(new LapRecord { LapNumber = int.Parse(parts[0]), LapTime = parts[1], TotalTime = parts[2] });
            }
            return data;
        }

        private StopWatchData ImportFromJson(string content) =>
            JsonSerializer.Deserialize<StopWatchData>(content) ?? new StopWatchData();

        private StopWatchData ImportFromTxt(string content)
        {
            var data = new StopWatchData();
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bool readingLaps = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("---LAPS---")) { readingLaps = true; continue; }
                if (!readingLaps)
                {
                    var kv = line.Split(new[] { ':' }, 2);
                    if (kv.Length != 2) continue;
                    switch (kv[0].Trim())
                    {
                        case "ElapsedMilliseconds": data.ElapsedMilliseconds = long.Parse(kv[1].Trim()); break;
                        case "IsRunning": data.IsRunning = bool.Parse(kv[1].Trim()); break;
                        case "Lap": data.Lap = int.Parse(kv[1].Trim()); break;
                        case "LastLapMilliseconds": data.LastLapMilliseconds = long.Parse(kv[1].Trim()); break;
                    }
                }
                else
                {
                    var parts = line.Split('\t');
                    if (parts.Length < 3) continue;
                    data.LapRecords.Add(new LapRecord { LapNumber = int.Parse(parts[0]), LapTime = parts[1], TotalTime = parts[2] });
                }
            }
            return data;
        }

        private StopWatchData ImportFromIni(string content)
        {
            var data = new StopWatchData();
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var lapDict = new Dictionary<int, LapRecord>();
            string section = "";

            foreach (var line in lines)
            {
                string t = line.Trim();
                if (t.StartsWith("[") && t.EndsWith("]")) { section = t; continue; }
                var kv = t.Split(new[] { '=' }, 2);
                if (kv.Length != 2) continue;
                string key = kv[0].Trim(), value = kv[1].Trim();

                if (section == "[State]")
                {
                    switch (key)
                    {
                        case "ElapsedMilliseconds": data.ElapsedMilliseconds = long.Parse(value); break;
                        case "IsRunning": data.IsRunning = bool.Parse(value); break;
                        case "Lap": data.Lap = int.Parse(value); break;
                        case "LastLapMilliseconds": data.LastLapMilliseconds = long.Parse(value); break;
                    }
                }
                else if (section == "[Laps]")
                {
                    int dot = key.IndexOf('.');
                    if (dot < 0) continue;
                    int idx = int.Parse(key.Substring(0, dot).Replace("Lap", ""));
                    if (!lapDict.ContainsKey(idx)) lapDict[idx] = new LapRecord();
                    switch (key.Substring(dot + 1))
                    {
                        case "Number": lapDict[idx].LapNumber = int.Parse(value); break;
                        case "LapTime": lapDict[idx].LapTime = value; break;
                        case "TotalTime": lapDict[idx].TotalTime = value; break;
                    }
                }
            }
            foreach (var kv in lapDict.OrderBy(x => x.Key)) data.LapRecords.Add(kv.Value);
            return data;
        }
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            string format = comboBox.SelectedItem?.ToString()?.ToLower();
            if (string.IsNullOrEmpty(format))
            {
                MessageBox.Show("Vui lòng chọn định dạng file!");
                return;
            }

            StopWatchData data = new StopWatchData
            {
                ElapsedMilliseconds = elapsedMilliseconds,
                IsRunning = isRunning,
                Lap = lap,
                LastLapMilliseconds = lastLapMilliseconds
            };

            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                var row = dataGridView1.Rows[i];
                if (row.Cells[0].Value == null) continue;
                data.LapRecords.Add(new LapRecord
                {
                    LapNumber = Convert.ToInt32(row.Cells[0].Value),
                    LapTime = row.Cells[1].Value?.ToString(),
                    TotalTime = row.Cells[2].Value?.ToString()
                });
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = GetFileFilter(format);
            sfd.FileName = $"stopwatch_history.{format}";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string content;
                switch (format)
                {
                    case "csv":
                        content = ExportToCsv(data);
                        break;
                    case "json":
                        content = ExportToJson(data);
                        break;
                    case "txt":
                        content = ExportToTxt(data);
                        break;
                    case "ini":
                        content = ExportToIni(data);
                        break;
                    default:
                        throw new NotSupportedException();
                }
                File.WriteAllText(sfd.FileName, content, Encoding.UTF8);
                MessageBox.Show("Xuất file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message);
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            string format = comboBox.SelectedItem?.ToString()?.ToLower();
            if (string.IsNullOrEmpty(format))
            {
                MessageBox.Show("Vui lòng chọn định dạng file!");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = GetFileFilter(format);
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                StopWatchData data;
                switch (format)
                {
                    case "csv":
                        data = ImportFromCsv(content);
                        break;
                    case "json":
                        data = ImportFromJson(content);
                        break;
                    case "txt":
                        data = ImportFromTxt(content);
                        break;
                    case "ini":
                        data = ImportFromIni(content);
                        break;
                    default:
                        throw new NotSupportedException();
                }

                timer1.Stop();
                isRunning = false;
                btnStart.Text = "Start";
                elapsedMilliseconds = data.ElapsedMilliseconds;
                lap = data.Lap;
                lastLapMilliseconds = data.LastLapMilliseconds;
                UpdateDisplay();

                dataGridView1.Rows.Clear();
                for (int i = data.LapRecords.Count - 1; i >= 0; i--)
                {
                    var l = data.LapRecords[i];
                    dataGridView1.Rows.Insert(0, l.LapNumber, l.LapTime, l.TotalTime);
                }

                if (data.IsRunning)
                {
                    startTime = DateTime.Now - TimeSpan.FromMilliseconds(elapsedMilliseconds);
                    timer1.Start();
                    isRunning = true;
                    btnStart.Text = "Stop";
                }

                MessageBox.Show("Nạp file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

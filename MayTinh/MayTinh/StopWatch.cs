using CsvHelper;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static MayTinh.StopWatch;
namespace MayTinh
{

    public partial class StopWatch : Form
    {
        public StopWatch()
        {
            InitializeComponent();
            //timer1.Interval = 10; 
            comboBox.Items.AddRange(new object[] { "csv", "json", "txt", "ini" });
            comboBox.SelectedIndex = 0;
            btnRestart.Enabled = false;
            btnSave.Enabled = false;

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
            if (!isRunning)
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
                btnRestart.Enabled = true;
                btnSave.Enabled = true;
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
            if (!timer1.Enabled)
            {
                MessageBox.Show("Đồng hồ chưa chạy!");
                return;
            }
            long current = elapsedMilliseconds;
            long lapTime = current - lastLapMilliseconds;
            dataGridView1.Rows.Insert(0, lap, FormatTime(lapTime), FormatTime(current));
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
            btnRestart.Enabled = false;
            btnSave.Enabled = false;
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
        public class IniFile
        {
        public string Path;

        public IniFile(string path)
        {
            Path = path;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(
            string section,
            string key,
            string value,
            string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(
            string section,
            string key,
            string defaultValue,
            StringBuilder value,
            int size,
            string filePath);

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        public string Read(string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section,key,"",sb,255,Path);
            return sb.ToString();
        }
    } 
        private List<LapRecord> ImportFromJson(string content) =>
        JsonSerializer.Deserialize<List<LapRecord>>(content) ?? new List<LapRecord>();

        private string ExportToJson(List<LapRecord> laps)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(laps, options);
        }
     
        private string ExportToTxt(List<LapRecord> laps)
        {
            var sb = new StringBuilder();
            foreach (var l in laps)sb.AppendLine($"{l.LapNumber}\t{l.LapTime}\t{l.TotalTime}");
            return sb.ToString();
        }
        private void ExportToIni(List<LapRecord> laps, string fileName)
        {
            IniFile ini = new IniFile(fileName);
            for (int i = 0; i < laps.Count; i++)
            {
                string section = $"Lap{i + 1}";
                ini.Write(section, "Number", laps[i].LapNumber.ToString());
                ini.Write(section, "LapTime", laps[i].LapTime);
                ini.Write(section, "TotalTime", laps[i].TotalTime);
            }
        }
        private List<LapRecord> ImportFromIni(string fileName)
        {
            IniFile ini = new IniFile(fileName);

            List<LapRecord> laps = new List<LapRecord>();

            int i = 1;

            while (true)
            {
                string section = $"Lap{i}";

                string number = ini.Read(section, "Number");

                if (string.IsNullOrEmpty(number))
                {
                    if (i == 1) throw new FormatException("Không đúng định dạng file");
                    break;
                }
                if (!int.TryParse(number, out int lapNum)) throw new FormatException("Format file không hợp lệ");
                string lapTime = ini.Read(section, "Laptime");
                string totalTime = ini.Read(section, "TotalTime");
                if (string.IsNullOrEmpty(lapTime) || string.IsNullOrEmpty(totalTime)) throw new FormatException("File không đúng định dạng");
                laps.Add(new LapRecord { LapNumber = lapNum, LapTime = lapTime, TotalTime = totalTime });
                i++;
            }
            return laps;
        }
        private string ExportToCsv(List<LapRecord> laps)
        {
            var writer = new StringWriter();
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(laps);
            return writer.ToString();
        }

        private List<LapRecord> ImportFromCsv(string content)
        {
            var reader = new StringReader(content);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<LapRecord>().ToList();
        }
        private bool IsValidTimeFormat(string time)
        {
            if (time.Length != 11) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(time, @"^\d{2}:\d{2}:\d{2}\.\d{2}$");
        }
        private List<LapRecord> ImportFromTxt(string content)
        {
            var laps = new List<LapRecord>();
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0) throw new FormatException("File txt không có dữ liệu");
            for(int i =0; i<lines.Length; i++)
            {
                var parts = lines[i].Split('\t');
                if (parts.Length != 3) throw new FormatException("File không đúng định dạng");
                if (int.TryParse(parts[0].Trim(), out int lapNum)) throw new FormatException("Dòng đầu phải chứa số nguyên hợp lệ");
                if (!IsValidTimeFormat(parts[1].Trim())) throw new FormatException("Định dạng thời gian không hợp lệ");
                if (!IsValidTimeFormat(parts[2].Trim())) throw new FormatException("Định dạng thời gian không hợp lệ");
                laps.Add(new LapRecord
                {
                    LapNumber = lapNum,
                    LapTime = parts[1].Trim(),
                    TotalTime = parts[2].Trim()
                });
            }
            if (laps.Count == 0)throw new FormatException("File TXT không chứa dữ liệu lap hợp lệ.");
            return laps;
        }
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            string format = comboBox.SelectedItem?.ToString()?.ToLower();
            if (string.IsNullOrEmpty(format))
            {
                MessageBox.Show("Vui lòng chọn định dạng file!");
                return;
            }
            var laps = new List<LapRecord>();
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                var row = dataGridView1.Rows[i];
                if (row.Cells[0].Value == null) continue;
                laps.Add(new LapRecord
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
                if (format == "ini")
                {
                    ExportToIni(laps, sfd.FileName);
                }
                else
                {
                    string content;
                    switch (format)
                    {
                        case "csv": content = ExportToCsv(laps); break;
                        case "json": content = ExportToJson(laps); break;
                        case "txt": content = ExportToTxt(laps); break;
                        default: throw new NotSupportedException();
                    }
                    File.WriteAllText(sfd.FileName, content, Encoding.UTF8); 
                }
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
                List<LapRecord> laps;
                if (format == "ini")
                {
                    laps = ImportFromIni(ofd.FileName);
                }
                else
                {
                    string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                    switch (format)
                    {
                        case "csv": laps = ImportFromCsv(content); break;
                        case "json": laps = ImportFromJson(content); break;
                        case "txt": laps = ImportFromTxt(content); break;
                        default: throw new NotSupportedException();
                    }
                }
                dataGridView1.Rows.Clear();
                for (int i = laps.Count - 1; i >= 0; i--)
                    dataGridView1.Rows.Insert(0, laps[i].LapNumber, laps[i].LapTime, laps[i].TotalTime);
                MessageBox.Show("Nạp file thành công!");
            }
            catch 
            {
                MessageBox.Show("Lỗi khi đọc file");
            }
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

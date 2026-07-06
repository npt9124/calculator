//using System;
//using System.Collections.Generic;
//using System.Text.Json;
//using static MayTinh.StopWatch;

//private List<LapRecord> ImportFromCsv(string content)
//{
//    var laps = new List<LapRecord>();
//    var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

//    // Kiểm tra header
//    if (lines.Length == 0 || lines[0].Trim() != "LapNumber,LapTime,TotalTime")
//        throw new FormatException("File CSV không đúng định dạng! Dòng đầu phải là: LapNumber,LapTime,TotalTime");

//    for (int i = 1; i < lines.Length; i++)
//    {
//        var parts = lines[i].Split(',');
//        if (parts.Length < 3)
//            throw new FormatException($"File CSV lỗi ở dòng {i + 1}: không đủ 3 cột.");
//        if (!int.TryParse(parts[0], out int lapNum))
//            throw new FormatException($"File CSV lỗi ở dòng {i + 1}: LapNumber không hợp lệ.");
//        laps.Add(new LapRecord { LapNumber = lapNum, LapTime = parts[1], TotalTime = parts[2] });
//    }
//    return laps;
//}

//private List<LapRecord> ImportFromJson(string content)
//{
//    try
//    {
//        var laps = JsonSerializer.Deserialize<List<LapRecord>>(content);
//        if (laps == null || laps.Count == 0)
//            throw new FormatException("File JSON không chứa dữ liệu lap hợp lệ.");
//        // Kiểm tra từng phần tử có đủ field không
//        foreach (var l in laps)
//            if (l.LapTime == null || l.TotalTime == null)
//                throw new FormatException("File JSON thiếu trường LapTime hoặc TotalTime.");
//        return laps;
//    }
//    catch (JsonException)
//    {
//        throw new FormatException("File JSON sai cú pháp, không thể đọc.");
//    }
//}

//private List<LapRecord> ImportFromTxt(string content)
//{
//    var laps = new List<LapRecord>();
//    var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

//    if (lines.Length == 0)
//        throw new FormatException("File TXT trống, không có dữ liệu.");

//    foreach (var line in lines)
//    {
//        var parts = line.Split('\t');
//        if (parts.Length < 3)
//            throw new FormatException($"File TXT lỗi ở dòng: \"{line}\"\nDòng phải có đúng 3 cột phân cách bằng Tab.");
//        if (!int.TryParse(parts[0], out int lapNum))
//            throw new FormatException($"File TXT lỗi: LapNumber \"{parts[0]}\" không hợp lệ.");
//        laps.Add(new LapRecord { LapNumber = lapNum, LapTime = parts[1], TotalTime = parts[2] });
//    }
//    return laps;
//}

//private List<LapRecord> ImportFromIni(string fileName)
//{
//    IniFile ini = new IniFile(fileName);
//    List<LapRecord> laps = new List<LapRecord>();
//    int i = 1;

//    while (true)
//    {
//        string section = $"Lap{i}";
//        string number = ini.Read(section, "Number");

//        if (string.IsNullOrEmpty(number))
//        {
//            if (i == 1)
//                throw new FormatException("File INI không đúng định dạng! Không tìm thấy section [Lap1].");
//            break;
//        }

//        if (!int.TryParse(number, out int lapNum))
//            throw new FormatException($"File INI lỗi ở [{section}]: Number \"{number}\" không hợp lệ.");

//        string lapTime = ini.Read(section, "LapTime");
//        string totalTime = ini.Read(section, "TotalTime");

//        if (string.IsNullOrEmpty(lapTime) || string.IsNullOrEmpty(totalTime))
//            throw new FormatException($"File INI lỗi ở [{section}]: thiếu LapTime hoặc TotalTime.");

//        laps.Add(new LapRecord { LapNumber = lapNum, LapTime = lapTime, TotalTime = totalTime });
//        i++;
//    }
//    return laps;
//}
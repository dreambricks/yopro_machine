using System;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class DataUploaderUtils
{
    public static void BackupFile(string filename, string outputPath, string backupPath)
    {
        string from = Path.Combine(outputPath, filename);
        string to = Path.Combine(backupPath, filename);

        File.Move(from, to);
    }

    public static bool CheckForInternetConnection(int timeoutMs = 2000)
    {
        try
        {
            string url = "http://www.gstatic.com/generate_204";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.KeepAlive = false;
            request.Timeout = timeoutMs;
            using (var response = (HttpWebResponse)request.GetResponse())
                return true;
        }
        catch
        {
            return false;
        }
    }

    public static void CheckIfDirectoryExists(string path)
    {
        bool exists = System.IO.Directory.Exists(path);

        if (!exists)
        {
            System.IO.Directory.CreateDirectory(path);
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;

class Program
{
    public string appDataRoamingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "plakapp");

    static void Main(string[] args)
    {
        Program program = new Program();
        if (!Directory.Exists(program.appDataRoamingPath))
        {
            Directory.CreateDirectory(program.appDataRoamingPath);
        }
        var appdataFiles = Directory.GetFiles(program.appDataRoamingPath);
        foreach ( var appdataFile in appdataFiles )
        {
            File.Delete(appdataFile);
        }
        Directory.SetCurrentDirectory("game_data");
        if (!File.Exists(program.appDataRoamingPath + "/data"))
        {
            File.Copy("data", program.appDataRoamingPath + "/data");
        }
        Directory.SetCurrentDirectory(program.appDataRoamingPath);
        program.ExtractZip("data");
        program.ExtractZip("lua54");
        File.Delete("lua54");
        Process process = new Process();
        process.StartInfo.FileName = Path.Combine(program.appDataRoamingPath, "lua54.exe");
        process.StartInfo.Arguments = "binary";
        process.Start();
        Thread.Sleep(1000);
        File.Delete(Path.Combine(program.appDataRoamingPath, "binary"));
        process.WaitForExit();
    }

    void ExtractZip(string zipFileName)
    {
        string zipFilePath = Path.Combine(Directory.GetCurrentDirectory(), zipFileName);
        ZipFile.ExtractToDirectory(zipFilePath, appDataRoamingPath, true);
    }

}

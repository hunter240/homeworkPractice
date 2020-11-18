using System;
using static System.Console;
using static System.IO.Directory;
using static System.Environment;
using static System.IO.Path;
using System.IO;
using System.Net;

namespace homeworkPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*while (true)
            {
                WriteLine("would you like to add anything to your file?");
                string option = ReadLine().ToLower();
                switch(option)
                {
                    case "yes":
                        StreamWriterFunction();
                        break;
                    case "no":
                        return;
                    default:
                        break;
                }
            }*/    
            //WorkWithFiles();
            //NetWorking();
            //OutputFileSystemInfo();
            //WorkWithDrives();
        }
        static void OutputFileSystemInfo()
        {
            WriteLine("{0,-33} {1}", "Path.PathSeparator", PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar",
                DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()",
                GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Environment.CurrentDirectory",
                CurrentDirectory);
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory",
                SystemDirectory);
            WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());

            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0,-33} {1}", " .System)",
                GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", " .ApplicationData)",
                GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", " .MyDocuments)",
                GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", " .Personal)",
                GetFolderPath(SpecialFolder.Personal));
        }
        static void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
            "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine(
                    "{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                    drive.Name, drive.DriveType, drive.DriveFormat,
                    drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }

        static void WorkWithFiles()
        {
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "OutputFiles");
            CreateDirectory(dir);

            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");


            WriteLine($"Does it exist? {File.Exists(textFile)}");


            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close();
            WriteLine($"Does it exist? {File.Exists(textFile)}");


            File.Copy(sourceFileName: textFile,
            destFileName: backupFile, overwrite: true);
            WriteLine(
            $"Does {backupFile} exist? {File.Exists(backupFile)}");
            Write("Confirm the files exist, and then press ENTER: ");
            ReadLine();


            File.Delete(textFile);
            WriteLine($"Does it exist? {File.Exists(textFile)}");


            WriteLine($"Reading contents of {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();
        }
        static void NetWorking()
        {
            WriteLine("Enter a valid web address: ");
            string url = ReadLine();
            if (string.IsNullOrWhiteSpace(url))
            {
                url = "https://world.episerver.com/cms/?q=pagetype";
            }

            var uri = new Uri(url);

            WriteLine($"URL: {url}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");

            IPHostEntry entry = Dns.GetHostEntry(uri.Host);

            WriteLine($"{entry.HostName} has the following IP addresses:");
            foreach (IPAddress address in entry.AddressList)
            {
                WriteLine($" {address}");
            }
        }
    }
}

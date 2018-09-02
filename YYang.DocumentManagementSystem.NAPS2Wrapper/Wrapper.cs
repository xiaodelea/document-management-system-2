using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;

namespace YYang.DocumentManagementSystem.NAPS2Wrapper
{
    public static class Wrapper
    {
        private const string NAPS2Exe = "NAPS2.exe";
        private const string NAPS2ConsoleExe = "NAPS2.Console.exe";

        public static string GetInstallationPath()
        {
            var path = "";

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\NAPS2 (Not Another PDF Scanner 2)_is1"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("InstallLocation");
                        if (o != null)
                        {
                            path = (o as String);  //"as" because it's REG_SZ...otherwise ToString() might be safe(r) do what you like with version
                        }

                        return path;
                    }

                    return null;
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                return null;
            }
        }

        public static string GetNAPS2FullPath()
        {
            return GetInstallationPath() + NAPS2Exe;
        }

        public static string GetNAPS2ConsoleFullPath()
        {
            return GetInstallationPath() + NAPS2ConsoleExe;
        }

        public static int Scan()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.WorkingDirectory = GetInstallationPath();
            startInfo.Arguments = String.Format("/C {0} {1}", NAPS2ConsoleExe, NAPS2OptionsBuilder());
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            Console.WriteLine("Scan finished with exit code: " + process.ExitCode);

            return process.ExitCode;
        }

        private static string NAPS2OptionsBuilder()
        {
            var options = new List<string>();
            var today = DateTime.Now;
            var fileName = String.Format("{0}-{1}-{2}_{3}-{4}-{5}", today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second);

            options.Add("-o");
            options.Add(String.Format(@"F:\Pictures\Scans\{0}.jpg", fileName));

            var arguments = "";

            foreach (var option in options)
            {
                arguments += option;
                arguments += " ";
                // trailing whitespace for last element should not matter, I think?
            }

            return arguments;
        }
    }
}

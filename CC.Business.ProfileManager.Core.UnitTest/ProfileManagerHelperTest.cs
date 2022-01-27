using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace CC.Business.ProfileManager.Core.CribisComX.UnitTest
{
    
    static class ProfileManagerHelperTest
    {
        public static void ExecuteDataBaseScript(string scriptPath)
        {
            string completePath = Path.Combine(Environment.CurrentDirectory, scriptPath);
            if (File.Exists(completePath))
            {
                Process sqlplusProcess = new Process();
                sqlplusProcess.StartInfo.FileName = "sqlplus.exe";
                sqlplusProcess.StartInfo.CreateNoWindow = true;
                sqlplusProcess.StartInfo.Arguments = String.Format(@"-s {0} @""{1}"" ", ConfigurationManager.AppSettings["CribisComSqlPlusConnString"], completePath);
                sqlplusProcess.StartInfo.UseShellExecute = false;
                sqlplusProcess.StartInfo.RedirectStandardOutput = true;
                sqlplusProcess.Start();
                sqlplusProcess.WaitForExit();

                if (sqlplusProcess.ExitCode != 0)
                {
                    string output = sqlplusProcess.StandardOutput.ReadToEnd();
                    throw new ApplicationException(sqlplusProcess.StandardOutput.ReadToEnd());
                }
            }
            else
            {
                throw new ApplicationException(string.Format("il file {0} non è stato trovato", completePath));
            }
        }
    }
}

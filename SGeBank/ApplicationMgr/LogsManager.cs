using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace eMais.ApplicationMgr
{
    //This class will write all the aplication logs to make easy to identify errors.
    public class LogsManager
    {
        public LogsManager(){}
        public static void writeErrorLogs(string errorMessage, string innerExp)
        {
            //Specify a name for your top-level folder.
            string folderName = @"c:\LogseBank";

            // To create a string that specifies the path to a subfolder under your
            // top-level folder, add a name for the subfolder to folderName.
            string pathString = System.IO.Path.Combine(folderName, "ErrorLogs");

            // Create the subfolder. You can verify in File Explorer that you have this
            System.IO.Directory.CreateDirectory(pathString);

            string fileName = "Errorlogs.txt";

            // Use Combine again to add the file name to the path.
            pathString = System.IO.Path.Combine(pathString, fileName);

            // Check that the file doesn't already exist. If it doesn't exist, create
            // the file and write the logs.
            // DANGER: System.IO.File.Create will overwrite the file if it already exists.
            try
            {
                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.FileStream fs = System.IO.File.Create(pathString);
                }

                using (StreamWriter w = File.AppendText(pathString))
                {
                    Log(errorMessage, innerExp, w);
                }

            }
            catch(Exception) { }
            


        }

        public static void Log(string logMessage, string innerExp, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine(" Inner exception: {0}", innerExp);
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("---------------------------------------");
            }
            catch (Exception)
            {
            }
        }
    }
}
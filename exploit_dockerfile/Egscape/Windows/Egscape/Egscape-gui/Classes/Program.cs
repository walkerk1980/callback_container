using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Egscape_gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Egscape", "Egscape.log");
            string dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Egscape");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                File.Create(logPath).Close();
            }
            else
            {
                if (!File.Exists(logPath))
                {
                    File.Create(logPath).Close();
                }
                else
                {
                    File.Delete(logPath);
                    File.Create(logPath).Close();
                }
            }
            
            Application.Run(new EgscapeMainForm());
        }
    }
}

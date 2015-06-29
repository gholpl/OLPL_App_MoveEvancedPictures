using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OLPL_App_MoveEvancedPictures
{
    class Program
    {

        static void Main(string[] args)
        {
            Settings st1 = new Settings();
            st1 = Settings_Functions.getSettings();
            foreach(string fl in Directory.GetFiles(st1.folder_source))
            {
                string filename = fl.Replace(st1.folder_source + '\\', "");
                if (File.Exists(st1.folder_target + "\\" + filename))
                {
                    
                    if (File.GetCreationTime(fl)>File.GetCreationTime(st1.folder_target + "\\" + filename))
                    {
                        File.Delete(st1.folder_target + "\\" + filename);
                        File.Move(fl, st1.folder_target + "\\" + filename);
                        Console.WriteLine("New version of the File Moved" + Environment.NewLine);
                    }
                    else { File.Delete(fl); }
                }
                else
                {

                    File.Move(fl, st1.folder_target + "\\" + filename);
                    Console.WriteLine("New File Moved" + Environment.NewLine);
                }
                
            }
            Thread.Sleep(2000);
        }
    }
}

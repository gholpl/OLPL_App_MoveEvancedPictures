using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLPL_App_MoveEvancedPictures
{
    public class Settings
    {
        public string folder_source { get; set; }
        public string folder_target { get; set; }
    }
    public class Settings_Functions
    {
        public static Settings getSettings()
        {
            Settings st1 = new Settings();
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string[] SettingMain = File.ReadAllLines(Path.GetDirectoryName(path) + "\\settings.ini");
            st1.folder_source = getSettingINI(SettingMain, "folder.source");
            st1.folder_target = getSettingINI(SettingMain, "folder.destination");
            return st1;
        }
        public static string getSettingINI(string[] str, string strName)
        {
            foreach (string str1 in str)
            {
                if (str1.Contains(strName))
                {
                    return str1.Split('=')[1];
                }
            }
            return "none";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Apresentacao
{
    public class IniFile
    {
        // Declara dll para trabalhar com arquivos ini
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string filePath(string fileName)
        {
            String strAppDir;
            //String strAppDir = Application.StartupPath;
            //this.fileName = strAppDir + "\\" + fileName;
            strAppDir = Application.StartupPath + "\\" + fileName;

            return strAppDir;
        }
        public string IniReadString(string Section, string Key, string filePath)
        {
            //this.fileName
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filePath);
            return temp.ToString();
        }
    }
}

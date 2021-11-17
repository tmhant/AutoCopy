using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoCopy
{
    class Ini
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 讀取ini
        /// </summary>
        /// <param name="group">資料分組</param>
        /// <param name="key">關鍵字</param>
        /// <param name="default_value"></param>
        /// <param name="filepath">ini檔案地址</param>
        /// <returns>關鍵字對應的值，沒有時用預設值</returns>
        public static string readini(string group, string key, string default_value, string filepath)
        {
            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString(group, key, default_value, temp, 255, filepath);
            return temp.ToString();
        }

        /// <summary>
        /// 儲存ini
        /// </summary>
        /// <param name="group">資料分組</param>
        /// <param name="key">關鍵字</param>
        /// <param name="value">關鍵字對應的值</param>
        /// <param name="filepath">ini檔案地址</param>
        public static void writeini(string group, string key, string value, string filepath)
        {
            WritePrivateProfileString(group, key, value, filepath);
        }
    }

    
}

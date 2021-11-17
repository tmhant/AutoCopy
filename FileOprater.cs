using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AutoCopy
{
    class FileOprater
    {
        public FileOprater() { }
        /// <summary>
        /// 讀取路徑上的檔案列表
        /// </summary>
        /// <param name="Path">檔案路徑</param>
        /// <param name="compare"> == 或者 >= </param>
        /// <param name="days">用numberUpDown的值</param>
        /// <returns></returns>
        public ArrayList getFileList(string Path, string compare, int days = 0)
        {
            try
            {
                string[] dir = Directory.GetFiles(Path);
                ArrayList _fileList = new ArrayList();
                for (int dirIndex = 0; dirIndex < dir.Length; dirIndex++)
                {
                    DateTime fileLastWriteTime = File.GetLastWriteTime(dir[dirIndex].ToString());
                    TimeSpan timespan = DateTime.Today.Date - fileLastWriteTime.Date;
                    if (compare == "==")
                    {
                        if (timespan.Days == 0)
                        {
                            _fileList.Add(dir[dirIndex].ToString());
                        }
                    }
                    else
                    {
                        //TimeSpan timespan = DateTime.Today.Date - fileLastWriteTime.Date;
                        if (timespan.Days >= days)
                        {
                            _fileList.Add(dir[dirIndex].ToString());
                        }
                    }

                }
                return _fileList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }

        }

        /// <summary>
        /// 拷貝檔案，用FileStream buffer來寫入，大檔案也沒問題
        /// </summary>
        /// <param name="SourcePath">原始檔路徑</param>
        /// <param name="DestinyPath">目標檔案路徑</param>
        public void CopyFiles(string SourcePath, string DestinyPath)
        { //1建立一個負責讀取的流
            using (FileStream fsRead = new FileStream(SourcePath, FileMode.Open, FileAccess.Read))
            {//建立一個負責寫入的流
                using (FileStream fsWrite = new FileStream(DestinyPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    while (true)
                    {
                        int r = fsRead.Read(buffer, 0, buffer.Length);
                        //如果返回一個0，就意味什麼都沒有讀取到，讀取完了
                        if (r == 0)
                        {
                            break;
                        }
                        fsWrite.Write(buffer, 0, r);
                    }
                }

            }

        }

        public void DeleteFiles(string Path)
        {
            File.Delete(Path);

        }

    }
}

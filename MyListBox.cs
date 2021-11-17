using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace AutoCopy
{
    class MyListBox
    {
        public MyListBox() { }
        internal Boolean showFilesList(ArrayList fileList, ListBox listbox)
        {
            //定義陣列，用於儲存檔案路徑
            if (fileList != null)
            {
                for (int index = 0; index < fileList.Count; index++)
                {
                    listbox.Items.Add(fileList[index].ToString());
                }
                return true;
            }
            else
                return false;

        }

    }
}
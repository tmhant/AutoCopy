using NLog;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCopy
{
    public partial class Form1 : Form
    {
        private int _checkInterval = 0;
        DateTime _time;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private bool flag = false;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            txt_source.Text = Ini.readini("group1", "source", "C:\\backup", ".\\set.ini");
            txt_target.Text = Ini.readini("group1", "destiny", "D:\\backup", ".\\set.ini");
            cb_hour.Text = Ini.readini("group1", "hour", "12", ".\\set.ini");
            cb_minute.Text = Ini.readini("group1", "minute", "00", ".\\set.ini");
            _time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            toolStripStatusLabel1.Text = _time.ToString("HH:mm:ss");
        }

        private void btn_source_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txt_source.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_target_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txt_target.Text = folderBrowserDialog1.SelectedPath;
        }

        protected void OnStart(object sender, EventArgs e)
        {
            flag = true;
            backup(sender, e);
            timer1.Tick += backup;
            timer2.Tick += Timer2_Tick;
            _checkInterval = Convert.ToInt16(cb_hour.Text) * 24 * 60 + Convert.ToInt16(cb_minute.Text) * 60;
            timer1.Interval = _checkInterval * 1000;
            timer2.Interval = 1000;
            //_timer.AutoReset = true;
            timer1.Enabled = true;
            timer1.Start();
            timer2.Enabled = true;
            timer2.Start();
            btn_backup.Enabled = false;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            _time = _time.AddSeconds(-1);
            toolStripStatusLabel1.Text = _time.ToString("HH:mm:ss");
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            flag = false;
            timer1.Stop();
            timer1.Dispose();
            timer2.Stop();
            timer2.Dispose();
            toolStripStatusLabel2.Text = "停止備份";
            btn_backup.Enabled = true;
            btn_stop.Enabled = false;
        }

        //新建FileOprater物件
        private async void backup(object sender, EventArgs e)
        {
            try
            {
                DateTime sdate = DateTime.Now;
                string sourceDirectory = txt_source.Text;
                string targetDirectory = txt_target.Text;
                if (sourceDirectory.ToLower() == targetDirectory.ToLower())
                {
                    Console.WriteLine("來源目錄和備份目錄不能是同一目錄！");
                    MessageBox.Show("來源目錄和備份目錄不能是同一目錄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);  // 來源目錄
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);  // 備份目錄
                if (diTarget.Name != diSource.Name)
                    diTarget = new DirectoryInfo(Path.Combine(diTarget.FullName, diSource.Name));  // 建立同名目錄
                if (!diTarget.Exists) diTarget.Create();  // 如果該目錄已存在，則此方法不執行任何操作
                btn_backup.Enabled = false;
                txt_source.Enabled = false;
                txt_target.Enabled = false;
                if (!timer1.Enabled)
                    toolStripStatusLabel2.Text = "備份開始！";

                bool result = await Task.Run(() => CopyAllAsync(diSource, diTarget));
                if (result)
                {
                    DateTime edate = DateTime.Now;
                    toolStripStatusLabel2.Text = string.Format("備份完成！花費時間：{0}", DateDiff(sdate, edate));
                    //MessageBox.Show("備份完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt16(cb_hour.Text), Convert.ToInt16(cb_minute.Text), 0);
                    toolStripStatusLabel1.Text = _time.ToString("HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                //toolStripStatusLabel2.Text = string.Format("出現錯誤！{0}", ex.Message);
                logger.Error(ex.Message);
            }
        }

        public async Task<bool> CopyAllAsync(DirectoryInfo source, DirectoryInfo target)
        {
            if (!flag) return false;
            try
            {
                foreach (FileInfo fi in source.GetFiles())  // 複製最新檔案
                {
                    Console.WriteLine(@"準備複製檔案 {0}\{1}", target.FullName, fi.Name);  // Name不含路徑，僅檔名
                    FileInfo newfi = new FileInfo(Path.Combine(target.FullName, fi.Name));
                    if (!newfi.Exists || (newfi.Exists && fi.LastWriteTime > newfi.LastWriteTime))
                    {
                        Console.WriteLine("正在複製檔案 {0}", newfi.FullName);
                        toolStripStatusLabel2.Text = string.Format("正在複製檔案 {0}", newfi.FullName);
                        if (newfi.Exists && newfi.IsReadOnly) newfi.IsReadOnly = false;
                        // 覆蓋或刪除只讀檔案會產生異常：對路徑“XXX”的訪問被拒絕
                        fi.CopyTo(newfi.FullName, true);  // Copy each file into it's new directory
                    }
                }
                //foreach (FileInfo fi2 in target.GetFiles())  // 刪除來源目錄沒有而目標目錄中有的檔案
                //{
                //    FileInfo newfi2 = new FileInfo(Path.Combine(source.FullName, fi2.Name));
                //    if (!newfi2.Exists)
                //    {
                //        Console.WriteLine("正在刪除檔案 {0}", fi2.FullName);
                //        toolStripStatusLabel2.Text = string.Format("正在刪除檔案 {0}", fi2.FullName);
                //        if (fi2.IsReadOnly) fi2.IsReadOnly = false;
                //        fi2.Delete();  // 沒有許可權(如系統盤需管理員許可權)會產生異常，檔案不存在不會產生異常
                //    }
                //}


                foreach (DirectoryInfo di in source.GetDirectories())  // 複製目錄(實際上是建立同名目錄，和來源目錄的屬性不同步)
                {
                    Console.WriteLine(" {0} {1}", di.FullName, di.Name);  // Name不含路徑，僅本級目錄名
                    Console.WriteLine(@"準備建立目錄 {0}\{1}", di.FullName, di.Name);
                    DirectoryInfo newdi = new DirectoryInfo(Path.Combine(target.FullName, di.Name));
                    if (!newdi.Exists)  // 如果CopyAllAsync放在if裡的bug: 只要存在同名目錄，則不會進行子目錄和子檔案的檢查和更新
                    {
                        Console.WriteLine("正在建立目錄 {0}", newdi.FullName);
                        toolStripStatusLabel2.Text = string.Format("正在複製目錄 {0}", newdi.FullName);
                        DirectoryInfo diTargetSubDir = target.CreateSubdirectory(di.Name);  // 建立目錄
                        Console.WriteLine("完成建立目錄 {0}", diTargetSubDir.FullName);
                    }
                    if (await CopyAllAsync(di, newdi) == false) return false; ;  // Copy each subdirectory using recursion
                }
                //foreach (DirectoryInfo di2 in target.GetDirectories())  // 刪除來源目錄沒有而目標目錄中有的目錄(及其子目錄和檔案)
                //{
                //    DirectoryInfo newdi2 = new DirectoryInfo(Path.Combine(source.FullName, di2.Name));
                //    if (!newdi2.Exists)
                //    {
                //        Console.WriteLine("正在刪除目錄 {0}", di2.FullName);
                //        toolStripStatusLabel2.Text = string.Format("正在刪除目錄 {0}", di2.FullName);
                //        di2.Delete(true);  // 只讀的目錄和檔案也能刪除，如不使用引數則異常"目錄不是空的"
                //    }
                //}
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                toolStripStatusLabel2.Text = string.Format("出現錯誤！{0}", e.Message);
                return true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Ini.writeini("group1", "source", txt_source.Text.Trim(), ".\\set.ini");
            Ini.writeini("group1", "destiny", txt_target.Text.Trim(), ".\\set.ini");
            Ini.writeini("group1", "hour", cb_hour.Text.Trim(), ".\\set.ini");
            Ini.writeini("group1", "minute", cb_minute.Text.Trim(), ".\\set.ini");
        }

        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new
            TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            //dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小時" + ts.Minutes.ToString() + "分鐘" + ts.Seconds.ToString() + "秒";
            dateDiff = ts.Hours.ToString() + "小時" + ts.Minutes.ToString() + "分鐘" + ts.Seconds.ToString() + "秒";
            return dateDiff;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (timer1 != null)
                timer1.Stop();
            Application.Exit();
        }
    }
}


namespace AutoCopy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_source = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_source = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_target = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_target = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_hour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_minute = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(85, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "來源：";
            // 
            // txt_source
            // 
            this.txt_source.Location = new System.Drawing.Point(158, 56);
            this.txt_source.Name = "txt_source";
            this.txt_source.Size = new System.Drawing.Size(494, 23);
            this.txt_source.TabIndex = 1;
            // 
            // btn_source
            // 
            this.btn_source.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_source.Location = new System.Drawing.Point(673, 48);
            this.btn_source.Name = "btn_source";
            this.btn_source.Size = new System.Drawing.Size(75, 40);
            this.btn_source.TabIndex = 2;
            this.btn_source.Text = "瀏覽";
            this.btn_source.UseVisualStyleBackColor = true;
            this.btn_source.Click += new System.EventHandler(this.btn_source_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(85, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "目的：";
            // 
            // txt_target
            // 
            this.txt_target.Location = new System.Drawing.Point(158, 121);
            this.txt_target.Name = "txt_target";
            this.txt_target.Size = new System.Drawing.Size(494, 23);
            this.txt_target.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 255);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(935, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // btn_backup
            // 
            this.btn_backup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_backup.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_backup.Location = new System.Drawing.Point(766, 48);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(100, 108);
            this.btn_backup.TabIndex = 6;
            this.btn_backup.Text = "立即備份";
            this.btn_backup.UseVisualStyleBackColor = false;
            this.btn_backup.Click += new System.EventHandler(this.OnStart);
            // 
            // btn_target
            // 
            this.btn_target.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_target.Location = new System.Drawing.Point(673, 117);
            this.btn_target.Name = "btn_target";
            this.btn_target.Size = new System.Drawing.Size(75, 39);
            this.btn_target.TabIndex = 7;
            this.btn_target.Text = "瀏覽";
            this.btn_target.UseVisualStyleBackColor = true;
            this.btn_target.Click += new System.EventHandler(this.btn_target_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_save.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_save.Location = new System.Drawing.Point(401, 193);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(87, 41);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "儲存設定";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(85, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "定時備份：";
            // 
            // cb_hour
            // 
            this.cb_hour.FormattingEnabled = true;
            this.cb_hour.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cb_hour.Location = new System.Drawing.Point(197, 201);
            this.cb_hour.Name = "cb_hour";
            this.cb_hour.Size = new System.Drawing.Size(53, 23);
            this.cb_hour.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(256, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "時";
            // 
            // cb_minute
            // 
            this.cb_minute.FormattingEnabled = true;
            this.cb_minute.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.cb_minute.Location = new System.Drawing.Point(292, 201);
            this.cb_minute.Name = "cb_minute";
            this.cb_minute.Size = new System.Drawing.Size(51, 23);
            this.cb_minute.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(349, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "分";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.Info;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_exit.Location = new System.Drawing.Point(673, 194);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 41);
            this.btn_exit.TabIndex = 15;
            this.btn_exit.Text = "離開";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_stop.Location = new System.Drawing.Point(766, 193);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(100, 41);
            this.btn_stop.TabIndex = 16;
            this.btn_stop.Text = "停止備份";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 277);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_minute);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_hour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_target);
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt_target);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_source);
            this.Controls.Add(this.txt_source);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "資料備份";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_source;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_source;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_target;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_target;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_hour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_minute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btn_stop;
    }
}



namespace gooditem
{
    partial class CsvChangeMgr
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            this.ChangeCsv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CsvOpen = new System.Windows.Forms.OpenFileDialog();
            this.DialogOpen = new System.Windows.Forms.Button();
            this.CsvDialogName = new System.Windows.Forms.TextBox();
            this.ABtest = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._day = new System.Windows.Forms.ComboBox();
            this.RealCsvPath = new System.Windows.Forms.TextBox();
            this.SaveCsvButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CsvFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ExcelTest = new System.Windows.Forms.Button();
            this.ExcelFIleReader = new System.Windows.Forms.OpenFileDialog();
            this.ExcelPath = new System.Windows.Forms.TextBox();
            this.ExcelModify = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.RichTextCheckbox = new System.Windows.Forms.CheckBox();
            this.AdjustedBox = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ChangeCsv
            // 
            this.ChangeCsv.BackColor = System.Drawing.Color.White;
            this.ChangeCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeCsv.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChangeCsv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChangeCsv.Location = new System.Drawing.Point(224, 266);
            this.ChangeCsv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChangeCsv.Name = "ChangeCsv";
            this.ChangeCsv.Size = new System.Drawing.Size(107, 32);
            this.ChangeCsv.TabIndex = 0;
            this.ChangeCsv.Text = "Csv转译";
            this.ChangeCsv.UseVisualStyleBackColor = false;
            this.ChangeCsv.Click += new System.EventHandler(this.ChangeCsv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择Csv文件";
            // 
            // CsvOpen
            // 
            this.CsvOpen.Filter = "CSV UTF-8(*.csv)|*.csv";
            // 
            // DialogOpen
            // 
            this.DialogOpen.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.DialogOpen.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DialogOpen.Location = new System.Drawing.Point(452, 121);
            this.DialogOpen.Margin = new System.Windows.Forms.Padding(4);
            this.DialogOpen.Name = "DialogOpen";
            this.DialogOpen.Size = new System.Drawing.Size(61, 28);
            this.DialogOpen.TabIndex = 3;
            this.DialogOpen.Text = "..";
            this.DialogOpen.UseVisualStyleBackColor = true;
            this.DialogOpen.Click += new System.EventHandler(this.DialogOpen_Click);
            // 
            // CsvDialogName
            // 
            this.CsvDialogName.BackColor = System.Drawing.Color.White;
            this.CsvDialogName.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CsvDialogName.Location = new System.Drawing.Point(47, 121);
            this.CsvDialogName.Margin = new System.Windows.Forms.Padding(4);
            this.CsvDialogName.Name = "CsvDialogName";
            this.CsvDialogName.ReadOnly = true;
            this.CsvDialogName.Size = new System.Drawing.Size(377, 28);
            this.CsvDialogName.TabIndex = 4;
            // 
            // ABtest
            // 
            this.ABtest.CausesValidation = false;
            this.ABtest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ABtest.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ABtest.FormattingEnabled = true;
            this.ABtest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ABtest.Items.AddRange(new object[] {
            "O",
            "A",
            "B"});
            this.ABtest.Location = new System.Drawing.Point(113, 214);
            this.ABtest.Name = "ABtest";
            this.ABtest.Size = new System.Drawing.Size(82, 27);
            this.ABtest.TabIndex = 6;
            this.ABtest.SelectedIndexChanged += new System.EventHandler(this.ABtest_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "AB组";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(220, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Day";
            // 
            // _day
            // 
            this._day.CausesValidation = false;
            this._day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._day.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._day.FormattingEnabled = true;
            this._day.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._day.Items.AddRange(new object[] {
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
            "19"});
            this._day.Location = new System.Drawing.Point(265, 214);
            this._day.Name = "_day";
            this._day.Size = new System.Drawing.Size(82, 27);
            this._day.TabIndex = 9;
            this._day.SelectedIndexChanged += new System.EventHandler(this.Day_SelectedIndexChanged);
            // 
            // RealCsvPath
            // 
            this.RealCsvPath.BackColor = System.Drawing.Color.White;
            this.RealCsvPath.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RealCsvPath.Location = new System.Drawing.Point(47, 179);
            this.RealCsvPath.Margin = new System.Windows.Forms.Padding(4);
            this.RealCsvPath.Name = "RealCsvPath";
            this.RealCsvPath.ReadOnly = true;
            this.RealCsvPath.Size = new System.Drawing.Size(377, 28);
            this.RealCsvPath.TabIndex = 13;
            // 
            // SaveCsvButton
            // 
            this.SaveCsvButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.SaveCsvButton.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveCsvButton.Location = new System.Drawing.Point(452, 179);
            this.SaveCsvButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveCsvButton.Name = "SaveCsvButton";
            this.SaveCsvButton.Size = new System.Drawing.Size(61, 28);
            this.SaveCsvButton.TabIndex = 14;
            this.SaveCsvButton.Text = "..";
            this.SaveCsvButton.UseVisualStyleBackColor = true;
            this.SaveCsvButton.Click += new System.EventHandler(this.SaveCsvButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(47, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "保存路径";
            // 
            // ExcelTest
            // 
            this.ExcelTest.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.ExcelTest.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExcelTest.Location = new System.Drawing.Point(452, 66);
            this.ExcelTest.Margin = new System.Windows.Forms.Padding(4);
            this.ExcelTest.Name = "ExcelTest";
            this.ExcelTest.Size = new System.Drawing.Size(61, 28);
            this.ExcelTest.TabIndex = 16;
            this.ExcelTest.Text = "Excel";
            this.ExcelTest.UseVisualStyleBackColor = true;
            this.ExcelTest.Click += new System.EventHandler(this.ExcelTest_Click);
            // 
            // ExcelFIleReader
            // 
            this.ExcelFIleReader.Filter = "Excel(*.xlsx)|*.xlsx";
            // 
            // ExcelPath
            // 
            this.ExcelPath.BackColor = System.Drawing.Color.White;
            this.ExcelPath.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExcelPath.Location = new System.Drawing.Point(47, 66);
            this.ExcelPath.Margin = new System.Windows.Forms.Padding(4);
            this.ExcelPath.Name = "ExcelPath";
            this.ExcelPath.ReadOnly = true;
            this.ExcelPath.Size = new System.Drawing.Size(377, 28);
            this.ExcelPath.TabIndex = 17;
            // 
            // ExcelModify
            // 
            this.ExcelModify.BackColor = System.Drawing.Color.White;
            this.ExcelModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExcelModify.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExcelModify.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ExcelModify.Location = new System.Drawing.Point(52, 266);
            this.ExcelModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExcelModify.Name = "ExcelModify";
            this.ExcelModify.Size = new System.Drawing.Size(107, 32);
            this.ExcelModify.TabIndex = 18;
            this.ExcelModify.Text = "Excel2Csv";
            this.ExcelModify.UseVisualStyleBackColor = false;
            this.ExcelModify.Click += new System.EventHandler(this.ExcelModify_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(47, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "选择Excel文件转成Csv";
            // 
            // RichTextCheckbox
            // 
            this.RichTextCheckbox.AutoSize = true;
            this.RichTextCheckbox.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichTextCheckbox.Location = new System.Drawing.Point(377, 245);
            this.RichTextCheckbox.Name = "RichTextCheckbox";
            this.RichTextCheckbox.Size = new System.Drawing.Size(126, 23);
            this.RichTextCheckbox.TabIndex = 21;
            this.RichTextCheckbox.Text = "富文本处理";
            this.RichTextCheckbox.UseVisualStyleBackColor = true;
            // 
            // AdjustedBox
            // 
            this.AdjustedBox.AutoSize = true;
            this.AdjustedBox.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AdjustedBox.Location = new System.Drawing.Point(377, 216);
            this.AdjustedBox.Name = "AdjustedBox";
            this.AdjustedBox.Size = new System.Drawing.Size(111, 23);
            this.AdjustedBox.TabIndex = 20;
            this.AdjustedBox.Text = "Adjusted?";
            this.AdjustedBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("等线", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(47, 312);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(202, 19);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "点击前往Excel文档网址";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CsvChangeMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(526, 356);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.RichTextCheckbox);
            this.Controls.Add(this.AdjustedBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExcelModify);
            this.Controls.Add(this.ExcelPath);
            this.Controls.Add(this.ExcelTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SaveCsvButton);
            this.Controls.Add(this.RealCsvPath);
            this.Controls.Add(this._day);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ABtest);
            this.Controls.Add(this.CsvDialogName);
            this.Controls.Add(this.DialogOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangeCsv);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CsvChangeMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CsvDesigner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button ChangeCsv;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.OpenFileDialog CsvOpen;
        public System.Windows.Forms.Button DialogOpen;
        public System.Windows.Forms.TextBox CsvDialogName;
        public System.Windows.Forms.ComboBox ABtest;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox _day;
        public System.Windows.Forms.TextBox RealCsvPath;
        public System.Windows.Forms.Button SaveCsvButton;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.FolderBrowserDialog CsvFolder;
        public System.Windows.Forms.Button ExcelTest;
        public System.Windows.Forms.OpenFileDialog ExcelFIleReader;
        public System.Windows.Forms.TextBox ExcelPath;
        public System.Windows.Forms.Button ExcelModify;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox RichTextCheckbox;
        public System.Windows.Forms.CheckBox AdjustedBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}


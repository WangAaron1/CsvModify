using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace gooditem
{
    public partial class CsvChangeMgr : Form
    {
        private int             _currentIndex = 0;
        private int             _typeNum = 1;           //调整抬头
        private char            _suffixString = 'A';    //通过递增实现A-Z
        private string[]        _realCsvData;
        private string          _indexNum;              //索引用来区分不同的任务ID
        public string           _csvName;               //Csv创建时的名称
        private string          _suffixNumber = "01";
        private bool            _isTrans;


        private List<MilaScirpt>                _commentData;
        private static Dictionary<int, string>  _commentType = new Dictionary<int, string>() { { 1, "Main" }, { 2, "After" } };
        private static Dictionary<string, int>  _abType = new Dictionary<string, int>() { { "O", 1 }, { "A", 2 }, { "B", 3 } };
        private Excel2Csv                       _excelWriter = new Excel2Csv();
        public  ProgressBox                     _ProgressWriter = new ProgressBox();

        public CsvChangeMgr()
        {
            InitializeComponent();
        }
        //初始化后缀
        public void InitSuffixNum()
        {
            _suffixString = 'A';
            _suffixNumber = "01";
            _currentIndex = 0;
            _typeNum = 1;
        }
        private void ChangeCsv_Click(object sender, EventArgs e)
        {
            if (CsvOpen.FileName.Length == 0)
            {
                MessageBox.Show("请选择一个CsV！", "Error");
                return;
            }
            if (CsvFolder.SelectedPath.Length == 0)
            {
                MessageBox.Show("请选择一个保存路径！", "Error");
                return;
            }
            InitSuffixNum();
            var _csvData = File.ReadAllLines(CsvOpen.FileName);
            _realCsvData = _csvData;
            _commentData = new List<MilaScirpt>(_realCsvData.Length);
            for (int i = 0; i < _realCsvData.Length; i++)
            {
                var ms = new MilaScirpt();
                var line = _realCsvData[i];
                var sp = line.Split(',');

                //用Task来分割index
                if (sp[0].Contains($"Task {Convert.ToInt32(_day.Text)}"))
                {
                    FindTaskNum(sp[0]);
                    continue;
                }

                //有一种是过渡路图的可能性

                if (sp[0].Contains("Transitional Task"))
                {
                    _suffixNumber = "01";
                    _typeNum = 2;
                    _isTrans = true;
                }




                //sp[0]是检测CommentNode
                if (!_isTrans && sp[0] == "CommentNode" && _currentIndex != 0)
                {
                    IfIsCommentNode(sp[0], ms, _realCsvData[i]);
                    continue;
                }
                //检测After后置对话
                if (!_isTrans && sp[0] == "BubbleTalk")
                {
                    ms.milaType = MilaScirptType.bubble;
                    var _textLoad = line.Substring(12);
                    if (_textLoad.Length == 1)
                    {
                        continue;
                    }
                    ms.text = _textLoad;
                    ms.key = $"After{_abType[ABtest.Text]}{_indexNum}_{_suffixNumber}";
                    _commentData.Add(ms);
                    var number = Convert.ToInt32(_suffixNumber);
                    number++;
                    if (number < 10)
                    {
                        _suffixNumber = string.Concat("0", number);
                    }
                    continue;
                }
                //重置文本开头字母
                if (sp[0].Contains("NEW TASK!"))
                {
                    continue;
                }
                if (sp[0].Contains("Post Task"))
                {
                    if (!_isTrans)
                    {
                        _typeNum = 1;
                        _suffixNumber = "01";
                        _suffixString = 'A';
                    }
                    continue;
                }

                if (_isTrans && _currentIndex != 0)
                {
                    if (sp[0] == "CommentNode" || sp[0] == "BubbleTalk")
                    {
                        IfIsCommentNode(sp[0], ms, _realCsvData[i]);
                    }
                    continue;
                }
                else
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    var bp = _realCsvData[i - 1].Split(',');
                    if (bp[0] == "CommentNode")
                    {
                        _suffixString++;
                        _suffixNumber = "01";
                    }
                    continue;
                }

            }
            //数据整合好后的写入处理
            if (_commentData != null)
            {
                WriteData2Csv();
            }
        }

        #region 找到Task后的处理方法
        public void FindTaskNum(string sp)
        {

            _isTrans = false;
            var where = sp.Trim();

            var num = where.Substring(5);

            var spNum = num.Split(' ');
            var taskNum = spNum[0].Split('-');

            if (Convert.ToInt32(taskNum[0]) < 10)
            {
                taskNum[0] = string.Concat("0", taskNum[0]);
            }
            _indexNum = string.Concat(taskNum[0], taskNum[1]);
            _suffixNumber = "01";
            _suffixString = 'A';
            _typeNum = 1;

            IdentifyNumber(_indexNum, out var _realNum);
            _indexNum = _realNum;
            _currentIndex = Convert.ToInt32(_realNum);
        }
        #endregion

        #region 数据写入处理 还是剥离出来好点
        public void WriteData2Csv()
        {
            _csvName = $"{ABtest.Text}组-Day{_day.Text}文本配置.csv";
            string[] _realCsvData = new string[_commentData.Count];
            for (int i = 0; i < _commentData.Count; i++)
            {
                _realCsvData[i] = $"{_commentData[i].key},,{_commentData[i].text}";
            }
            if (File.Exists($"{RealCsvPath.Text}\\{_csvName}"))
            {
                File.WriteAllLines($"{RealCsvPath.Text}\\{_csvName}", _realCsvData, Encoding.UTF8);
            }
            else
            {
                FileStream S = new FileStream($"{RealCsvPath.Text}\\{_csvName}", FileMode.Create);
                S.Close();
                File.WriteAllLines($"{RealCsvPath.Text}\\{_csvName}", _realCsvData, Encoding.UTF8);

            }
            MessageBox.Show("搞定", "文本转换完成");
            System.Diagnostics.Process.Start($"{RealCsvPath.Text}\\");
            System.Diagnostics.Process.Start($"{RealCsvPath.Text}\\{_csvName}");
        }

        #endregion

        private void DialogOpen_Click(object sender, EventArgs e)
        {
            CsvOpen.DefaultExt = ".csv";
            CsvOpen.Title = "Csv";
            if (CsvOpen.ShowDialog() == DialogResult.OK)
            {
                CsvDialogName.Text = CsvOpen.FileName;
            }
        }
        public class MilaScirpt
        {
            public MilaScirptType milaType;     //文本类型
            public int index;                   //索引
            //public int subIndex;
            public string key;                  //抬头
            public string text;                 //文本
        }
        public enum MilaScirptType
        {
            comment,
            bubble
        }
        private void Day_SelectedIndexChanged(object sender, EventArgs e)
        {
            _csvName = $"{ABtest.Text}组-Day{_day.Text}文本配置.csv";
        }

        private void ABtest_SelectedIndexChanged(object sender, EventArgs e)
        {
            _csvName = $"{ABtest.Text}组-Day{_day.Text}文本配置.csv";
        }

        private void SaveCsvButton_Click(object sender, EventArgs e)
        {

            if (CsvFolder.ShowDialog() == DialogResult.OK)
            {
                RealCsvPath.Text = CsvFolder.SelectedPath;
            }
        }

        private void ExcelTest_Click(object sender, EventArgs e)
        {

            if (ExcelFIleReader.ShowDialog() == DialogResult.OK)
            {
                ExcelPath.Text = ExcelFIleReader.FileName;
            }
            else
            {
                return;
            }
        }

        private void ExcelModify_Click(object sender, EventArgs e)
        {
            if (RealCsvPath.Text.Length == 0)
            {
                MessageBox.Show("请选择保存路径");
                return;
            }
            _excelWriter.LoadAndWrite(this,_ProgressWriter);
            CsvOpen.FileName = $"{RealCsvPath.Text}\\{_csvName}";
            CsvDialogName.Text = $"{RealCsvPath.Text}\\{_csvName}";
        }

        #region 检测CommentNode
        public void IfIsCommentNode(string sp, MilaScirpt _mila, string line)
        {
            var idx = Convert.ToChar(_suffixString);
            var textSuffix = $"{idx}{_suffixNumber}";
            string _textLoad = line.Substring(13).Trim();
            if (line.Contains("CommentNode"))
            {
                _textLoad = line.Substring(13).Trim();
            }
            if (line.Contains("BubbleTalk"))
            {
                _textLoad = line.Substring(12).Trim();
            }
            if (_textLoad.Length == 1 || _textLoad.Length == 0)
            {
                return;
            }
            _mila.index = _currentIndex;
            _mila.key = $"{_commentType[_typeNum]}{_abType[ABtest.Text]}{_indexNum}_{textSuffix}";
            _mila.text = _textLoad;
            _commentData.Add(_mila);
            var number = Convert.ToInt32(_suffixNumber);
            number++;
            if (number < 10)
            {
                _suffixNumber = string.Concat("0", number);
            }
            if (number >= 10)
            {
                _suffixNumber = number.ToString() ;
            }
        }
        #endregion


        #region 检测是否为纯数字 并out出纯数字字符串
        public void IdentifyNumber(string _num,out string realnum)
        {
            foreach (char s in _num)
            {
                if (s >= '0' && s <= '9')
                {
                    continue;
                }
                else
                {
                    _num = _num.Replace(s, '\0');
                }
            }
            realnum = _num;
        }

        #endregion

        private void label6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/spreadsheets/d/1DFkFl6KTRm-udsgJ4w3XsU0CEFa9VY9Cf7gKYLyqEfk/edit#gid=0");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;


namespace gooditem
{
    public partial class Excel2Csv
    {
        public   dynamic    _sheet;
        public   int        _whichSheet;
        public   string[]   _csvData;
        public   string     _csvText;
        public   string     _sheetName;
        public   string     _csvKey;
        public   string     _endOfDay;
        readonly string     _richSuffix     = "<color=#17aa4b><b>";
        readonly string     _richSuffixNext = "</b></color>";
        readonly string     _boldSuffix     = "<b>";
        readonly string     _boldSuffixNext = "</b>";
        readonly double     _richDcolor     = 16711680.0;

        public   Characters   _richinfo;
        public   Range        _commentKey;
        public   Range        _commentText;


        private List<RichText> _richData;
        private List<BoldText> _boldData;

        public void LoadAndWrite(CsvChangeMgr _form, ProgressBox progress)
        {
            Application _milaApp = new Application();
            var _loading = progress.progressBar1;
            //获取工作簿
            var _selfBook = _milaApp.Workbooks;
            var _milabook = _selfBook.Open(_form.ExcelFIleReader.FileName);

            //拿到每个工作簿的名称
            Sheets _allSheets = _milabook.Sheets;

            //遍历所有工作簿名称，定位需要使用的具体工作簿
            for (int i = 1; i < _allSheets.Count; i++)
            {
                _sheet = _allSheets[i];
                _sheetName = _sheet.Name;

                //解决Adjust区别的表的问题 默认抓没有后缀的版本，现在还需要加上PH版本 所有要写方法了

                if (_form.AdjustedBox.Checked && _sheetName.Contains($"Day_{Convert.ToInt32(_form._day.Text)}")&& _sheetName.Contains("Adjusted"))
                {
                    _whichSheet = i;
                    break;
                }
                if (!_form.AdjustedBox.Checked && _sheetName.Contains($"Day_{Convert.ToInt32(_form._day.Text)}"))
                {
                    _whichSheet = i;
                    break;
                }
            }

            //拿到具体工作簿
            Worksheet _workSheet = _milabook.Worksheets[(int)_whichSheet];
            
            //显示进度条
            progress.Visible = true;

            //开始对具体工作簿进行操作
            //逐行读取单元格数据 [行,列]
            var _sheetCount = _workSheet.UsedRange;
            var  usedRowCount = _sheetCount.Rows.Count;
            var  usedCloumnsCount = _sheetCount.Columns.Count;
            
            //计算行数
            CaculateExcelRows(_sheetCount.Rows.Count, _workSheet,out  int _excelCount);


            //实例化需要的文本集合
            _csvData = new string[_excelCount];


            for (int i = 0; i < _excelCount; i++)
            {
                //初始化进度条长度，并不断调用方法增量
                _loading.Maximum = _excelCount;

                //类的数据存入的地方 __咽喉
                _commentKey  = (Range)_workSheet.Cells[i+1, 2];
                _commentText = (Range)_workSheet.Cells[i+1, 5];
                _csvKey  = _commentKey.Text;
                _csvText = _commentText.Text.Trim();

                //做一层检测文本中有两个空格的操作
                if (_csvText.Contains("  "))
                {
                    _csvText = _csvText.Replace("  "," ");
                }
                progress.CsvDataName.Text = _csvText;

                //逗号处理
                if (_csvText.Contains(","))
                {
                    _csvText = string.Concat("\"", _csvText, "\"");
                }
                //引号的处理
                var _csvss = _csvText.Trim('"');
                if (_csvss.Contains("\""))
                {
                    _csvss = _csvss.Replace("\"","\"\"");
                    _csvss = string.Concat("\"", _csvss, "\"");
                    _csvText = _csvss;
                }
                _boldData = new List<BoldText>();
                _richData = new List<RichText>();
                //逐个拿单元格中的文本字符(富文本处理 
                if (_form.RichTextCheckbox.Checked == true)
                {
                    RichTextDetective();
                }

                _csvData[i] = $"{_csvKey},,{_csvText}";
                _loading.PerformStep();

            }

            //先写进Csv 然后再操作Csv数据
            File.WriteAllLines($"{_form.RealCsvPath.Text}\\{_form._csvName}", _csvData,Encoding.UTF8);
            //WriteCsvData(_form,_csvData);
            //让进度条拜拜
            if (_loading.Value ==_loading.Maximum)
            {
                progress.Visible = false;
                _loading.Value = 0;

            }
            //释放
            CleanProgrm(_milabook,_milaApp,_selfBook, _allSheets, _workSheet, progress);
        }

        #region 清理缓存 释放Excel 保底删除进度条
        public void CleanProgrm(Workbook _book,Application _App,Workbooks _sBook,Sheets _sheets, Worksheet _workSheet,ProgressBox _loading)
        {
            _book.Close(true, Type.Missing, Type.Missing);
            _App.Quit();
            _App.Application.Quit();
            Marshal.ReleaseComObject(_sBook);
            Marshal.ReleaseComObject(_App);
            Marshal.ReleaseComObject(_workSheet);
            Marshal.ReleaseComObject(_sheets);
            Marshal.ReleaseComObject(_book);
            GC.Collect();
            _loading.progressBar1.Value = 0;
            _loading.Visible = false;
            GC.WaitForPendingFinalizers();
            _App = null;
        }
        #endregion

        #region 写入数据 先缓存在TxT然后进Csv 
        public void WriteCsvData(CsvChangeMgr _form,string[] _csvData)
        {
            var _csvPath = $"{_form.RealCsvPath.Text}\\测试用.txt";
            FileStream _newCsv = new FileStream(_csvPath, FileMode.Create);
            _newCsv.Close();
            File.WriteAllLines(_csvPath, _csvData);

            StreamReader sr = new StreamReader(_csvPath, Encoding.Default, false);
            string contenttxt = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(_csvPath, false, Encoding.UTF8);
            sw.Write(contenttxt);
            sw.Close();
            var _textData = File.ReadAllLines(_csvPath);
            File.WriteAllLines($"{_form.RealCsvPath.Text}\\{_form._csvName}", _textData, Encoding.UTF8);
        }
        #endregion

        #region 用来收集富文本信息的类
        private class RichText
        {
            public int[] _richNum = new int[3];
            public string _needRichText;
        }
        #endregion

        #region 用来收集粗体文本
        private class BoldText
        {
            public int[] _boldNum = new int[3];
            public string _needBoldText;
        }
        #endregion

        #region 处理富文本
        public void RichTextDetective()
        {
            int _Num = 0;
            var _firstColor = _commentText.Characters[1, 1].Font.Color;
            var _lastColor = _commentText.Characters[_commentText.Text.Length, 1].Font.Color;
            var _richNewData = new RichText();
            var _boldNewData = new BoldText();
            var _charaLength = _commentText.Text.Length+1;


            for (int i = 1; i <= _charaLength; i++)
            {
                var _richChara = _commentText.Characters[i, 1];
                var _richColor = _richChara.Font.Color;
                var _beforeChara = _commentText.Characters[i - 1, 1];
                var _charaBold = _richChara.Font.Bold;
                var _beforeColor = _beforeChara.Font.Color;
                //用于判断第一个字符是否为富文本
                if (_firstColor == _richDcolor && i==1)
                {
                    _richNewData._richNum[_Num] = i;
                    _Num++;
                    continue;
                }
                //用于判断加粗文本
                if (_charaBold && _richColor == 0 && _boldNewData._boldNum[0] == 0)
                {
                    _boldNewData._boldNum[0] = i;
                }
                if (_boldNewData._boldNum[0] != 0 && !_charaBold)
                {
                    _boldNewData._boldNum[1] = i;
                    var _needBold = _commentText.Characters[_boldNewData._boldNum[0], _boldNewData._boldNum[1] - _boldNewData._boldNum[0]];
                    _boldNewData._needBoldText = _needBold.Text;
                    _boldData.Add(_boldNewData);
                    _boldNewData = new BoldText();

                }
                //用于判断最后一个字符是否为富文本
                if (i == _charaLength && _richNewData._richNum[0] != 0 && _lastColor == _richDcolor)
                {
                    //if (_richNewData._richNum[1] != 0)
                    //{
                    //    return;
                    //}
                    _richNewData._richNum[1] = _charaLength;
                    _richinfo = _commentText.Characters[_richNewData._richNum[0], _richNewData._richNum[1] - _richNewData._richNum[0]];
                    _richNewData._needRichText = _richinfo.Text;
                    _richData.Add(_richNewData);
                    _richNewData = new RichText();
                    continue;
                }
                if ( _beforeColor != _richColor && i>2) 
                {
                    if (_csvKey == "BubbleTalk"){ return; }
                    _richNewData._richNum[_Num] = i;
                    _Num++;
                    if (_Num == 2)
                    {
                        _Num = 0;
                        _richinfo = _commentText.Characters[_richNewData._richNum[0], _richNewData._richNum[1] - _richNewData._richNum[0]];
                        _richNewData._needRichText = _richinfo.Text;
                        _richData.Add(_richNewData);
                        _richNewData = new RichText();
                    }
                    continue;
                }
            }
            for (int i = 0; i < _boldData.Count; i++)
            {
                if (_boldData[i]._needBoldText.Length == 0)
                {
                    break;
                }
                if (_boldData[i]._needBoldText.Length ==1)
                {
                    foreach (char item in _boldData[i]._needBoldText)
                    {
                        if (item <= 'A' || item >= 'Z')
                        {
                            break;
                        }
                    }
                }
                if (_csvText.Contains(_boldData[i]._needBoldText))
                {
                    var _boldSuffixX = string.Concat(_boldSuffix, _boldData[i]._needBoldText , _boldSuffixNext);
                    var test = _csvText.Replace(_boldData[i]._needBoldText, _boldSuffixX);
                    _csvText = test;
                }
            }
            for (var i = 0; i < _richData.Count; i++)
            {
                
                if (_richData[i]._needRichText.Length == 0)
                {
                    return;
                }

                if (_csvText.Contains(_richData[i]._needRichText))
                {
                    var _richSuffixX = string.Concat(_richSuffix, _richData[i]._needRichText, _richSuffixNext);
                    var test = _csvText.Replace(_richData[i]._needRichText, _richSuffixX);
                    _csvText = test;
                }
            }

        }
        #endregion


        #region 用约定计算表长度
        public void CaculateExcelRows(int count, Worksheet endSheet,out int t) 
        {
            int s = 0;
            for (; s < count; s++)
            {
                var isEnd = (Range)endSheet.Cells[s+1, 2];
                var isEndText = isEnd.Text;
                if (isEndText.Contains("END OF DAY"))
                {
                    break;
                }
            }
            if (s==0)
            {
                t = 300;
            }
            else
            {
                t = s;
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using Aspose.Cells;
using FISCA.LogAgent;

namespace K12.Service.Learning.Modules
{
    public partial class DigitalCodeForm : BaseForm
    {
        AccessHelper _AccessHelper = new AccessHelper();
        BackgroundWorker BGW = new BackgroundWorker();
        BackgroundWorker BGW_Save = new BackgroundWorker();
        private Campus.Windows.ChangeListener DataListener { get; set; }

        private bool DataGridViewDataInChange = false;

        public DigitalCodeForm()
        {
            InitializeComponent();
            List<int> cols = new List<int>() { 0 };
            Campus.Windows.DataGridViewImeDecorator dec = new Campus.Windows.DataGridViewImeDecorator(this.dataGridViewX1, cols);
        }

        private void DigitalCodeForm_Load(object sender, EventArgs e)
        {
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
            BGW.RunWorkerAsync();
            SetFrom = false;

            BGW_Save.DoWork += new DoWorkEventHandler(BGW_Save_DoWork);
            BGW_Save.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_Save_RunWorkerCompleted);

            DataListener = new Campus.Windows.ChangeListener();
            DataListener.Add(new Campus.Windows.DataGridViewSource(dataGridViewX1));
            DataListener.StatusChanged += new EventHandler<Campus.Windows.ChangeEventArgs>(DataListener_StatusChanged);
        }

        bool SetFrom
        {
            set
            {
                if (value)
                {
                    this.Text = "服務學習事由代碼表";

                }
                else
                {
                    this.Text = "服務學習事由代碼表(處理中...)";
                }
                btnPrint.Enabled = value;
                btnInsert.Enabled = value;
                btnSave.Enabled = value;
            }
        }

        void DataListener_StatusChanged(object sender, Campus.Windows.ChangeEventArgs e)
        {
            DataGridViewDataInChange = true;
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DigitalCodeRecord> DCRecord = _AccessHelper.Select<DigitalCodeRecord>();
            e.Result = DCRecord;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetFrom = true;

            List<DigitalCodeRecord> DCRecord = (List<DigitalCodeRecord>)e.Result;
            foreach (DigitalCodeRecord dcr in DCRecord)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewX1);
                row.Cells[0].Value = dcr.Code;
                row.Cells[1].Value = dcr.Content;
                dataGridViewX1.Rows.Add(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BGW_Save.IsBusy)
            {
                //資料檢查
                if (!ValidateRow())
                {
                    FISCA.Presentation.Controls.MsgBox.Show("輸入資料有誤，請修正後再行儲存。", "內容錯誤", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                SetFrom = true;
                //儲存
                List<DigitalCodeRecord> DCRecord = new List<DigitalCodeRecord>();
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    DigitalCodeRecord dcRecord = new DigitalCodeRecord();
                    dcRecord.Code = ("" + row.Cells[0].Value).Trim();
                    dcRecord.Content = ("" + row.Cells[1].Value).Trim();
                    DCRecord.Add(dcRecord);
                }

                BGW_Save.RunWorkerAsync(DCRecord);
            }
            else
            {
                MsgBox.Show("系統忙碌中...");
            }

        }

        private bool ValidateRow()
        {
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ErrorText != "")
                    {
                        return false;
                    }
                    else if ("" + cell.Value == "")
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        void BGW_Save_DoWork(object sender, DoWorkEventArgs e)
        {
            //刪除
            List<DigitalCodeRecord> DelList = _AccessHelper.Select<DigitalCodeRecord>();
            _AccessHelper.DeletedValues(DelList);

            //把引數進行儲存
            List<DigitalCodeRecord> SaveList = (List<DigitalCodeRecord>)e.Argument;
            _AccessHelper.InsertValues(SaveList);
        }

        void BGW_Save_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MsgBox.Show("儲存成功!!");
                DataGridViewDataInChange = false;
                this.Close();
            }
            else
            {
                SetFrom = true;
                MsgBox.Show("儲存失敗!!\n" + e.Error.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            #region 確認畫面
            DialogResult dr = FISCA.Presentation.Controls.MsgBox.Show("匯入服務學習代碼表\n將完全覆蓋目前之資料狀態\n(建議可將原資料匯出備份)\n\n請確認繼續?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
            if (dr != DialogResult.Yes)
                return;

            Workbook wb = new Workbook();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "選擇要匯入的服務學習代碼表";
            ofd.Filter = "Excel檔案 (*.xlsx)|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    wb.Open(ofd.FileName);
                }
                catch
                {
                    FISCA.Presentation.Controls.MsgBox.Show("指定路徑無法存取。", "開啟檔案失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;

            //必要欄位
            List<string> requiredHeaders = new List<string>(new string[] { "代碼", "事由" });
            //欄位標題的索引
            Dictionary<string, int> headers = new Dictionary<string, int>();
            Worksheet ws = wb.Worksheets[0];
            for (int i = 0; i <= ws.Cells.MaxDataColumn; i++)
            {
                string header = ws.Cells[0, i].StringValue;
                if (requiredHeaders.Contains(header))
                    headers.Add(header, i);
            }

            //如果使用者匯入檔的欄位與必要欄位不符，則停止匯入
            if (headers.Count != requiredHeaders.Count)
            {
                StringBuilder builder = new StringBuilder(string.Empty);
                builder.AppendLine("匯入格式不符合。");
                builder.AppendLine("匯入資料標題必須包含：");
                builder.AppendLine(string.Join(",", requiredHeaders.ToArray()));
                FISCA.Presentation.Controls.MsgBox.Show(builder.ToString());
                return;
            }

            #endregion

            //資料匯入
            StringBuilder NameSb = new StringBuilder();
            List<string> NameList1 = new List<string>();

            for (int x = 1; x <= wb.Worksheets[0].Cells.MaxDataRow; x++) //每一Row
            {
                string code = ws.Cells[x, headers["代碼"]].StringValue;
                string name = ws.Cells[x, headers["事由"]].StringValue;

                if (string.IsNullOrEmpty(code.Trim())) //沒有代碼則跳過
                    continue;

                if (!NameList1.Contains(code.Trim()))
                {
                    NameList1.Add(code.Trim());
                }
                else
                {
                    NameSb.AppendLine("代碼重覆:" + code.Trim());
                }
            }

            if (!string.IsNullOrEmpty(NameSb.ToString()))
            {
                FISCA.Presentation.Controls.MsgBox.Show("匯入 服務學習代碼表 發生錯誤:\n" + NameSb.ToString());
                return;
            }

            List<DigitalCodeRecord> DCRecord = new List<DigitalCodeRecord>();
            for (int x = 1; x <= wb.Worksheets[0].Cells.MaxDataRow; x++) //每一Row
            {
                string code = ws.Cells[x, headers["代碼"]].StringValue;
                string name = ws.Cells[x, headers["事由"]].StringValue;

                if (string.IsNullOrEmpty(code.Trim())) //沒有代碼則跳過
                    continue;

                DigitalCodeRecord dcRecord = new DigitalCodeRecord();
                dcRecord.Code = code.Trim();
                dcRecord.Content = name.Trim();
                DCRecord.Add(dcRecord);
            }



            //刪除
            List<DigitalCodeRecord> DelList = _AccessHelper.Select<DigitalCodeRecord>();
            _AccessHelper.DeletedValues(DelList);

            //儲存
            try
            {
                _AccessHelper.InsertValues(DCRecord);
            }
            catch (Exception exception)
            {
                FISCA.Presentation.Controls.MsgBox.Show("更新失敗 :" + exception.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApplicationLog.Log("服務學習時數", "匯入", "服務學習代碼表 已覆蓋匯入。");

            FISCA.Presentation.Controls.MsgBox.Show("匯入成功!\n新設定將於畫面重新開啟時生效!", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridViewDataInChange = false;
            this.Close();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region 匯出
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(dataGridViewX1);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DigitalCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DataGridViewDataInChange)
            {
                DialogResult dr = FISCA.Presentation.Controls.MsgBox.Show("資料已變更,是否離開?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 資料重覆檢查,空值檢查
        /// </summary>
        /// <param name="ColumnIndex">傳入Column的Index</param>
        /// <param name="row">傳入Row的Index</param>
        private void CheckNameRepeat(int ColumnIndex, int RowIndex)
        {
            string Name = "" + dataGridViewX1.Rows[RowIndex].Cells[ColumnIndex].Value;
            DataGridViewRow OneRow = dataGridViewX1.Rows[RowIndex];

            List<string> list = new List<string>();

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == ColumnIndex) //同一行
                    {
                        if (cell.RowIndex != RowIndex) //不同列
                        {
                            list.Add("" + cell.Value);
                        }
                    }
                }

            }

            if (Name == string.Empty)
            {
                OneRow.Cells[ColumnIndex].ErrorText = "必須輸入內容!";
            }
            else if (list.Contains(Name))
            {
                OneRow.Cells[ColumnIndex].ErrorText = "資料重覆,請重新輸入!";
            }
            else
            {
                OneRow.Cells[ColumnIndex].ErrorText = "";
            }
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Rows[e.RowIndex].IsNewRow)
                return;

            if (e.ColumnIndex == 0) //代碼
            {
                CheckNameRepeat(e.ColumnIndex, e.RowIndex);
            }
            else if (e.ColumnIndex == 1) //事由
            {
                CheckNameRepeat(e.ColumnIndex, e.RowIndex);
            }
        }

        private void dataGridViewX1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //當選擇只有1格時,則進入編輯
            if (dataGridViewX1.SelectedCells.Count == 1)
                dataGridViewX1.BeginEdit(true);
        }
    }
}

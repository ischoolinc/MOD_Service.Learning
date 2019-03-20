using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Xml;
using K12.Data;
using FISCA.LogAgent;
using FISCA.UDT;
using FISCA.Data;

namespace K12.Service.Learning.Modules
{
    public partial class SingleStudentLearning : BaseForm
    {
        private Dictionary<string, string> dicReason = new Dictionary<string, string>();
        private StringBuilder sb = new StringBuilder();
        private AccessHelper _access = new AccessHelper();
        private QueryHelper _qh = new QueryHelper();
        private BackgroundWorker BGW = new BackgroundWorker();
        private StudentRecord studentRecord = new StudentRecord();
        private List<SLRecord> _listSLR = new List<SLRecord>();

        public SingleStudentLearning()
        {
            InitializeComponent();
        }

        private void MutiLearning_Load(object sender, EventArgs e)
        {

            //取得學生
            this.studentRecord = K12.Data.Student.SelectByID(K12.Presentation.NLDPanels.Student.SelectedSource[0]);

            lbStudentInfo.Text = string.Format("班級 :  {0}    座號 :  {1}    學號 :  {2}    姓名 :  {3} "
                , this.studentRecord.Class.Name, this.studentRecord.SeatNo, this.studentRecord.StudentNumber, this.studentRecord.Name);


            #region Init DataGridView
            {
                // 事由
                List<DigitalCodeRecord> listCode = this._access.Select<DigitalCodeRecord>();
                foreach (DigitalCodeRecord dcr in listCode)
                {
                    detail.Items.Add(dcr.Code + "-" + dcr.Content);
                }
                // 主辦單位

                DataTable dt = this._qh.Select("SELECT DISTINCT organizers FROM $k12.service.learning.record ORDER BY organizers");
                foreach (DataRow dr in dt.Rows)
                {
                    organizers.Items.Add("" + dr["organizers"]);
                }
            }
            #endregion
        }

        /// <summary>
        /// 驗證發生日期欄位
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool ValidOccurDate(DataGridViewCell cell)
        {
            if (string.IsNullOrEmpty("" + cell.Value))
            {
                cell.ErrorText = "欄位不可空白!";
                return false;
            }
            else
            {
                cell.ErrorText = null;
                return true;
            }
        }

        /// <summary>
        /// 驗證時數欄位
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool ValidCount(DataGridViewCell cell)
        {

            if (時數轉換器.IsDecimal("" + cell.Value))
            {
                if (時數轉換器.SentDecimalByString("" + cell.Value))
                {
                    cell.ErrorText = "";
                    return true;
                }
                else
                {
                    cell.ErrorText = "輸入內容必須為整數\n或小數後兩位!!";
                    return false;
                }
            }
            else
            {
                cell.ErrorText = "內容非數字!!";
                return false;
            }
        }

        private void dataGridViewX1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;

                DataGridViewCell cell = dataGridViewX1.Rows[row].Cells[col];
                //不等於最後一行才進行驗證
                if (dataGridViewX1.RowCount != row)
                {
                    // 驗證發生日期
                    if (col == 0)
                    {
                        //如果是最後一行 就不用進行資料驗證及轉換
                        if (ValidOccurDate(cell))
                        {
                            #region 學年度學期轉換
                            {
                                int sy = 0;
                                int s = 0;
                                int year = DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Year;
                                int month = DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Month;

                                if (month >= 8)
                                {
                                    sy = year - 1911;
                                    s = 1;
                                }
                                if (month < 2)
                                {
                                    sy = year - 1911 - 1;
                                    s = 1;
                                }
                                if (month >= 2 && month < 8)
                                {
                                    sy = year - 1911 - 1;
                                    s = 2;
                                }

                                dataGridViewX1.Rows[e.RowIndex].Cells["schoolYear"].Value = sy;
                                dataGridViewX1.Rows[e.RowIndex].Cells["semester"].Value = s;
                            }
                            #endregion
                        }
                    }
                    // 驗證時數
                    if (col == 1)
                    {
                        if (cell.RowIndex != dataGridViewX1.RowCount - 1)
                        {
                            ValidCount(cell);
                        }

                    }
                    // 事由代碼轉換
                    if (col == 2)
                    {
                        GetReason("" + cell.Value);
                    }
                }

            }
        }

        /// <summary>
        /// 取得服務學習資料
        /// </summary>
        /// <returns></returns>
        private void GetServiceData()
        {
            // 資料清空
            sb.Clear();
            this._listSLR.Clear();

            sb.AppendLine("批次「服務學習記錄」快速登錄作業");
            sb.AppendLine("詳細資料：");

            #region 資料整理
            {
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    if (row.Cells["count"].Value != null)
                    {
                        SLRecord mr = new SLRecord();

                        mr.RefStudentID = this.studentRecord.ID; //學生ID

                        mr.Hours = decimal.Parse("" + row.Cells["count"].Value); //時數

                        string strDetail = "" + row.Cells["detail"].Value;//處理事由代號

                        mr.Reason = strDetail.Remove(0, strDetail.IndexOf('-') + 1);//事由

                        mr.Organizers = "" + row.Cells["organizers"].Value;  //主辦單位

                        mr.Remark = "" + row.Cells[4].Value;  //備註

                        mr.InternalOrExternal = "" + row.Cells["collandOut"].Value;  //校內外

                        mr.OccurDate = DateTime.Parse("" + row.Cells["occurDate"].Value);  // 發生日期

                        mr.RegisterDate = DateTime.Today; // 紀錄日期

                        mr.SchoolYear = int.Parse("" + row.Cells["schoolYear"].Value); // 學年度

                        mr.Semester = int.Parse("" + row.Cells["semester"].Value); // 學期

                        this._listSLR.Add(mr);

                        sb.AppendLine("學生「" + this.studentRecord.Name + "」"
                        + "時數「" + row.Cells["count"].Value + "」"
                        + "事由「" + row.Cells["detail"].Value + "」"
                        + "主辦單位「" + row.Cells["organizers"].Value + "」"
                        + "備註「" + row.Cells[4].Value + "」"
                            + "校內外「" + row.Cells["collandOut"].Value + "」");
                    }
                }
            }
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int rowNum = 0;
            List<string> listError = new List<string>();
            List<string> listRemind = new List<string>();
            foreach (DataGridViewRow dgvrow in dataGridViewX1.Rows)
            {
                //如果不是最後一行 && 為第一行>>進行驗證 
                if (rowNum != dataGridViewX1.Rows.Count - 1|| rowNum==0)
                {
                    if (!ValidOccurDate(dgvrow.Cells[0]))
                    {
                        if (!listError.Contains("[發生日期]"))
                        {
                            listError.Add("[發生日期]");
                        }
                    }
                    if (!ValidCount(dgvrow.Cells[1]))
                    {
                        if (!listError.Contains("[時數欄位]"))
                        {
                            listError.Add("[時數欄位]");
                        }
                    }
                    //事由未填
                    if (String.IsNullOrEmpty("" + dgvrow.Cells[2].Value))
                    {
                        if (!listRemind.Contains("[事由]"))
                        {
                            listRemind.Add("[事由]");
                        }
                    }
                    //主班單位未填
                    if (String.IsNullOrEmpty("" + dgvrow.Cells[3].Value))
                    {
                        if (!listRemind.Contains("[主辦單位]"))
                        {
                            listRemind.Add("[主辦單位]");
                        }
                    }
                }
                rowNum++;
            }

            if (listError.Count>0)
            {
                MsgBox.Show($"部份學生 :{string.Join(",", listError)} 內容有誤!");
                return;
            }
            else
            {
                //是否需要提醒未填欄位
                if (listRemind.Count > 0)
                {
                    DialogResult dr = MsgBox.Show($"部份學生 :{string.Join(",", listRemind)} 未輸入,是否繼續儲存?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (dr == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                // 取得儲存資料
                GetServiceData();

                //如果資料驗證沒有錯誤
                if (true)
                {
                    try
                    {
                        this._access.InsertValues(this._listSLR);
                    }
                    catch (Exception ex)
                    {
                        MsgBox.Show("新增服務學習記錄失敗\n" + ex.Message);
                        return;
                    }
                    ApplicationLog.Log("服務學習記錄模組", "批次服務學習記錄快速登錄", sb.ToString());
                    MsgBox.Show("新增服務學習記錄成功!");

                    LearningEvents.RaiseAssnChanged();

                    this.Close();
                }
            }
        }

        /// <summary>
        /// 檢查時數是否為Decimal型態
        /// </summary>
        /// <returns></returns>
        private bool IsDecimal(string value)
        {
            bool result = true;

            if (!時數轉換器.IsDecimal(value))
            {
                if (!時數轉換器.SentDecimalByString(value))
                {
                    result = false;
                }
            }
            return result;
        }

        private string GetReason(string comText)
        {
            string reasonValue = "";
            List<string> list = new List<string>();
            string[] reasonList = comText.Split(',');
            foreach (string each in reasonList)
            {
                string each1 = each.Replace("\r\n", "");
                if (dicReason.ContainsKey(each1))
                {
                    list.Add(dicReason[each1]);
                }
                else
                {
                    list.Add(each1);
                }
            }

            reasonValue = string.Join(",", list);
            return reasonValue;
        }

        private void lbDescription_Click(object sender, EventArgs e)
        {
            MsgBox.Show(@"學年度、學期 :  

                會依照登打的發生日期自動換算，
                自動換算以2月、8月為分界點，也可自行輸入。
                EX:
                2018 / 2 / 1 以前為 106學年 、 第1學期
                2018 / 2 / 1 ~ 2018 / 8 / 1 日期區間為 106學年 、 第2學期
                2018 / 8 / 1 以後為 107學年 第1學期");
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


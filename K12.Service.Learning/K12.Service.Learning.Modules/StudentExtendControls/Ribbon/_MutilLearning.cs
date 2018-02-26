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
    public partial class _MutiLearning : BaseForm
    {
        Dictionary<string, string> ReasonDic = new Dictionary<string, string>();

        StringBuilder sb = new StringBuilder();

        AccessHelper _accessHelper = new AccessHelper();

        BackgroundWorker BGW = new BackgroundWorker();

        List<DigitalCodeRecord> DCRecord { get; set; }

        List<string> OrganizersList { get; set; }

        /// <summary>
        /// 傳入獎勵或懲戒字串,以決定模式
        /// </summary>
        /// <param name="DemeritOrMerit"></param>
        public _MutiLearning()
        {
            InitializeComponent();
        }

        //Load
        private void MutiLearning_Load(object sender, EventArgs e)
        {
            #region Init DataGridView
            collandOut.Items.Add("校內");
            collandOut.Items.Add("校外");
            //取得學生
            StudentRecord student = K12.Data.Student.SelectByID(K12.Presentation.NLDPanels.Student.SelectedSource[0]);

            classLb.Text = student.Class.Name;
            seatNoLb.Text = "" + student.SeatNo;
            studentNoLb.Text = student.StudentNumber;
            studentNameLb.Text = student.Name;
            studentNameLb.Tag = student.ID;

            // 事由
            detail.Width = 210;
            AccessHelper access = new AccessHelper();
            List<DigitalCodeRecord> dcrList = access.Select<DigitalCodeRecord>();
            foreach (DigitalCodeRecord dcr in dcrList)
            {
                detail.Items.Add(dcr.Code + "-" + dcr.Content);
            }
            // 主辦單位
            QueryHelper qh = new QueryHelper();
            string sql = "SELECT DISTINCT organizers FROM $k12.service.learning.record ORDER BY organizers";
            DataTable dt = qh.Select(sql);
            organizers.Width = 110;
            foreach (DataRow dr in dt.Rows)
            {
                organizers.Items.Add("" + dr["organizers"]);
            }
            #endregion

        }

        //儲存
        private void buttonX2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow datarow in dataGridViewX1.Rows)
            {
                if (datarow.Cells["count"].Value == null && datarow.Cells["detail"].Value == null && datarow.Cells["organizers"].Value == null)
                {
                    continue;
                }
                if (!CheckIntError())
                {
                    MsgBox.Show("輸入[時數]型態錯誤,請重新修正後再儲存!!");
                    return;
                }

                if (CheckOrganizers())
                {
                    DialogResult dr = MsgBox.Show("部份學生資料未輸入主辦單位,是否繼續儲存?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);

                    if (dr == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                if (CheckReasonError())
                {
                    DialogResult dr = MsgBox.Show("部份學生資料未輸入事由,是否繼續儲存?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);

                    if (dr == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                List<SLRecord> MeritList = GetSLRList();
                try
                {
                    _accessHelper.InsertValues(MeritList);
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

        //取得獎勵資料
        private List<SLRecord> GetSLRList()
        {
            sb.AppendLine("批次「服務學習記錄」快速登錄作業");
            //sb.AppendLine("學年度「" + integerInput1.Value.ToString() + "」");
            //sb.AppendLine("學期「" + integerInput2.Value.ToString() + "」");
            //sb.AppendLine("發生日期：" + dateTimeInput1.Value.ToShortDateString());
            //sb.AppendLine("登錄日期：" + dateTimeInput2.Value.ToShortDateString());
            sb.AppendLine("詳細資料：");

            List<SLRecord> SLRList = new List<SLRecord>();
            // 學生的獎懲資料
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.Cells["count"].Value != null && row.Cells["detail"].Value != null && row.Cells["organizers"].Value != null)
                {
                    SLRecord mr = new SLRecord();

                    mr.RefStudentID = "" + studentNameLb.Tag; //學生ID

                    mr.Hours = decimal.Parse("" + row.Cells["count"].Value); //時數
                    mr.Reason = "" + row.Cells["detail"].Value; //事由

                    mr.Organizers = "" + row.Cells["organizers"].Value;  //主辦單位
                    mr.Remark = "" + row.Cells[4].Value;  //備註

                    mr.InternalOrExternal = "" + row.Cells["collandOut"].Value;  //校內外

                    mr.OccurDate = DateTime.Parse("" + row.Cells["occurDate"].Value);  // 發生日期

                    mr.RegisterDate = DateTime.Today; // 紀錄日期

                    mr.SchoolYear = int.Parse("" + row.Cells["schoolYear"].Value); // 學年度

                    mr.Semester = int.Parse("" + row.Cells["semester"].Value); // 學期

                    SLRList.Add(mr);

                    sb.AppendLine("學生「" + studentNameLb.Text + "」"
                    + "時數「" + row.Cells["count"].Value + "」"
                    + "事由「" + row.Cells["detail"].Value + "」"
                    + "主辦單位「" + row.Cells["organizers"].Value + "」"
                    + "備註「" + row.Cells[4].Value + "」"
                      + "校內外「" + row.Cells["collandOut"].Value + "」");
                }
                
            }
            return SLRList;
        }

        private bool CheckOrganizers()
        {
            bool returnTrue = false;

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.Cells["count"].Value != null && row.Cells["detail"].Value != null )
                {
                    if (("" + row.Cells[2].Value).Trim() == "")
                    {
                        returnTrue = true;
                    }
                }
            }
            return returnTrue;
        }

        /// <summary>
        /// 檢查事由是否輸入
        /// </summary>
        /// <returns></returns>
        private bool CheckReasonError()
        {
            bool returnTrue = false;

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.Cells["count"].Value != null && row.Cells["organizers"].Value != null)
                {
                    if (("" + row.Cells[1].Value).Trim() == "")
                    {
                        returnTrue = true;
                    }
                }
            }
            return returnTrue;
        }

        /// <summary>
        /// 檢查時數是否為int型態
        /// </summary>
        /// <returns></returns>
        private bool CheckIntError()
        {
            // 2017/10/31，羿均根據恩正的建議修改判斷邏輯，只要有欄位無法轉型就false。
            bool returnTrue = true;

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.Cells["detail"].Value != null && row.Cells["organizers"].Value != null)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 0)
                        {
                            if (!時數轉換器.IsDecimal("" + cell.Value))
                            {
                                if (!時數轉換器.SentDecimalByString("" + cell.Value))
                                {
                                    returnTrue = false;
                                }
                            }
                        }
                    }
                }
            }
            return returnTrue;
        }

        //離開
        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewX1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //不是標題列
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                //缺曠數量
                if (e.ColumnIndex == count.Index)
                {
                    DataGridViewCell cell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (時數轉換器.IsDecimal("" + cell.Value))
                    {
                        if (時數轉換器.SentDecimalByString("" + cell.Value))
                        {
                            cell.ErrorText = "";
                        }
                        else
                        {
                            cell.ErrorText = "輸入內容必須為整數\n或小數後兩位!!";
                        }
                    }
                    else
                    {
                        cell.ErrorText = "內容非數字!!";
                    }
                }

                //事由替換
                if (e.ColumnIndex == detail.Index)
                {
                    DataGridViewCell cell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Value = GetReason("" + cell.Value);
                }

                //校內外
                if (e.ColumnIndex == collandOut.Index)
                {
                    DataGridViewCell cell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if ("" + cell.Value == "校內" || "" + cell.Value == "校外" || "" + cell.Value == "")
                    {
                        cell.ErrorText = "";
                    }
                    else
                    {
                        cell.ErrorText = "必須為校內或校外";
                    }
                }

                // 發生日期
                if (e.ColumnIndex == occurDate.Index)
                {
                    int sy = 0;
                    int s = 0;
                    int year = DateTime.Parse( dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "").Year;
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
            }
        }

        private string GetReason(string comText)
        {
            string reasonValue = "";
            List<string> list = new List<string>();
            string[] reasonList = comText.Split(',');
            foreach (string each in reasonList)
            {
                string each1 = each.Replace("\r\n", "");
                if (ReasonDic.ContainsKey(each1))
                {
                    list.Add(ReasonDic[each1]);
                }
                else
                {
                    list.Add(each1);
                }
            }

            reasonValue = string.Join(",", list);
            return reasonValue;
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                
            }
        }
    }
}


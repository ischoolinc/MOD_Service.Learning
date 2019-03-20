namespace K12.Service.Learning.Modules
{
    partial class SingleStudentLearning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnLeave = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbStudentInfo = new DevComponents.DotNetBar.LabelX();
            this.lbDescription = new DevComponents.DotNetBar.LabelX();
            this.occurDate = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.organizers = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collandOut = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.schoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.occurDate,
            this.count,
            this.detail,
            this.organizers,
            this.Column9,
            this.collandOut,
            this.schoolYear,
            this.semester});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(905, 403);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(761, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "登錄";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeave.BackColor = System.Drawing.Color.Transparent;
            this.btnLeave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLeave.Location = new System.Drawing.Point(842, 454);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(75, 23);
            this.btnLeave.TabIndex = 3;
            this.btnLeave.Text = "離開";
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbStudentInfo
            // 
            this.lbStudentInfo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbStudentInfo.BackgroundStyle.Class = "";
            this.lbStudentInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbStudentInfo.Location = new System.Drawing.Point(12, 12);
            this.lbStudentInfo.Name = "lbStudentInfo";
            this.lbStudentInfo.Size = new System.Drawing.Size(450, 23);
            this.lbStudentInfo.TabIndex = 4;
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDescription.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbDescription.BackgroundStyle.Class = "";
            this.lbDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbDescription.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbDescription.ForeColor = System.Drawing.Color.Blue;
            this.lbDescription.Location = new System.Drawing.Point(12, 454);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(223, 23);
            this.lbDescription.TabIndex = 5;
            this.lbDescription.Text = "說明：本功能僅提供快速新增";
            this.lbDescription.Click += new System.EventHandler(this.lbDescription_Click);
            // 
            // occurDate
            // 
            // 
            // 
            // 
            this.occurDate.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.occurDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.occurDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.occurDate.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.occurDate.ButtonDropDown.Visible = true;
            this.occurDate.HeaderText = "發生日期";
            this.occurDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.occurDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.occurDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.occurDate.MonthCalendar.BackgroundStyle.Class = "";
            this.occurDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.occurDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.occurDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.occurDate.MonthCalendar.DisplayMonth = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            this.occurDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.occurDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.occurDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.occurDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.occurDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.occurDate.Name = "occurDate";
            this.occurDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.occurDate.Width = 140;
            // 
            // count
            // 
            this.count.HeaderText = "時數";
            this.count.Name = "count";
            this.count.Width = 75;
            // 
            // detail
            // 
            this.detail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.detail.DisplayMember = "Text";
            this.detail.DropDownHeight = 106;
            this.detail.DropDownWidth = 121;
            this.detail.FillWeight = 80F;
            this.detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detail.HeaderText = "事由";
            this.detail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.detail.IntegralHeight = false;
            this.detail.ItemHeight = 17;
            this.detail.Name = "detail";
            this.detail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.detail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // organizers
            // 
            this.organizers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.organizers.DisplayMember = "Text";
            this.organizers.DropDownHeight = 106;
            this.organizers.DropDownWidth = 121;
            this.organizers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.organizers.HeaderText = "主辦單位";
            this.organizers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.organizers.IntegralHeight = false;
            this.organizers.ItemHeight = 17;
            this.organizers.Name = "organizers";
            this.organizers.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.organizers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "備註";
            this.Column9.Name = "Column9";
            this.Column9.Width = 80;
            // 
            // collandOut
            // 
            this.collandOut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.collandOut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.collandOut.DefaultCellStyle = dataGridViewCellStyle5;
            this.collandOut.DisplayMember = "Text";
            this.collandOut.DropDownHeight = 106;
            this.collandOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.collandOut.DropDownWidth = 121;
            this.collandOut.FillWeight = 60F;
            this.collandOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.collandOut.HeaderText = "校內外";
            this.collandOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.collandOut.IntegralHeight = false;
            this.collandOut.ItemHeight = 17;
            this.collandOut.Items.AddRange(new object[] {
            "校內",
            "校外"});
            this.collandOut.Name = "collandOut";
            this.collandOut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.collandOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.collandOut.Width = 90;
            // 
            // schoolYear
            // 
            this.schoolYear.HeaderText = "學年度";
            this.schoolYear.Name = "schoolYear";
            this.schoolYear.Width = 90;
            // 
            // semester
            // 
            this.semester.HeaderText = "學期";
            this.semester.Name = "semester";
            this.semester.Width = 75;
            // 
            // SingleStudentLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 484);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbStudentInfo);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.MaximizeBox = true;
            this.Name = "SingleStudentLearning";
            this.Text = "單人服務學習快速登錄";
            this.Load += new System.EventHandler(this.MutiLearning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnLeave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.LabelX lbStudentInfo;
        private DevComponents.DotNetBar.LabelX lbDescription;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn occurDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn detail;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn organizers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn collandOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn schoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester;
    }
}
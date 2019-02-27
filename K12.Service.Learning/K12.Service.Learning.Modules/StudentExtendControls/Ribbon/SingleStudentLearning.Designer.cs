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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.dataGridViewX1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellClick);
            this.dataGridViewX1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellValueChanged);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.BackColor = System.Drawing.Color.Transparent;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(761, 454);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 2;
            this.buttonX2.Text = "登錄";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX3.BackColor = System.Drawing.Color.Transparent;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(842, 454);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.TabIndex = 3;
            this.buttonX3.Text = "離開";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(413, 23);
            this.labelX1.TabIndex = 4;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelX2.ForeColor = System.Drawing.Color.Blue;
            this.labelX2.Location = new System.Drawing.Point(12, 454);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(223, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "說明：本功能僅提供快速新增";
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.collandOut.DefaultCellStyle = dataGridViewCellStyle1;
            this.collandOut.DisplayMember = "Text";
            this.collandOut.DropDownHeight = 106;
            this.collandOut.DropDownWidth = 121;
            this.collandOut.FillWeight = 60F;
            this.collandOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.collandOut.HeaderText = "校內外";
            this.collandOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.collandOut.IntegralHeight = false;
            this.collandOut.ItemHeight = 17;
            this.collandOut.Name = "collandOut";
            this.collandOut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.collandOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
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
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
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
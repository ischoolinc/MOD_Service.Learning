namespace K12.Service.Learning.CreationItems
{
    partial class ApprovedForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColCasll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColseatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOccurDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSemester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrganizers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改發生日期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改事由ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改時數ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改學年度學期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批次修改備註ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.自畫面上移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCasll,
            this.ColseatNo,
            this.ColName,
            this.ColStudentNumber,
            this.ColOccurDate,
            this.ColReason,
            this.ColHours,
            this.ColSchoolYear,
            this.ColSemester,
            this.ColOrganizers,
            this.ColRegisterDate,
            this.ColRemark});
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(710, 467);
            this.dataGridViewX1.TabIndex = 3;
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // ColCasll
            // 
            this.ColCasll.DataPropertyName = "ClassName";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.ColCasll.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColCasll.Frozen = true;
            this.ColCasll.HeaderText = "班級";
            this.ColCasll.Name = "ColCasll";
            this.ColCasll.ReadOnly = true;
            this.ColCasll.Width = 80;
            // 
            // ColseatNo
            // 
            this.ColseatNo.DataPropertyName = "SeatNo";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCyan;
            this.ColseatNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColseatNo.Frozen = true;
            this.ColseatNo.HeaderText = "座號";
            this.ColseatNo.Name = "ColseatNo";
            this.ColseatNo.ReadOnly = true;
            this.ColseatNo.Width = 60;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "StudentName";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.ColName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColName.Frozen = true;
            this.ColName.HeaderText = "姓名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 80;
            // 
            // ColStudentNumber
            // 
            this.ColStudentNumber.DataPropertyName = "StudentNumber";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan;
            this.ColStudentNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColStudentNumber.Frozen = true;
            this.ColStudentNumber.HeaderText = "學號";
            this.ColStudentNumber.Name = "ColStudentNumber";
            this.ColStudentNumber.ReadOnly = true;
            this.ColStudentNumber.Width = 80;
            // 
            // ColOccurDate
            // 
            this.ColOccurDate.DataPropertyName = "OccurDate";
            this.ColOccurDate.HeaderText = "發生日期";
            this.ColOccurDate.Name = "ColOccurDate";
            this.ColOccurDate.ReadOnly = true;
            // 
            // ColReason
            // 
            this.ColReason.DataPropertyName = "Reason";
            this.ColReason.HeaderText = "事由";
            this.ColReason.Name = "ColReason";
            this.ColReason.ReadOnly = true;
            this.ColReason.Width = 200;
            // 
            // ColHours
            // 
            this.ColHours.DataPropertyName = "Hours";
            this.ColHours.HeaderText = "時數";
            this.ColHours.Name = "ColHours";
            this.ColHours.ReadOnly = true;
            this.ColHours.Width = 60;
            // 
            // ColSchoolYear
            // 
            this.ColSchoolYear.DataPropertyName = "SchoolYear";
            this.ColSchoolYear.HeaderText = "學年度";
            this.ColSchoolYear.Name = "ColSchoolYear";
            this.ColSchoolYear.ReadOnly = true;
            this.ColSchoolYear.Width = 70;
            // 
            // ColSemester
            // 
            this.ColSemester.DataPropertyName = "Semester";
            this.ColSemester.HeaderText = "學期";
            this.ColSemester.Name = "ColSemester";
            this.ColSemester.ReadOnly = true;
            this.ColSemester.Width = 60;
            // 
            // ColOrganizers
            // 
            this.ColOrganizers.DataPropertyName = "Organizers";
            this.ColOrganizers.HeaderText = "主辦單位";
            this.ColOrganizers.Name = "ColOrganizers";
            this.ColOrganizers.ReadOnly = true;
            this.ColOrganizers.Width = 120;
            // 
            // ColRegisterDate
            // 
            this.ColRegisterDate.DataPropertyName = "RegisterDate";
            this.ColRegisterDate.HeaderText = "登錄日期";
            this.ColRegisterDate.Name = "ColRegisterDate";
            this.ColRegisterDate.ReadOnly = true;
            // 
            // ColRemark
            // 
            this.ColRemark.DataPropertyName = "Remark";
            this.ColRemark.HeaderText = "備註";
            this.ColRemark.Name = "ColRemark";
            this.ColRemark.ReadOnly = true;
            this.ColRemark.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改發生日期ToolStripMenuItem,
            this.修改事由ToolStripMenuItem,
            this.修改時數ToolStripMenuItem,
            this.修改學年度學期ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.批次修改備註ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.自畫面上移除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 192);
            // 
            // 修改發生日期ToolStripMenuItem
            // 
            this.修改發生日期ToolStripMenuItem.Name = "修改發生日期ToolStripMenuItem";
            this.修改發生日期ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.修改發生日期ToolStripMenuItem.Text = "批次修改發生日期";
            this.修改發生日期ToolStripMenuItem.Click += new System.EventHandler(this.批次修改發生日期ToolStripMenuItem_Click);
            // 
            // 修改事由ToolStripMenuItem
            // 
            this.修改事由ToolStripMenuItem.Name = "修改事由ToolStripMenuItem";
            this.修改事由ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.修改事由ToolStripMenuItem.Text = "批次修改事由";
            this.修改事由ToolStripMenuItem.Click += new System.EventHandler(this.批次修改事由ToolStripMenuItem_Click);
            // 
            // 修改時數ToolStripMenuItem
            // 
            this.修改時數ToolStripMenuItem.Name = "修改時數ToolStripMenuItem";
            this.修改時數ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.修改時數ToolStripMenuItem.Text = "批次修改時數";
            this.修改時數ToolStripMenuItem.Click += new System.EventHandler(this.批次修改時數ToolStripMenuItem_Click);
            // 
            // 修改學年度學期ToolStripMenuItem
            // 
            this.修改學年度學期ToolStripMenuItem.Name = "修改學年度學期ToolStripMenuItem";
            this.修改學年度學期ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.修改學年度學期ToolStripMenuItem.Text = "批次修改學年度學期";
            this.修改學年度學期ToolStripMenuItem.Click += new System.EventHandler(this.批次修改學年度學期ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.修改ToolStripMenuItem.Text = "批次修改主辦單位";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.批次修改主辦單位ToolStripMenuItem_Click);
            // 
            // 批次修改備註ToolStripMenuItem
            // 
            this.批次修改備註ToolStripMenuItem.Name = "批次修改備註ToolStripMenuItem";
            this.批次修改備註ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.批次修改備註ToolStripMenuItem.Text = "批次修改備註";
            this.批次修改備註ToolStripMenuItem.Click += new System.EventHandler(this.批次修改備註ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem1.Text = "批次修改所有欄位";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.批次修改所有資料toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // 自畫面上移除ToolStripMenuItem
            // 
            this.自畫面上移除ToolStripMenuItem.Name = "自畫面上移除ToolStripMenuItem";
            this.自畫面上移除ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.自畫面上移除ToolStripMenuItem.Text = "刪除未參與學生";
            this.自畫面上移除ToolStripMenuItem.Click += new System.EventHandler(this.自畫面上移除ToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(648, 485);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(524, 485);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 25);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "儲存並登錄至系統";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 487);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(100, 21);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "已選/總數：0/0";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(0, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.TabIndex = 0;
            // 
            // ApprovedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 520);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.MaximizeBox = true;
            this.Name = "ApprovedForm";
            this.Text = "登錄作業";
            this.Load += new System.EventHandler(this.ServiceLearningBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修改發生日期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改事由ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改時數ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改學年度學期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批次修改備註ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 自畫面上移除ToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCasll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColseatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOccurDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSchoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSemester;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrganizers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRegisterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemark;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}
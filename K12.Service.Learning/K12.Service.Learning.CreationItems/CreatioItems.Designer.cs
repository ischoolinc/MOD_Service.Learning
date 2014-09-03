namespace K12.Service.Learning.CreationItems
{
    partial class CreationItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.列印點名單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnNew = new DevComponents.DotNetBar.ButtonX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnAuthorized = new DevComponents.DotNetBar.ButtonX();
            this.btnApproved = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.filterOrganizers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.filterSemester = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.filterSchoolYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbEnd = new DevComponents.DotNetBar.LabelX();
            this.lbStart = new DevComponents.DotNetBar.LabelX();
            this.ColRegistStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRegistEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrganizers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOccurDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsAuthorized = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColApproved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExpertedHours = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.ColReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColParticipateLimit = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.ColRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRegistStartTime,
            this.ColRegistEndTime,
            this.ColOrganizers,
            this.ColOccurDate,
            this.ColLocation,
            this.ColCreateBy,
            this.ColIsAuthorized,
            this.ColApproved,
            this.ColExpertedHours,
            this.ColReason,
            this.ColParticipateLimit,
            this.ColRemark});
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(13, 79);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(710, 400);
            this.dataGridViewX1.TabIndex = 3;
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.列印點名單ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // 列印點名單ToolStripMenuItem
            // 
            this.列印點名單ToolStripMenuItem.Name = "列印點名單ToolStripMenuItem";
            this.列印點名單ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.列印點名單ToolStripMenuItem.Text = "列印點名單";
            this.列印點名單ToolStripMenuItem.Click += new System.EventHandler(this.列印點名單ToolStripMenuItem_Click);
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
            // btnNew
            // 
            this.btnNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.AutoSize = true;
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNew.Location = new System.Drawing.Point(13, 487);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.AutoSize = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Location = new System.Drawing.Point(94, 487);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAuthorized
            // 
            this.btnAuthorized.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAuthorized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuthorized.AutoSize = true;
            this.btnAuthorized.BackColor = System.Drawing.Color.Transparent;
            this.btnAuthorized.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAuthorized.Location = new System.Drawing.Point(175, 487);
            this.btnAuthorized.Name = "btnAuthorized";
            this.btnAuthorized.Size = new System.Drawing.Size(75, 25);
            this.btnAuthorized.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAuthorized.TabIndex = 9;
            this.btnAuthorized.Text = "核可作業";
            this.btnAuthorized.Click += new System.EventHandler(this.btnAuthorized_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.AutoSize = true;
            this.btnApproved.BackColor = System.Drawing.Color.Transparent;
            this.btnApproved.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnApproved.Location = new System.Drawing.Point(256, 487);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(75, 25);
            this.btnApproved.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnApproved.TabIndex = 10;
            this.btnApproved.Text = "登錄作業";
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.filterOrganizers);
            this.groupPanel1.Controls.Add(this.filterSemester);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.filterSchoolYear);
            this.groupPanel1.Controls.Add(this.lbEnd);
            this.groupPanel1.Controls.Add(this.lbStart);
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(711, 61);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 11;
            this.groupPanel1.Text = "篩選條件";
            // 
            // filterOrganizers
            // 
            this.filterOrganizers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.filterOrganizers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.filterOrganizers.DisplayMember = "Text";
            this.filterOrganizers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterOrganizers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterOrganizers.FormattingEnabled = true;
            this.filterOrganizers.ItemHeight = 19;
            this.filterOrganizers.Location = new System.Drawing.Point(360, 3);
            this.filterOrganizers.Name = "filterOrganizers";
            this.filterOrganizers.Size = new System.Drawing.Size(138, 25);
            this.filterOrganizers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.filterOrganizers.TabIndex = 42;
            // 
            // filterSemester
            // 
            this.filterSemester.DisplayMember = "Text";
            this.filterSemester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterSemester.FormattingEnabled = true;
            this.filterSemester.ItemHeight = 19;
            this.filterSemester.Location = new System.Drawing.Point(213, 3);
            this.filterSemester.Name = "filterSemester";
            this.filterSemester.Size = new System.Drawing.Size(75, 25);
            this.filterSemester.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.filterSemester.TabIndex = 14;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(294, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 41;
            this.labelX3.Text = "主辦單位";
            // 
            // filterSchoolYear
            // 
            this.filterSchoolYear.DisplayMember = "Text";
            this.filterSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterSchoolYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterSchoolYear.FormattingEnabled = true;
            this.filterSchoolYear.ItemHeight = 19;
            this.filterSchoolYear.Location = new System.Drawing.Point(56, 3);
            this.filterSchoolYear.Name = "filterSchoolYear";
            this.filterSchoolYear.Size = new System.Drawing.Size(111, 25);
            this.filterSchoolYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.filterSchoolYear.TabIndex = 13;
            // 
            // lbEnd
            // 
            this.lbEnd.AutoSize = true;
            // 
            // 
            // 
            this.lbEnd.BackgroundStyle.Class = "";
            this.lbEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbEnd.Location = new System.Drawing.Point(173, 3);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(34, 21);
            this.lbEnd.TabIndex = 2;
            this.lbEnd.Text = "學期";
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            // 
            // 
            // 
            this.lbStart.BackgroundStyle.Class = "";
            this.lbStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbStart.Location = new System.Drawing.Point(3, 3);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(47, 21);
            this.lbStart.TabIndex = 0;
            this.lbStart.Text = "學年度";
            // 
            // ColRegistStartTime
            // 
            this.ColRegistStartTime.DataPropertyName = "RegistStartTime";
            this.ColRegistStartTime.HeaderText = "報名開始時間";
            this.ColRegistStartTime.Name = "ColRegistStartTime";
            this.ColRegistStartTime.ReadOnly = true;
            this.ColRegistStartTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRegistStartTime.Width = 120;
            // 
            // ColRegistEndTime
            // 
            this.ColRegistEndTime.DataPropertyName = "RegistEndTime";
            this.ColRegistEndTime.HeaderText = "報名結束時間";
            this.ColRegistEndTime.Name = "ColRegistEndTime";
            this.ColRegistEndTime.ReadOnly = true;
            this.ColRegistEndTime.Width = 120;
            // 
            // ColOrganizers
            // 
            this.ColOrganizers.DataPropertyName = "Organizers";
            this.ColOrganizers.HeaderText = "主辦單位";
            this.ColOrganizers.Name = "ColOrganizers";
            this.ColOrganizers.ReadOnly = true;
            this.ColOrganizers.Width = 120;
            // 
            // ColOccurDate
            // 
            this.ColOccurDate.DataPropertyName = "OccurDate";
            this.ColOccurDate.HeaderText = "日期";
            this.ColOccurDate.Name = "ColOccurDate";
            this.ColOccurDate.ReadOnly = true;
            // 
            // ColLocation
            // 
            this.ColLocation.DataPropertyName = "Location";
            this.ColLocation.HeaderText = "地點";
            this.ColLocation.Name = "ColLocation";
            this.ColLocation.ReadOnly = true;
            // 
            // ColCreateBy
            // 
            this.ColCreateBy.DataPropertyName = "CreateBy";
            this.ColCreateBy.HeaderText = "開設人帳號";
            this.ColCreateBy.Name = "ColCreateBy";
            this.ColCreateBy.ReadOnly = true;
            // 
            // ColIsAuthorized
            // 
            this.ColIsAuthorized.DataPropertyName = "IsAuthorizedText";
            this.ColIsAuthorized.HeaderText = "完成核可作業";
            this.ColIsAuthorized.Name = "ColIsAuthorized";
            this.ColIsAuthorized.ReadOnly = true;
            this.ColIsAuthorized.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColApproved
            // 
            this.ColApproved.DataPropertyName = "IsApprovedText";
            this.ColApproved.HeaderText = "完成登錄作業";
            this.ColApproved.Name = "ColApproved";
            this.ColApproved.ReadOnly = true;
            this.ColApproved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColExpertedHours
            // 
            // 
            // 
            // 
            this.ColExpertedHours.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ColExpertedHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColExpertedHours.DataPropertyName = "ExpectedHours";
            this.ColExpertedHours.DisplayFormat = "N1";
            this.ColExpertedHours.HeaderText = "預計時數";
            this.ColExpertedHours.Increment = 1D;
            this.ColExpertedHours.Name = "ColExpertedHours";
            this.ColExpertedHours.ReadOnly = true;
            this.ColExpertedHours.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColReason
            // 
            this.ColReason.DataPropertyName = "Reason";
            this.ColReason.HeaderText = "服務事由";
            this.ColReason.Name = "ColReason";
            this.ColReason.ReadOnly = true;
            this.ColReason.Width = 200;
            // 
            // ColParticipateLimit
            // 
            // 
            // 
            // 
            this.ColParticipateLimit.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ColParticipateLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColParticipateLimit.DataPropertyName = "ParticipateLimit";
            this.ColParticipateLimit.HeaderText = "人數上限";
            this.ColParticipateLimit.Name = "ColParticipateLimit";
            this.ColParticipateLimit.ReadOnly = true;
            this.ColParticipateLimit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColRemark
            // 
            this.ColRemark.DataPropertyName = "Remark";
            this.ColRemark.HeaderText = "備註";
            this.ColRemark.Name = "ColRemark";
            this.ColRemark.ReadOnly = true;
            this.ColRemark.Width = 80;
            // 
            // CreationItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 520);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnAuthorized);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNew);
            this.DoubleBuffered = true;
            this.MaximizeBox = true;
            this.Name = "CreationItem";
            this.Text = "服務學習線上開設";
            this.Load += new System.EventHandler(this.ServiceLearningBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.ButtonX btnApproved;
        private DevComponents.DotNetBar.ButtonX btnAuthorized;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX lbEnd;
        private DevComponents.DotNetBar.LabelX lbStart;
        private DevComponents.DotNetBar.Controls.ComboBoxEx filterSchoolYear;
        private DevComponents.DotNetBar.Controls.ComboBoxEx filterSemester;
        private System.Windows.Forms.ToolStripMenuItem 列印點名單ToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx filterOrganizers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRegistStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRegistEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrganizers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOccurDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsAuthorized;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColApproved;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn ColExpertedHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReason;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn ColParticipateLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemark;
    }
}
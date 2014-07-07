namespace K12.Service.Learning.CreationItems
{
    partial class AuthorizeForm
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
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.ColGradeYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSchoolNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCanParticipate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.可ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.不可ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.ColGradeYear,
            this.ColClass,
            this.ColSeatNo,
            this.ColName,
            this.ColSchoolNumber,
            this.ColCanParticipate});
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
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(593, 475);
            this.dataGridViewX1.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnExit.Location = new System.Drawing.Point(530, 496);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(449, 496);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ColGradeYear
            // 
            this.ColGradeYear.HeaderText = "年級";
            this.ColGradeYear.Name = "ColGradeYear";
            this.ColGradeYear.ReadOnly = true;
            // 
            // ColClass
            // 
            this.ColClass.HeaderText = "班級";
            this.ColClass.Name = "ColClass";
            this.ColClass.ReadOnly = true;
            // 
            // ColSeatNo
            // 
            this.ColSeatNo.HeaderText = "座號";
            this.ColSeatNo.Name = "ColSeatNo";
            this.ColSeatNo.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "姓名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColSchoolNumber
            // 
            this.ColSchoolNumber.HeaderText = "學號";
            this.ColSchoolNumber.Name = "ColSchoolNumber";
            this.ColSchoolNumber.ReadOnly = true;
            // 
            // ColCanParticipate
            // 
            this.ColCanParticipate.DataPropertyName = "CanParticipate";
            this.ColCanParticipate.FalseValue = "False";
            this.ColCanParticipate.HeaderText = "核可";
            this.ColCanParticipate.Name = "ColCanParticipate";
            this.ColCanParticipate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCanParticipate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCanParticipate.TrueValue = "True";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.可ToolStripMenuItem,
            this.不可ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 可ToolStripMenuItem
            // 
            this.可ToolStripMenuItem.Name = "可ToolStripMenuItem";
            this.可ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.可ToolStripMenuItem.Text = "可";
            this.可ToolStripMenuItem.Click += new System.EventHandler(this.可ToolStripMenuItem_Click);
            // 
            // 不可ToolStripMenuItem
            // 
            this.不可ToolStripMenuItem.Name = "不可ToolStripMenuItem";
            this.不可ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.不可ToolStripMenuItem.Text = "不可";
            this.不可ToolStripMenuItem.Click += new System.EventHandler(this.不可ToolStripMenuItem_Click);
            // 
            // AuthorizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 533);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.Name = "AuthorizeForm";
            this.Text = "核可作業";
            this.Load += new System.EventHandler(this.AuthorizeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGradeYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSchoolNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCanParticipate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 可ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 不可ToolStripMenuItem;
    }
}
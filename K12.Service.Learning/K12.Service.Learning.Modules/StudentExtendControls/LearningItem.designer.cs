namespace K12.Service.Learning.Modules
{
    partial class LearningItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new K12.Service.Learning.Modules.ListViewEx();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.colSchoolYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSemeater = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOccurDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegisterDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrganizers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView
            // 
            // 
            // 
            // 
            this.listView.Border.Class = "ListViewBorder";
            this.listView.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSchoolYear,
            this.colSemeater,
            this.colOccurDate,
            this.colReason,
            this.colHours,
            this.colOrganizers,
            this.colRegisterDate,
            this.colRemark});
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(13, 8);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(524, 245);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(175, 259);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "刪除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(94, 259);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(13, 259);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnView.Location = new System.Drawing.Point(13, 259);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "檢視";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // colSchoolYear
            // 
            this.colSchoolYear.Text = "學年度";
            // 
            // colSemeater
            // 
            this.colSemeater.Text = "學期";
            this.colSemeater.Width = 45;
            // 
            // colOccurDate
            // 
            this.colOccurDate.Text = "發生日期";
            this.colOccurDate.Width = 110;
            // 
            // colReason
            // 
            this.colReason.Text = "事由";
            this.colReason.Width = 120;
            // 
            // colHours
            // 
            this.colHours.Text = "時數";
            this.colHours.Width = 45;
            // 
            // colRegisterDate
            // 
            this.colRegisterDate.Text = "登錄日期";
            this.colRegisterDate.Width = 110;
            // 
            // colRemark
            // 
            this.colRemark.Text = "備註";
            // 
            // colOrganizers
            // 
            this.colOrganizers.Text = "主辦單位";
            this.colOrganizers.Width = 80;
            // 
            // LearningItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Name = "LearningItem";
            this.Size = new System.Drawing.Size(550, 290);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewEx listView;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnView;
        private System.Windows.Forms.ColumnHeader colSchoolYear;
        private System.Windows.Forms.ColumnHeader colSemeater;
        private System.Windows.Forms.ColumnHeader colOccurDate;
        private System.Windows.Forms.ColumnHeader colReason;
        private System.Windows.Forms.ColumnHeader colHours;
        private System.Windows.Forms.ColumnHeader colRegisterDate;
        private System.Windows.Forms.ColumnHeader colRemark;
        private System.Windows.Forms.ColumnHeader colOrganizers;

    }
}

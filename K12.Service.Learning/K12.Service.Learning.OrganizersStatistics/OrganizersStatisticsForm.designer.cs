namespace K12.SL.OrganizersStatistics
{
    partial class OrganizersStatisticsForm
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.加入學生待處理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空待處理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgSelectSchoolYear = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbSemester = new DevComponents.DotNetBar.LabelX();
            this.lbSchoolYear = new DevComponents.DotNetBar.LabelX();
            this.intSemester = new DevComponents.Editors.IntegerInput();
            this.intSchoolYear = new DevComponents.Editors.IntegerInput();
            this.gpSelect1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbOrganizer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbReason = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbDateTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbSchoolYear = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnStart = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.bgSelect2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gbDateTime = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.bgSelectSchoolYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).BeginInit();
            this.gpSelect1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            this.bgSelect2.SuspendLayout();
            this.gbDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
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
            this.dataGridViewX1.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(578, 344);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "主辦單位";
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "人數";
            this.Column2.Name = "Column2";
            this.Column2.Width = 65;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "人次";
            this.Column3.Name = "Column3";
            this.Column3.Width = 65;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "總時數";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加入學生待處理ToolStripMenuItem,
            this.清空待處理ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 48);
            // 
            // 加入學生待處理ToolStripMenuItem
            // 
            this.加入學生待處理ToolStripMenuItem.Name = "加入學生待處理ToolStripMenuItem";
            this.加入學生待處理ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.加入學生待處理ToolStripMenuItem.Text = "加入學生待處理";
            this.加入學生待處理ToolStripMenuItem.Click += new System.EventHandler(this.加入學生待處理ToolStripMenuItem_Click);
            // 
            // 清空待處理ToolStripMenuItem
            // 
            this.清空待處理ToolStripMenuItem.Name = "清空待處理ToolStripMenuItem";
            this.清空待處理ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.清空待處理ToolStripMenuItem.Text = "清空學生待處理";
            this.清空待處理ToolStripMenuItem.Click += new System.EventHandler(this.清空待處理ToolStripMenuItem_Click);
            // 
            // bgSelectSchoolYear
            // 
            this.bgSelectSchoolYear.BackColor = System.Drawing.Color.Transparent;
            this.bgSelectSchoolYear.CanvasColor = System.Drawing.SystemColors.Control;
            this.bgSelectSchoolYear.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bgSelectSchoolYear.Controls.Add(this.lbSemester);
            this.bgSelectSchoolYear.Controls.Add(this.lbSchoolYear);
            this.bgSelectSchoolYear.Controls.Add(this.intSemester);
            this.bgSelectSchoolYear.Controls.Add(this.intSchoolYear);
            this.bgSelectSchoolYear.Location = new System.Drawing.Point(204, 12);
            this.bgSelectSchoolYear.Name = "bgSelectSchoolYear";
            this.bgSelectSchoolYear.Size = new System.Drawing.Size(140, 100);
            // 
            // 
            // 
            this.bgSelectSchoolYear.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.bgSelectSchoolYear.Style.BackColorGradientAngle = 90;
            this.bgSelectSchoolYear.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.bgSelectSchoolYear.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelectSchoolYear.Style.BorderBottomWidth = 1;
            this.bgSelectSchoolYear.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.bgSelectSchoolYear.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelectSchoolYear.Style.BorderLeftWidth = 1;
            this.bgSelectSchoolYear.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelectSchoolYear.Style.BorderRightWidth = 1;
            this.bgSelectSchoolYear.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelectSchoolYear.Style.BorderTopWidth = 1;
            this.bgSelectSchoolYear.Style.Class = "";
            this.bgSelectSchoolYear.Style.CornerDiameter = 4;
            this.bgSelectSchoolYear.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.bgSelectSchoolYear.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.bgSelectSchoolYear.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.bgSelectSchoolYear.StyleMouseDown.Class = "";
            this.bgSelectSchoolYear.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bgSelectSchoolYear.StyleMouseOver.Class = "";
            this.bgSelectSchoolYear.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bgSelectSchoolYear.TabIndex = 1;
            this.bgSelectSchoolYear.Text = "學年度/學期";
            // 
            // lbSemester
            // 
            this.lbSemester.AutoSize = true;
            // 
            // 
            // 
            this.lbSemester.BackgroundStyle.Class = "";
            this.lbSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSemester.Location = new System.Drawing.Point(10, 42);
            this.lbSemester.Name = "lbSemester";
            this.lbSemester.Size = new System.Drawing.Size(34, 21);
            this.lbSemester.TabIndex = 3;
            this.lbSemester.Text = "學期";
            // 
            // lbSchoolYear
            // 
            this.lbSchoolYear.AutoSize = true;
            // 
            // 
            // 
            this.lbSchoolYear.BackgroundStyle.Class = "";
            this.lbSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSchoolYear.Location = new System.Drawing.Point(10, 10);
            this.lbSchoolYear.Name = "lbSchoolYear";
            this.lbSchoolYear.Size = new System.Drawing.Size(47, 21);
            this.lbSchoolYear.TabIndex = 2;
            this.lbSchoolYear.Text = "學年度";
            // 
            // intSemester
            // 
            // 
            // 
            // 
            this.intSemester.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSemester.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSemester.Location = new System.Drawing.Point(59, 40);
            this.intSemester.MaxValue = 2;
            this.intSemester.MinValue = 1;
            this.intSemester.Name = "intSemester";
            this.intSemester.ShowUpDown = true;
            this.intSemester.Size = new System.Drawing.Size(66, 25);
            this.intSemester.TabIndex = 1;
            this.intSemester.Value = 1;
            // 
            // intSchoolYear
            // 
            // 
            // 
            // 
            this.intSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSchoolYear.Location = new System.Drawing.Point(59, 8);
            this.intSchoolYear.MaxValue = 999;
            this.intSchoolYear.MinValue = 90;
            this.intSchoolYear.Name = "intSchoolYear";
            this.intSchoolYear.ShowUpDown = true;
            this.intSchoolYear.Size = new System.Drawing.Size(66, 25);
            this.intSchoolYear.TabIndex = 0;
            this.intSchoolYear.Value = 90;
            // 
            // gpSelect1
            // 
            this.gpSelect1.BackColor = System.Drawing.Color.Transparent;
            this.gpSelect1.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpSelect1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpSelect1.Controls.Add(this.cbOrganizer);
            this.gpSelect1.Controls.Add(this.cbReason);
            this.gpSelect1.Location = new System.Drawing.Point(12, 12);
            this.gpSelect1.Name = "gpSelect1";
            this.gpSelect1.Size = new System.Drawing.Size(92, 100);
            // 
            // 
            // 
            this.gpSelect1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpSelect1.Style.BackColorGradientAngle = 90;
            this.gpSelect1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpSelect1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSelect1.Style.BorderBottomWidth = 1;
            this.gpSelect1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpSelect1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSelect1.Style.BorderLeftWidth = 1;
            this.gpSelect1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSelect1.Style.BorderRightWidth = 1;
            this.gpSelect1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSelect1.Style.BorderTopWidth = 1;
            this.gpSelect1.Style.Class = "";
            this.gpSelect1.Style.CornerDiameter = 4;
            this.gpSelect1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpSelect1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpSelect1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpSelect1.StyleMouseDown.Class = "";
            this.gpSelect1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpSelect1.StyleMouseOver.Class = "";
            this.gpSelect1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpSelect1.TabIndex = 2;
            this.gpSelect1.Text = "條件";
            // 
            // cbOrganizer
            // 
            this.cbOrganizer.AutoSize = true;
            this.cbOrganizer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbOrganizer.BackgroundStyle.Class = "";
            this.cbOrganizer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbOrganizer.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbOrganizer.Checked = true;
            this.cbOrganizer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOrganizer.CheckValue = "Y";
            this.cbOrganizer.Location = new System.Drawing.Point(3, 12);
            this.cbOrganizer.Name = "cbOrganizer";
            this.cbOrganizer.Size = new System.Drawing.Size(80, 21);
            this.cbOrganizer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbOrganizer.TabIndex = 0;
            this.cbOrganizer.Text = "主辦單位";
            this.cbOrganizer.CheckedChanged += new System.EventHandler(this.cbOrganizer_CheckedChanged);
            // 
            // cbReason
            // 
            this.cbReason.AutoSize = true;
            this.cbReason.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbReason.BackgroundStyle.Class = "";
            this.cbReason.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbReason.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbReason.Location = new System.Drawing.Point(3, 41);
            this.cbReason.Name = "cbReason";
            this.cbReason.Size = new System.Drawing.Size(54, 21);
            this.cbReason.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbReason.TabIndex = 1;
            this.cbReason.Text = "事由";
            // 
            // dateTimeInput2
            // 
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(44, 40);
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.Class = "";
            this.dateTimeInput2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateTimeInput2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.DayNames = new string[] {
        "日",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六"};
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2013, 7, 1, 0, 0, 0, 0);
            this.dateTimeInput2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateTimeInput2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput2.Name = "dateTimeInput2";
            this.dateTimeInput2.Size = new System.Drawing.Size(130, 25);
            this.dateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput2.TabIndex = 3;
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(44, 7);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DayNames = new string[] {
        "日",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六"};
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2013, 7, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(130, 25);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 2;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(7, 42);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "結束";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(7, 9);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "開始";
            // 
            // cbDateTime
            // 
            this.cbDateTime.AutoSize = true;
            this.cbDateTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbDateTime.BackgroundStyle.Class = "";
            this.cbDateTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDateTime.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbDateTime.Location = new System.Drawing.Point(8, 44);
            this.cbDateTime.Name = "cbDateTime";
            this.cbDateTime.Size = new System.Drawing.Size(54, 21);
            this.cbDateTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDateTime.TabIndex = 1;
            this.cbDateTime.TabStop = false;
            this.cbDateTime.Text = "日期";
            // 
            // cbSchoolYear
            // 
            this.cbSchoolYear.AutoSize = true;
            this.cbSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbSchoolYear.BackgroundStyle.Class = "";
            this.cbSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbSchoolYear.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbSchoolYear.Checked = true;
            this.cbSchoolYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSchoolYear.CheckValue = "Y";
            this.cbSchoolYear.Location = new System.Drawing.Point(8, 12);
            this.cbSchoolYear.Name = "cbSchoolYear";
            this.cbSchoolYear.Size = new System.Drawing.Size(67, 21);
            this.cbSchoolYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbSchoolYear.TabIndex = 0;
            this.cbSchoolYear.Text = "學年期";
            this.cbSchoolYear.CheckedChanged += new System.EventHandler(this.checkBoxX4_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStart.Location = new System.Drawing.Point(546, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(44, 88);
            this.btnStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "開始查詢";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(515, 468);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.AutoSize = true;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Location = new System.Drawing.Point(12, 468);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 25);
            this.btnReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "匯出";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // bgSelect2
            // 
            this.bgSelect2.BackColor = System.Drawing.Color.Transparent;
            this.bgSelect2.CanvasColor = System.Drawing.SystemColors.Control;
            this.bgSelect2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bgSelect2.Controls.Add(this.cbSchoolYear);
            this.bgSelect2.Controls.Add(this.cbDateTime);
            this.bgSelect2.Location = new System.Drawing.Point(110, 12);
            this.bgSelect2.Name = "bgSelect2";
            this.bgSelect2.Size = new System.Drawing.Size(88, 100);
            // 
            // 
            // 
            this.bgSelect2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.bgSelect2.Style.BackColorGradientAngle = 90;
            this.bgSelect2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.bgSelect2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelect2.Style.BorderBottomWidth = 1;
            this.bgSelect2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.bgSelect2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelect2.Style.BorderLeftWidth = 1;
            this.bgSelect2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelect2.Style.BorderRightWidth = 1;
            this.bgSelect2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bgSelect2.Style.BorderTopWidth = 1;
            this.bgSelect2.Style.Class = "";
            this.bgSelect2.Style.CornerDiameter = 4;
            this.bgSelect2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.bgSelect2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.bgSelect2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.bgSelect2.StyleMouseDown.Class = "";
            this.bgSelect2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bgSelect2.StyleMouseOver.Class = "";
            this.bgSelect2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bgSelect2.TabIndex = 6;
            this.bgSelect2.Text = "依據";
            // 
            // gbDateTime
            // 
            this.gbDateTime.BackColor = System.Drawing.Color.Transparent;
            this.gbDateTime.CanvasColor = System.Drawing.SystemColors.Control;
            this.gbDateTime.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gbDateTime.Controls.Add(this.dateTimeInput2);
            this.gbDateTime.Controls.Add(this.dateTimeInput1);
            this.gbDateTime.Controls.Add(this.labelX4);
            this.gbDateTime.Controls.Add(this.labelX3);
            this.gbDateTime.Location = new System.Drawing.Point(350, 12);
            this.gbDateTime.Name = "gbDateTime";
            this.gbDateTime.Size = new System.Drawing.Size(190, 100);
            // 
            // 
            // 
            this.gbDateTime.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gbDateTime.Style.BackColorGradientAngle = 90;
            this.gbDateTime.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gbDateTime.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbDateTime.Style.BorderBottomWidth = 1;
            this.gbDateTime.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gbDateTime.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbDateTime.Style.BorderLeftWidth = 1;
            this.gbDateTime.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbDateTime.Style.BorderRightWidth = 1;
            this.gbDateTime.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbDateTime.Style.BorderTopWidth = 1;
            this.gbDateTime.Style.Class = "";
            this.gbDateTime.Style.CornerDiameter = 4;
            this.gbDateTime.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gbDateTime.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gbDateTime.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gbDateTime.StyleMouseDown.Class = "";
            this.gbDateTime.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gbDateTime.StyleMouseOver.Class = "";
            this.gbDateTime.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gbDateTime.TabIndex = 2;
            this.gbDateTime.Text = "日期";
            // 
            // OrganizersStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 501);
            this.Controls.Add(this.bgSelect2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbDateTime);
            this.Controls.Add(this.gpSelect1);
            this.Controls.Add(this.bgSelectSchoolYear);
            this.Controls.Add(this.dataGridViewX1);
            this.Name = "OrganizersStatisticsForm";
            this.Text = "主辦單位與事由統計";
            this.Load += new System.EventHandler(this.OrganizersStatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.bgSelectSchoolYear.ResumeLayout(false);
            this.bgSelectSchoolYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).EndInit();
            this.gpSelect1.ResumeLayout(false);
            this.gpSelect1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            this.bgSelect2.ResumeLayout(false);
            this.bgSelect2.PerformLayout();
            this.gbDateTime.ResumeLayout(false);
            this.gbDateTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.GroupPanel bgSelectSchoolYear;
        private DevComponents.DotNetBar.Controls.GroupPanel gpSelect1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbOrganizer;
        private DevComponents.DotNetBar.LabelX lbSemester;
        private DevComponents.DotNetBar.LabelX lbSchoolYear;
        private DevComponents.Editors.IntegerInput intSemester;
        private DevComponents.Editors.IntegerInput intSchoolYear;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbReason;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbDateTime;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbSchoolYear;
        private DevComponents.DotNetBar.ButtonX btnStart;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.Controls.GroupPanel bgSelect2;
        private DevComponents.DotNetBar.Controls.GroupPanel gbDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 加入學生待處理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空待處理ToolStripMenuItem;
    }
}
namespace K12.Service.Learning.CreationItems
{
    partial class Item
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
            this.inpOrganizers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.inpReason = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.inpSemester = new DevComponents.Editors.IntegerInput();
            this.inpSchoolYear = new DevComponents.Editors.IntegerInput();
            this.inpOccurDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lbl1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.inpRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.inpLocation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.inpRegistEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.inpRegistStartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.inpEpectedHours = new DevComponents.Editors.DoubleInput();
            this.inpParticipateLimit = new DevComponents.Editors.IntegerInput();
            ((System.ComponentModel.ISupportInitialize)(this.inpSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpOccurDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpRegistEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpRegistStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpEpectedHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpParticipateLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // inpOrganizers
            // 
            this.inpOrganizers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.inpOrganizers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.inpOrganizers.DisplayMember = "Text";
            this.inpOrganizers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.inpOrganizers.FormattingEnabled = true;
            this.inpOrganizers.ItemHeight = 19;
            this.inpOrganizers.Location = new System.Drawing.Point(108, 46);
            this.inpOrganizers.Name = "inpOrganizers";
            this.inpOrganizers.Size = new System.Drawing.Size(138, 25);
            this.inpOrganizers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.inpOrganizers.TabIndex = 3;
            // 
            // inpReason
            // 
            // 
            // 
            // 
            this.inpReason.Border.Class = "TextBoxBorder";
            this.inpReason.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpReason.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.inpReason.Location = new System.Drawing.Point(107, 256);
            this.inpReason.MaxLength = 100;
            this.inpReason.Multiline = true;
            this.inpReason.Name = "inpReason";
            this.inpReason.Size = new System.Drawing.Size(321, 84);
            this.inpReason.TabIndex = 10;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnExit.Location = new System.Drawing.Point(354, 346);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(273, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // inpSemester
            // 
            this.inpSemester.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.inpSemester.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inpSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpSemester.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.inpSemester.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.inpSemester.Location = new System.Drawing.Point(245, 12);
            this.inpSemester.MaxValue = 2;
            this.inpSemester.MinValue = 1;
            this.inpSemester.Name = "inpSemester";
            this.inpSemester.ShowUpDown = true;
            this.inpSemester.Size = new System.Drawing.Size(80, 25);
            this.inpSemester.TabIndex = 2;
            this.inpSemester.Value = 1;
            // 
            // inpSchoolYear
            // 
            this.inpSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.inpSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inpSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.inpSchoolYear.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.inpSchoolYear.Location = new System.Drawing.Point(107, 12);
            this.inpSchoolYear.MaxValue = 999;
            this.inpSchoolYear.MinValue = 90;
            this.inpSchoolYear.Name = "inpSchoolYear";
            this.inpSchoolYear.ShowUpDown = true;
            this.inpSchoolYear.Size = new System.Drawing.Size(86, 25);
            this.inpSchoolYear.TabIndex = 1;
            this.inpSchoolYear.Value = 90;
            // 
            // inpOccurDate
            // 
            this.inpOccurDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.inpOccurDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inpOccurDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpOccurDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.inpOccurDate.ButtonDropDown.Visible = true;
            this.inpOccurDate.ButtonFreeText.Checked = true;
            this.inpOccurDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.inpOccurDate.FreeTextEntryMode = true;
            this.inpOccurDate.IsPopupCalendarOpen = false;
            this.inpOccurDate.Location = new System.Drawing.Point(107, 137);
            this.inpOccurDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.inpOccurDate.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.inpOccurDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inpOccurDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.inpOccurDate.MonthCalendar.BackgroundStyle.Class = "";
            this.inpOccurDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpOccurDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.inpOccurDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpOccurDate.MonthCalendar.DayNames = new string[] {
        "日",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六"};
            this.inpOccurDate.MonthCalendar.DisplayMonth = new System.DateTime(2009, 10, 1, 0, 0, 0, 0);
            this.inpOccurDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.inpOccurDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inpOccurDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.inpOccurDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.inpOccurDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.inpOccurDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.inpOccurDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpOccurDate.MonthCalendar.TodayButtonVisible = true;
            this.inpOccurDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.inpOccurDate.Name = "inpOccurDate";
            this.inpOccurDate.Size = new System.Drawing.Size(138, 25);
            this.inpOccurDate.TabIndex = 6;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX7.Location = new System.Drawing.Point(12, 255);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(60, 21);
            this.labelX7.TabIndex = 26;
            this.labelX7.Text = "服務事由";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX6.Location = new System.Drawing.Point(12, 139);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(34, 21);
            this.labelX6.TabIndex = 36;
            this.labelX6.Text = "日期";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl1.BackgroundStyle.Class = "";
            this.lbl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.lbl1.Location = new System.Drawing.Point(12, 201);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(60, 21);
            this.lbl1.TabIndex = 22;
            this.lbl1.Text = "預計時數";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX2.Location = new System.Drawing.Point(207, 14);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 21);
            this.labelX2.TabIndex = 32;
            this.labelX2.Text = "學期";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX1.Location = new System.Drawing.Point(12, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(54, 21);
            this.labelX1.TabIndex = 30;
            this.labelX1.Text = "學 年 度";
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
            this.labelX3.Location = new System.Drawing.Point(12, 49);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 21;
            this.labelX3.Text = "主辦單位";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX4.Location = new System.Drawing.Point(12, 76);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(87, 21);
            this.labelX4.TabIndex = 41;
            this.labelX4.Text = "報名開始時間";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX5.Location = new System.Drawing.Point(12, 110);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(87, 21);
            this.labelX5.TabIndex = 44;
            this.labelX5.Text = "報名結束時間";
            // 
            // inpRemark
            // 
            // 
            // 
            // 
            this.inpRemark.Border.Class = "TextBoxBorder";
            this.inpRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRemark.Location = new System.Drawing.Point(108, 346);
            this.inpRemark.Name = "inpRemark";
            this.inpRemark.Size = new System.Drawing.Size(138, 25);
            this.inpRemark.TabIndex = 11;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(12, 350);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(34, 21);
            this.labelX8.TabIndex = 45;
            this.labelX8.Text = "備註";
            // 
            // inpLocation
            // 
            // 
            // 
            // 
            this.inpLocation.Border.Class = "TextBoxBorder";
            this.inpLocation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpLocation.Location = new System.Drawing.Point(107, 167);
            this.inpLocation.Name = "inpLocation";
            this.inpLocation.Size = new System.Drawing.Size(138, 25);
            this.inpLocation.TabIndex = 7;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(12, 166);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(34, 21);
            this.labelX10.TabIndex = 49;
            this.labelX10.Text = "地點";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.labelX9.Location = new System.Drawing.Point(12, 228);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(60, 21);
            this.labelX9.TabIndex = 51;
            this.labelX9.Text = "人數上限";
            // 
            // inpRegistEndTime
            // 
            this.inpRegistEndTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.inpRegistEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inpRegistEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.inpRegistEndTime.ButtonDropDown.Visible = true;
            this.inpRegistEndTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.inpRegistEndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.inpRegistEndTime.IsPopupCalendarOpen = false;
            this.inpRegistEndTime.Location = new System.Drawing.Point(107, 106);
            // 
            // 
            // 
            this.inpRegistEndTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inpRegistEndTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.inpRegistEndTime.MonthCalendar.BackgroundStyle.Class = "";
            this.inpRegistEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.inpRegistEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2014, 6, 1, 0, 0, 0, 0);
            this.inpRegistEndTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.inpRegistEndTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inpRegistEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.inpRegistEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.inpRegistEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.inpRegistEndTime.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.inpRegistEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistEndTime.MonthCalendar.TodayButtonVisible = true;
            this.inpRegistEndTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.inpRegistEndTime.Name = "inpRegistEndTime";
            this.inpRegistEndTime.Size = new System.Drawing.Size(200, 25);
            this.inpRegistEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.inpRegistEndTime.TabIndex = 5;
            // 
            // inpRegistStartTime
            // 
            this.inpRegistStartTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.inpRegistStartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inpRegistStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.inpRegistStartTime.ButtonDropDown.Visible = true;
            this.inpRegistStartTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.inpRegistStartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.inpRegistStartTime.IsPopupCalendarOpen = false;
            this.inpRegistStartTime.Location = new System.Drawing.Point(107, 76);
            // 
            // 
            // 
            this.inpRegistStartTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inpRegistStartTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.inpRegistStartTime.MonthCalendar.BackgroundStyle.Class = "";
            this.inpRegistStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistStartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.inpRegistStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistStartTime.MonthCalendar.DisplayMonth = new System.DateTime(2014, 6, 1, 0, 0, 0, 0);
            this.inpRegistStartTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.inpRegistStartTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.inpRegistStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.inpRegistStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.inpRegistStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.inpRegistStartTime.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.inpRegistStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpRegistStartTime.MonthCalendar.TodayButtonVisible = true;
            this.inpRegistStartTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.inpRegistStartTime.Name = "inpRegistStartTime";
            this.inpRegistStartTime.Size = new System.Drawing.Size(200, 25);
            this.inpRegistStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.inpRegistStartTime.TabIndex = 4;
            // 
            // inpEpectedHours
            // 
            this.inpEpectedHours.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.inpEpectedHours.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inpEpectedHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpEpectedHours.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.inpEpectedHours.DisplayFormat = "N1";
            this.inpEpectedHours.Increment = 0.5D;
            this.inpEpectedHours.Location = new System.Drawing.Point(107, 197);
            this.inpEpectedHours.Name = "inpEpectedHours";
            this.inpEpectedHours.ShowUpDown = true;
            this.inpEpectedHours.Size = new System.Drawing.Size(80, 25);
            this.inpEpectedHours.TabIndex = 8;
            // 
            // inpParticipateLimit
            // 
            this.inpParticipateLimit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.inpParticipateLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.inpParticipateLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.inpParticipateLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.inpParticipateLimit.Location = new System.Drawing.Point(107, 228);
            this.inpParticipateLimit.Name = "inpParticipateLimit";
            this.inpParticipateLimit.ShowUpDown = true;
            this.inpParticipateLimit.Size = new System.Drawing.Size(80, 25);
            this.inpParticipateLimit.TabIndex = 9;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 381);
            this.Controls.Add(this.inpParticipateLimit);
            this.Controls.Add(this.inpEpectedHours);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.inpLocation);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.inpRemark);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.inpRegistEndTime);
            this.Controls.Add(this.inpRegistStartTime);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.inpOrganizers);
            this.Controls.Add(this.inpReason);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.inpSemester);
            this.Controls.Add(this.inpSchoolYear);
            this.Controls.Add(this.inpOccurDate);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX3);
            this.DoubleBuffered = true;
            this.Name = "Item";
            this.Text = "Item";
            ((System.ComponentModel.ISupportInitialize)(this.inpSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpOccurDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpRegistEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpRegistStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpEpectedHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpParticipateLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx inpOrganizers;
        private DevComponents.DotNetBar.Controls.TextBoxX inpReason;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.Editors.IntegerInput inpSemester;
        private DevComponents.Editors.IntegerInput inpSchoolYear;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput inpOccurDate;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lbl1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX inpRemark;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX inpLocation;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput inpRegistEndTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput inpRegistStartTime;
        private DevComponents.Editors.DoubleInput inpEpectedHours;
        private DevComponents.Editors.IntegerInput inpParticipateLimit;
    }
}
namespace K12.Service.Learning.Modules
{
    partial class LearningForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtReason = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lbl1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeInput2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.intSchoolYear = new DevComponents.Editors.IntegerInput();
            this.intSemester = new DevComponents.Editors.IntegerInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbOrganizers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbIAndE = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnExit.Location = new System.Drawing.Point(351, 272);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(270, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReason
            // 
            // 
            // 
            // 
            this.txtReason.Border.Class = "TextBoxBorder";
            this.txtReason.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReason.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txtReason.Location = new System.Drawing.Point(75, 187);
            this.txtReason.MaxLength = 100;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(353, 69);
            this.txtReason.TabIndex = 1;
            this.txtReason.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReason_KeyUp);
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
            this.labelX7.ForeColor = System.Drawing.Color.Red;
            this.labelX7.Location = new System.Drawing.Point(12, 187);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(60, 21);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "事　　由";
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
            this.labelX6.ForeColor = System.Drawing.Color.Red;
            this.labelX6.Location = new System.Drawing.Point(12, 49);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(60, 21);
            this.labelX6.TabIndex = 8;
            this.labelX6.Text = "發生日期";
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
            this.lbl1.ForeColor = System.Drawing.Color.Red;
            this.lbl1.Location = new System.Drawing.Point(12, 119);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(60, 21);
            this.lbl1.TabIndex = 16;
            this.lbl1.Text = "時　　數";
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
            this.labelX2.Location = new System.Drawing.Point(228, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "學　　期";
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
            this.labelX1.Location = new System.Drawing.Point(15, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(54, 21);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "學 年 度";
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
            this.labelX4.Location = new System.Drawing.Point(228, 49);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(60, 21);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "登錄日期";
            // 
            // dateTimeInput1
            // 
            this.dateTimeInput1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.ButtonFreeText.Checked = true;
            this.dateTimeInput1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.dateTimeInput1.FreeTextEntryMode = true;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(75, 47);
            this.dateTimeInput1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimeInput1.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
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
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2009, 10, 1, 0, 0, 0, 0);
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
            this.dateTimeInput1.Size = new System.Drawing.Size(138, 25);
            this.dateTimeInput1.TabIndex = 9;
            this.dateTimeInput1.Click += new System.EventHandler(this.dateTimeInput1_Click);
            // 
            // dateTimeInput2
            // 
            this.dateTimeInput2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.dateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput2.ButtonDropDown.Visible = true;
            this.dateTimeInput2.ButtonFreeText.Checked = true;
            this.dateTimeInput2.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.dateTimeInput2.FreeTextEntryMode = true;
            this.dateTimeInput2.IsPopupCalendarOpen = false;
            this.dateTimeInput2.Location = new System.Drawing.Point(291, 47);
            this.dateTimeInput2.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimeInput2.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
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
            this.dateTimeInput2.MonthCalendar.DisplayMonth = new System.DateTime(2009, 10, 1, 0, 0, 0, 0);
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
            this.dateTimeInput2.Size = new System.Drawing.Size(138, 25);
            this.dateTimeInput2.TabIndex = 11;
            // 
            // intSchoolYear
            // 
            this.intSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSchoolYear.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.intSchoolYear.Location = new System.Drawing.Point(75, 12);
            this.intSchoolYear.MaxValue = 999;
            this.intSchoolYear.MinValue = 90;
            this.intSchoolYear.Name = "intSchoolYear";
            this.intSchoolYear.ShowUpDown = true;
            this.intSchoolYear.Size = new System.Drawing.Size(138, 25);
            this.intSchoolYear.TabIndex = 5;
            this.intSchoolYear.Value = 90;
            // 
            // intSemester
            // 
            this.intSemester.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intSemester.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSemester.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSemester.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.intSemester.Location = new System.Drawing.Point(291, 10);
            this.intSemester.MaxValue = 2;
            this.intSemester.MinValue = 1;
            this.intSemester.Name = "intSemester";
            this.intSemester.ShowUpDown = true;
            this.intSemester.Size = new System.Drawing.Size(138, 25);
            this.intSemester.TabIndex = 7;
            this.intSemester.Value = 1;
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
            this.labelX3.ForeColor = System.Drawing.Color.Red;
            this.labelX3.Location = new System.Drawing.Point(12, 84);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 12;
            this.labelX3.Text = "主辦單位";
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Location = new System.Drawing.Point(291, 117);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(137, 25);
            this.textBoxX2.TabIndex = 19;
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
            this.labelX5.Location = new System.Drawing.Point(228, 119);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(60, 21);
            this.labelX5.TabIndex = 18;
            this.labelX5.Text = "備　　註";
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.Location = new System.Drawing.Point(75, 117);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.Size = new System.Drawing.Size(138, 25);
            this.textBoxX3.TabIndex = 17;
            this.textBoxX3.TextChanged += new System.EventHandler(this.textBoxX3_TextChanged);
            this.textBoxX3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxX3_KeyUp);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.labelX8.Location = new System.Drawing.Point(12, 154);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(60, 21);
            this.labelX8.TabIndex = 20;
            this.labelX8.Text = "事由代碼";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxEx1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 19;
            this.comboBoxEx1.Location = new System.Drawing.Point(75, 152);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(353, 25);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 21;
            this.comboBoxEx1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            this.comboBoxEx1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBoxEx1_KeyUp);
            // 
            // cbOrganizers
            // 
            this.cbOrganizers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbOrganizers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbOrganizers.DisplayMember = "Text";
            this.cbOrganizers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOrganizers.DropDownWidth = 400;
            this.cbOrganizers.FormattingEnabled = true;
            this.cbOrganizers.ItemHeight = 19;
            this.cbOrganizers.Location = new System.Drawing.Point(75, 82);
            this.cbOrganizers.Name = "cbOrganizers";
            this.cbOrganizers.Size = new System.Drawing.Size(138, 25);
            this.cbOrganizers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbOrganizers.TabIndex = 13;
            // 
            // cbIAndE
            // 
            this.cbIAndE.DisplayMember = "Text";
            this.cbIAndE.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIAndE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIAndE.FormattingEnabled = true;
            this.cbIAndE.ItemHeight = 19;
            this.cbIAndE.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cbIAndE.Location = new System.Drawing.Point(291, 82);
            this.cbIAndE.Name = "cbIAndE";
            this.cbIAndE.Size = new System.Drawing.Size(139, 25);
            this.cbIAndE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIAndE.TabIndex = 15;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "校內";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "校外";
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
            this.labelX9.Location = new System.Drawing.Point(228, 84);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(60, 21);
            this.labelX9.TabIndex = 14;
            this.labelX9.Text = "校內校外";
            // 
            // LearningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 306);
            this.ControlBox = false;
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.cbIAndE);
            this.Controls.Add(this.cbOrganizers);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.intSemester);
            this.Controls.Add(this.intSchoolYear);
            this.Controls.Add(this.dateTimeInput2);
            this.Controls.Add(this.dateTimeInput1);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.textBoxX3);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX8);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LearningForm";
            this.Text = "服務學習記錄";
            this.Load += new System.EventHandler(this.LearningForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReason;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lbl1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput2;
        private DevComponents.Editors.IntegerInput intSchoolYear;
        private DevComponents.Editors.IntegerInput intSemester;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbOrganizers;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbIAndE;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
    }
}
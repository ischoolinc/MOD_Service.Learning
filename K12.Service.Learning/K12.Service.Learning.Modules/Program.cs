using Campus.DocumentValidator;
using FISCA;
using FISCA.Permission;
using FISCA.Presentation;
using FISCA.UDT;
using K12.Data.Configuration;
using System.Windows.Forms;

namespace K12.Service.Learning.Modules
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {
            ServerModule.AutoManaged("http://module.ischool.com.tw/module/138/Service_Learning/udm.xml");

            //6bccb45b-ca75-43ee-beaa-c035a77c8263 - 服務學習時數(老師)
            //dfde4dc2-fece-4c29-be99-c8bd11650383 - 服務學習時數(學生)
            //2d25c52c-4c13-4d9b-a347-9772ec217516 - 服務學習時數(家長)

            //FISCA.RTOut.WriteLine("註冊Gadget - 服務學習時數(老師)：" + WebPackage.RegisterGadget("Teacher", "6bccb45b-ca75-43ee-beaa-c035a77c8263", "服務學習時數(老師)").Item2);
            //FISCA.RTOut.WriteLine("註冊Gadget - 服務學習時數(學生)：" + WebPackage.RegisterGadget("Student", "dfde4dc2-fece-4c29-be99-c8bd11650383", "服務學習時數(學生)").Item2);
            //FISCA.RTOut.WriteLine("註冊Gadget - 服務學習時數(家長)：" + WebPackage.RegisterGadget("Parent", "2d25c52c-4c13-4d9b-a347-9772ec217516", "服務學習時數(家長)").Item2);


            #region 處理UDT Table沒有的問題

            ConfigData cd = K12.Data.School.Configuration["服務學習時數模組UDT載入_1030911"];
            bool checkClubUDT = false;
            string name = "服務學習UDT是否已載入";
            //如果尚無設定值,預設為
            if (string.IsNullOrEmpty(cd[name]))
            {
                cd[name] = "false";
            }

            //檢查是否為布林
            bool.TryParse(cd[name], out checkClubUDT);

            if (!checkClubUDT)
            {
                AccessHelper _accessHelper = new AccessHelper();
                _accessHelper.Select<SLRecord>("UID = '00000'");
                _accessHelper.Select<DigitalCodeRecord>("UID = '00000'");

                cd[name] = "true";
                cd.Save();
            }

            #endregion

            FactoryProvider.FieldFactory.Add(new FieldValidatorFactory());

            //服務學習資料項目
            FeatureAce UserPermission = FISCA.Permission.UserAcl.Current[Permissions.服務學習記錄];
            if (UserPermission.Editable)
                K12.Presentation.NLDPanels.Student.AddDetailBulider(new FISCA.Presentation.DetailBulider<LearningItem>());

            RibbonBarItem insert = MotherForm.RibbonBarItems["學生", "學務"];
            insert["服務學習"].Image = Properties.Resources.flip_vertical_clock_64;
            insert["服務學習"].Size = RibbonBarButton.MenuButtonSize.Medium;
            insert["服務學習"].Enable = false;
            insert["服務學習"].Click += delegate
            {
                // 單選學生
                if (K12.Presentation.NLDPanels.Student.SelectedSource.Count == 1)
                {
                    SingleStudentLearning acf = new SingleStudentLearning();
                    acf.ShowDialog();
                }
                // 多選學生
                if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 1)
                {
                    MutiLearning acf = new MutiLearning();
                    acf.ShowDialog();
                }
                
            };

            if (Permissions.服務學習快速登錄權限)
            {
                //必須要有權限,才會出現在滑鼠右鍵
                K12.Presentation.NLDPanels.Student.ListPaneContexMenu["服務學習"].Image = Properties.Resources.flip_vertical_clock_64;
                K12.Presentation.NLDPanels.Student.ListPaneContexMenu["服務學習"].Enable = false;
                K12.Presentation.NLDPanels.Student.ListPaneContexMenu["服務學習"].Click += delegate
                {
                    // 單選學生
                    if (K12.Presentation.NLDPanels.Student.SelectedSource.Count == 1)
                    {
                        SingleStudentLearning acf = new SingleStudentLearning();
                        acf.ShowDialog();
                    }
                    // 多選學生
                    if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 1)
                    {
                        MutiLearning acf = new MutiLearning();
                        acf.ShowDialog();
                    }
                };
            }

            K12.Presentation.NLDPanels.Student.SelectedSourceChanged += delegate
            {
                if (Permissions.服務學習快速登錄權限)
                {
                    bool a = K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0;

                    K12.Presentation.NLDPanels.Student.ListPaneContexMenu["服務學習"].Enable = a;
                    insert["服務學習"].Enable = a;
                }
            };

            RibbonBarItem reportBar = MotherForm.RibbonBarItems["學生", "資料統計"];
            reportBar["報表"]["學務相關報表"]["服務學習時數證明單"].Enable = Permissions.服務學習_證明單權限;
            reportBar["報表"]["學務相關報表"]["服務學習時數證明單"].Click += delegate
            {
                SLReportForm acf = new SLReportForm();
                acf.ShowDialog();
            };

            MenuButton rbItemExport = MotherForm.RibbonBarItems["學生", "資料統計"]["匯出"]["學務相關匯出"];
            rbItemExport["匯出服務學習記錄"].Enable = Permissions.匯出服務學習記錄權限;
            rbItemExport["匯出服務學習記錄"].Click += delegate
            {
                SmartSchool.API.PlugIn.Export.Exporter exporter = new ExportSLRecord();
                ExportStudentV2 wizard = new ExportStudentV2(exporter.Text, exporter.Image);
                exporter.InitializeExport(wizard);
                wizard.ShowDialog();
            };

            MenuButton rbItemImport = MotherForm.RibbonBarItems["學生", "資料統計"]["匯入"]["學務相關匯入"];
            rbItemImport["匯入服務學習記錄(新增)"].Enable = Permissions.匯入服務學習記錄權限;
            rbItemImport["匯入服務學習記錄(新增)"].Click += delegate
            {
                ImportServiceLearning wizard = new ImportServiceLearning();
                wizard.Execute();
            };

            rbItemImport = MotherForm.RibbonBarItems["學生", "資料統計"]["匯入"]["學務相關匯入"];
            rbItemImport["匯入服務學習記錄(更新)"].Enable = Permissions.匯入服務學習記錄權限;
            rbItemImport["匯入服務學習記錄(更新)"].Click += delegate
            {
                ImportServiceLearning_up wizard = new ImportServiceLearning_up();
                wizard.Execute();
            };

            RibbonBarItem toolSpeed = MotherForm.RibbonBarItems["學務作業", "批次作業/查詢"];
            toolSpeed["服務學習時數"].Image = Properties.Resources.lamp_clock_64;

            toolSpeed["服務學習時數"]["服務學習批次修改"].Enable = Permissions.服務學習批次修改權限;
            //toolSpeed["服務學習時數"]["服務學習批次修改"].Image = Properties.Resources.lamp_clock_64;
            toolSpeed["服務學習時數"]["服務學習批次修改"].Click += delegate
            {

                ServiceLearningBatch batch = new ServiceLearningBatch();
                batch.ShowDialog();

                #region shift 才能開啟功能
                //if (Control.ModifierKeys != Keys.Shift)
                //{
                //}
                //else
                //{
                //    if (Permissions.服務時數查詢權限)
                //    {
                //        StudentIvForm batch = new StudentIvForm();
                //        batch.ShowDialog();
                //    }
                //    else
                //    {
                //        FISCA.Presentation.Controls.MsgBox.Show("您沒有權限打開進階功能!!");
                //    }
                //} 
                #endregion
            };

            RibbonBarItem toolselect = MotherForm.RibbonBarItems["學務作業", "批次作業/查詢"];
            toolselect["服務學習時數"]["學生服務時數查詢"].Enable = Permissions.學生服務時數查詢權限;
            //toolselect["服務學習時數"]["學生服務時數查詢"].Image = Properties.Resources.offer_b_search_64;
            toolselect["服務學習時數"]["學生服務時數查詢"].Click += delegate
            {
                StudentIvForm batch = new StudentIvForm();
                batch.ShowDialog();
            };

            RibbonBarItem toolCode = MotherForm.RibbonBarItems["學務作業", "基本設定"];
            toolCode["對照/代碼"]["服務學習事由代碼表"].Enable = Permissions.服務學習事由代碼表權限;
            toolCode["對照/代碼"]["服務學習事由代碼表"].Click += delegate
            {
                DigitalCodeForm batch = new DigitalCodeForm();
                batch.ShowDialog();
            };


            Catalog ribbon = RoleAclSource.Instance["學生"]["資料項目"];
            ribbon.Add(new FISCA.Permission.DetailItemFeature(Permissions.服務學習記錄, "服務學習記錄"));

            ribbon = RoleAclSource.Instance["學生"]["功能按鈕"];
            ribbon.Add(new RibbonFeature(Permissions.服務學習快速登錄, "服務學習快速登錄"));
            ribbon.Add(new RibbonFeature(Permissions.服務學習_證明單, "服務學習時數證明單"));
            ribbon.Add(new RibbonFeature(Permissions.匯出服務學習記錄, "匯出服務學習記錄"));
            ribbon.Add(new RibbonFeature(Permissions.匯入服務學習記錄, "匯入服務學習記錄"));

            ribbon = RoleAclSource.Instance["學務作業"]["功能按鈕"];
            ribbon.Add(new RibbonFeature(Permissions.服務學習批次修改, "服務學習批次修改"));
            ribbon.Add(new RibbonFeature(Permissions.學生服務時數查詢, "學生服務時數查詢"));
            ribbon.Add(new RibbonFeature(Permissions.服務學習事由代碼表, "服務學習事由代碼表"));
        }

    }
}

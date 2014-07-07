using FISCA;
using FISCA.Permission;
using FISCA.Presentation;
using FISCA.UDT;
using K12.Data.Configuration;

namespace K12.Service.Learning.CreationItems
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {
            ServerModule.AutoManaged("https://module.ischool.com.tw/module/193005/k12.service_learning.creationitems/udm.xml");

            //服務學習資料項目
            //FeatureAce UserPermission = FISCA.Permission.UserAcl.Current[Permissions.服務學習記錄];

            RibbonBarItem insert = MotherForm.RibbonBarItems["學務作業", "批次作業/查詢"];
            //insert["服務學習快速登錄"].Image = Properties.Resources.flip_vertical_clock_64;
            insert["服務學習線上開設"].Size = RibbonBarButton.MenuButtonSize.Medium;
            //insert["服務學習快速登錄"].Enable = false;
            insert["服務學習線上開設"].Click += delegate
            {
                new CreationItem().ShowDialog();
            };
            insert["服務學習記錄卡"].Size = RibbonBarButton.MenuButtonSize.Medium;
            //insert["服務學習快速登錄"].Enable = false;
            insert["服務學習記錄卡"].Click += delegate
            {
                new RecordCard().ShowDialog();
            };
            //Catalog ribbon = RoleAclSource.Instance["學生"]["資料項目"];
            //ribbon.Add(new FISCA.Permission.DetailItemFeature(Permissions.服務學習記錄, "服務學習記錄"));
        }

    }
}

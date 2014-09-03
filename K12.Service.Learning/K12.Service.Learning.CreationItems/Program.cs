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

            RibbonBarItem insert = MotherForm.RibbonBarItems["學務作業", "批次作業/查詢"];
            insert["服務學習線上開設"].Size = RibbonBarButton.MenuButtonSize.Medium;
            insert["服務學習線上開設"].Enable = Permissions.服務學習線上開設權限;
            insert["服務學習線上開設"].Click += delegate
            {
                new CreationItem().ShowDialog();
            };
            Catalog ribbon1 = RoleAclSource.Instance["學務作業"];
            ribbon1.Add(new FISCA.Permission.RibbonFeature(Permissions.服務學習線上開設, "服務學習線上開設"));


             MenuButton mb = MotherForm.RibbonBarItems["學生", "資料統計"]["報表"]["學務相關報表"];
             mb["服務學習記錄卡"].Enable = Permissions.服務學習記錄卡權限;
             mb["服務學習記錄卡"].Click += delegate
            {
                new RecordCard().ShowDialog();
            };
             Catalog ribbon2 = RoleAclSource.Instance["學生"]["報表"];
             ribbon2.Add(new FISCA.Permission.RibbonFeature(Permissions.服務學習記錄卡, "服務學習記錄卡"));
        }

    }
}

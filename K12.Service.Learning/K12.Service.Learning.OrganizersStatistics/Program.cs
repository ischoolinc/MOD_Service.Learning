using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;

namespace K12.SL.OrganizersStatistics
{
    public class Program
    {
        [MainMethod()]
        public static void Main()
        {
            RibbonBarItem bh = FISCA.Presentation.MotherForm.RibbonBarItems["學務作業", "批次作業/查詢"];
            bh["服務學習時數"]["主辦單位與事由統計"].Enable = Permissions.主辦單位與事由統計權限;
            //bh["服務學習時數"]["主辦單位與事由統計"].Image = Properties.Resources.system_64;
            bh["服務學習時數"]["主辦單位與事由統計"].Click += delegate
            {
                OrganizersStatisticsForm osForm = new OrganizersStatisticsForm();
                osForm.ShowDialog();
            };

            Catalog detail = RoleAclSource.Instance["學務作業"]["功能按鈕"];
            detail.Add(new RibbonFeature(Permissions.主辦單位與事由統計, "主辦單位與事由統計"));
        }
    }
}

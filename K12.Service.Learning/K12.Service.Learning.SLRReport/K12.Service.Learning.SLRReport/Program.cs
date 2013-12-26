using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;

namespace K12.Service.Learning.SLRReport
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {
            RibbonBarItem reportClassBar = MotherForm.RibbonBarItems["班級", "資料統計"];
            reportClassBar["報表"]["學務相關報表"]["班級服務學習統計表"].Enable = Permissions.班級服務學習統計表權限;
            reportClassBar["報表"]["學務相關報表"]["班級服務學習統計表"].Click += delegate
            {
                SLRClassTotal acf = new SLRClassTotal();
                acf.ShowDialog();
            };

            Catalog ribbon = RoleAclSource.Instance["班級"]["功能按鈕"];
            ribbon.Add(new RibbonFeature(Permissions.班級服務學習統計表, "班級服務學習統計表"));


        }
    }
}

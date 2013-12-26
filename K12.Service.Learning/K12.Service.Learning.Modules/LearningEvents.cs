using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//服務學習資料更新
namespace K12.Service.Learning.Modules
{
    public static class LearningEvents
    {
        public static void RaiseAssnChanged()
        {
            if (LearningChanged != null)
                LearningChanged(null, EventArgs.Empty);
        }

        public static event EventHandler LearningChanged;
    }
}
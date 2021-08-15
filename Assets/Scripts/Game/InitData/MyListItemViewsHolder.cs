using Com.TheFallenGames.OSA.Core;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.UI;

namespace Your.Namespace.Here.UniqueStringHereToAvoidNamespaceConflicts.Lists
{
    public class MyListItemViewsHolder : BaseItemViewsHolder
    {
        public Image backgroundImage;
        
        public Text nickName; //自定义组件
        public Text trophy; //奖杯
        public Text grade; //文字排名
        
        public Image gradeImage; //图片排名
        public Image rank;
		
        public override void CollectViews()
        {
            base.CollectViews();
            //获取设置组件
            root.GetComponentAtPath("nickName", out nickName);
            root.GetComponentAtPath("BackgroundImage", out backgroundImage);
            root.GetComponentAtPath("GradeImage", out gradeImage);
            root.GetComponentAtPath("Grade", out grade);
            root.GetComponentAtPath("Trophy", out trophy);
            root.GetComponentAtPath("Rank", out rank);
        }

		
    }
}
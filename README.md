# http

**整体大纲**  
1.通过http请求获取json数据  
2.解析json文件，获取解析的数据  
3.展示数据列表，并将数据进行降序排列  
4.使用osa插件完成元素服用  

**目录结构**  
```
├── Config. 
│   ├── RankListApi.cs. //http读取数据
│   └── RankListApi.cs.meta. 
├── Config.meta. 
├── Controller. 
│   ├── BasicListAdapter.cs.  //osa解析并展示数据
│   ├── BasicListAdapter.cs.meta. 
│   ├── ViewChange.cs.  //游戏场景变换
│   ├── ViewChange.cs.meta. 
│   ├── Window.cs.  //弹窗类
│   └── Window.cs.meta. 
├── Controller.meta. 
├── Data. 
│   ├── MyListItemModel.cs. //对应json数据
│   ├── MyListItemModel.cs.meta. 
│   ├── MyListItemViewsHolder.cs. //对应相应UI组件
│   └── MyListItemViewsHolder.cs.meta. 
└── Data.meta. 
```
  
**界面结构**  
```
 Hierarchy：  
    1.GameView  //展示排行榜的画布  
    1)OSA     //展示排行榜  
      2)ButtonPanel  //放置后退按钮  
      3)Popups   //弹窗  
      4)Countdown  //倒计时  
      5)CountdownText //倒计时标题  
      6)TrophyBackImage //奖杯背景图  
      7)TrophyImage  //奖杯图片  
      8)TopRank  //头榜  
    2.StartView //初始页面的画布  
      1）BackImage //初始页面背景图  
 ```
**流程图**

![image](https://github.com/89trillion-songzhiheng/http/blob/main/Picture/Httpic.png)

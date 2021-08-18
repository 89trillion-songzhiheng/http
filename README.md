# http

**整体大纲**
1.通过http请求获取json数据
2.解析json文件，获取解析的数据
3.展示数据列表，并将数据进行降序排列
4.使用osa插件完成元素服用

    
**目录结构**
├── Game
│   ├── InitData
│   │   ├── BasicListAdapter.cs //使用OSA，加载数据 
│   │   ├── BasicListAdapter.cs.meta
│   │   ├── MyListItemModel.cs //设置对应json的字段 
│   │   ├── MyListItemModel.cs.meta
│   │   ├── MyListItemViewsHolder.cs //设置对应的UI组件
│   │   └── MyListItemViewsHolder.cs.meta
│   ├── InitData.meta
│   ├── Tools
│   │   ├── TimeFormat.cs //时间格式化
│   │   ├── TimeFormat.cs.meta
│   │   ├── ViewChange.cs //场景转换控制类
│   │   ├── ViewChange.cs.meta
│   │   ├── Window.cs   //设置弹窗类
│   │   └── Window.cs.meta
│   └── Tools.meta
├── Game.meta
├── Http
│   ├── RankListApi.cs  //http请求数据类
│   ├── RankListApi.cs.meta
│   ├── Tools
│   │   ├── BaseAPI.cs
│   │   ├── BaseAPI.cs.meta
│   │   ├── ContentTypeUtil.cs
│   │   ├── ContentTypeUtil.cs.meta
│   │   ├── DefaultAPI.cs
│   │   ├── DefaultAPI.cs.meta
│   │   ├── HttpClient.cs
│   │   ├── HttpClient.cs.meta
│   │   ├── HttpClientBuilder.cs
│   │   ├── HttpClientBuilder.cs.meta
│   │   ├── IPlatformAPI.cs
│   │   ├── IPlatformAPI.cs.meta
│   │   ├── NetworkUtil.cs
│   │   ├── NetworkUtil.cs.meta
│   │   ├── Reg.cs
│   │   ├── Reg.cs.meta
│   │   ├── e392323d23a.cs
│   │   └── e392323d23a.cs.meta
│   └── Tools.meta
├── Http.meta
├── SimpJson
│   ├── SimpleJSON.cs
│   ├── SimpleJSON.cs.meta
│   ├── SimpleJSONBinary.cs
│   ├── SimpleJSONBinary.cs.meta
│   ├── SimpleJSONDotNetTypes.cs
│   ├── SimpleJSONDotNetTypes.cs.meta
│   ├── SimpleJSONUnity.cs
│   └── SimpleJSONUnity.cs.meta
└── SimpJson.meta
  
**界面结构**
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
**流程图**

![image](https://github.com/89trillion-songzhiheng/http/blob/main/picture/Httppic.png)

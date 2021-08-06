/*
 * * * * This bare-bones script was auto-generated * * * *
 * The code commented with "/ * * /" demonstrates how data is retrieved and passed to the adapter, plus other common commands. You can remove/replace it once you've got the idea
 * Complete it according to your specific use-case
 * Consult the Example scripts if you get stuck, as they provide solutions to most common scenarios
 * 
 * Main terms to understand:
 *		Model = class that contains the data associated with an item (title, content, icon etc.)
 *		Views Holder = class that contains references to your views (Text, Image, MonoBehavior, etc.)
 * 
 * Default expected UI hiererchy:
 *	  ...
 *		-Canvas
 *		  ...
 *			-MyScrollViewAdapter
 *				-Viewport
 *					-Content
 *				-Scrollbar (Optional)
 *				-ItemPrefab (Optional)
 * 
 * Note: If using Visual Studio and opening generated scripts for the first time, sometimes Intellisense (autocompletion)
 * won't work. This is a well-known bug and the solution is here: https://developercommunity.visualstudio.com/content/problem/130597/unity-intellisense-not-working-after-creating-new-1.html (or google "unity intellisense not working new script")
 * 
 * 
 * Please read the manual under "Assets/OSA/Docs", as it contains everything you need to know in order to get started, including FAQ
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Other.Extensions;
using Com.TheFallenGames.OSA.Core;
using Com.TheFallenGames.OSA.CustomParams;
using Com.TheFallenGames.OSA.DataHelpers;
using SimpleJSON;
using Timer = System.Threading.Timer;

// You should modify the namespace to your own or - if you're sure there won't ever be conflicts - remove it altogether
namespace Your.Namespace.Here.UniqueStringHereToAvoidNamespaceConflicts.Lists
{
	// There are 2 important callbacks you need to implement, apart from Start(): CreateViewsHolder() and UpdateViewsHolder()
	// See explanations below
	public class BasicListAdapter : OSA<BaseParamsWithPrefab, MyListItemViewsHolder>
	{
		//json文件
		public  TextAsset jsonfile;
		
		//最上方本人排名
		public Text selfpai;
		
		//最上方本人奖杯数
		public Text selfcount;
		
		//最上方本人姓名
		public Text selfname;
		
		//存储json数据
		private  string moveSpriet;
		
		//存储jsonarray长度
		private int count;
		
		//倒计时对象
		public Text  dt ;
        //倒计时整型
		private int dttt;
		
       //倒计时字符串
		private string dtt;
		
		//http请求类对象
		private HeroTowerRankListApi gra;
		public SimpleDataHelper<MyListItemModel> Data { get; private set; }
		

		#region OSA implementation
		protected override void Awake()
		{
			gra = new HeroTowerRankListApi(new GameObject())
				{
					OnSuccess = sc
				};
			dt.transform.GetComponent<Text>().text = "100";
			dtt = dt.transform.GetComponent<Text>().text;
			dttt = int.Parse(dtt);
			moveSpriet=jsonfile.text;
			Data = new SimpleDataHelper<MyListItemModel>(this);
			var n = JSONNode.Parse (moveSpriet);
			count  = n["list"].Count;
			
			base.Awake();
			//开启倒计时
			StartCoroutine(startdown());


		}

		public void sc(string data)
		{
			// Debug.Log(data+"");
			Data = new SimpleDataHelper<MyListItemModel>(this);
			OnDataRetrieved(HeroTowerRankListApi.ParseResponse(data));
		}
        //倒计时协程
		IEnumerator startdown()
		{
			while (dttt >= 0)
			{
				yield return new WaitForSeconds(1);
				dttt--;
				dt.transform.GetComponent<Text>().text = dttt.ToString();
				RetrieveDataAndUpdate();
				// if (dttt == 0)
				// {
				// 	dt.transform.GetComponent<Text>().text = "5";
				// 	dtt = dt.transform.GetComponent<Text>().text;
				// 	dttt = int.Parse(dtt);
				// }
			}
		}
		protected override MyListItemViewsHolder CreateViewsHolder(int itemIndex)
		{
			var instance = new MyListItemViewsHolder();

			
			instance.Init(_Params.ItemPrefab, _Params.Content, itemIndex);
			
			instance.nickName.text = Data[itemIndex].nickName;
			instance.trophy.text =Data[itemIndex].trophy.ToString();
			
			if (Data[itemIndex].uid.Equals("3716954261"))
			{
				selfcount.transform.GetComponent<Text>().text = Data[itemIndex].trophy.ToString();
				selfname.transform.GetComponent<Text>().text = Data[itemIndex].nickName;
				selfpai.transform.GetComponent<Text>().text = Data[itemIndex].trophy / 1000 + 1.ToString();
			}

			int ss = Data[itemIndex].trophy / 1000 + 1;
		    instance.duanwei.sprite = Resources.Load<Sprite>("picture/rank/arenaBadge_"+ss);
			return instance;
		}

		
		protected override void UpdateViewsHolder(MyListItemViewsHolder newOrRecycled)
		{
		
			Debug.Log(newOrRecycled.ItemIndex);
			MyListItemModel model = Data[newOrRecycled.ItemIndex];
			int ss = Data[newOrRecycled.ItemIndex].trophy / 1000 + 1;
			newOrRecycled.nickName.text = model.nickName;
			newOrRecycled.trophy.text = model.trophy.ToString();
			newOrRecycled.image.sprite =Resources.Load<Sprite>("picture/rank_"+(newOrRecycled.ItemIndex+1));
			newOrRecycled.wenzipai.text = (newOrRecycled.ItemIndex + 1).ToString();
			newOrRecycled.duanwei.sprite = Resources.Load<Sprite>("picture/rank/arenaBadge_"+ss);
			if (newOrRecycled.ItemIndex >2)
			{
				newOrRecycled.image.color = new Color(1, 1, 1, 0);
			}

			// if (newOrRecycled.ItemIndex>=count)
			// {
			// 	StopCoroutine(startdown());
			// }
			// else
			// {
			// 	StartCoroutine(startdown());
			// }
			if (newOrRecycled.ItemIndex <= 2)
			{
				newOrRecycled.image.sprite =Resources.Load<Sprite>("picture/rank_"+(newOrRecycled.ItemIndex+1));
				newOrRecycled.image.color = new Color(1, 1, 1, 1);
				if (newOrRecycled.ItemIndex == 0)
				{
					newOrRecycled.image.GetComponent<RectTransform>().sizeDelta = new Vector2(86, 78);
				}
				
				if (newOrRecycled.ItemIndex == 1)
				{
					newOrRecycled.image.GetComponent<RectTransform>().sizeDelta = new Vector2(83, 77);
				}
				newOrRecycled.image.color = new Color(1, 1, 1, 1);
			}
			
		}
		
		#endregion

		
		#region data manipulation
		public void AddItemsAt(int index, IList<MyListItemModel> items)
		{
			
			Data.InsertItems(index, items);
		}

		public void RemoveItemsFrom(int index, int count)
		{
			

			Data.RemoveItems(index, count);
		}

		public void SetItems(IList<MyListItemModel> items)
		{
			
			Data.ResetItems(items);
		}
		#endregion

		void RetrieveDataAndUpdate()
		{
			StartCoroutine(FetchMoreItemsFromDataSourceAndUpdate());
		}

		
		IEnumerator FetchMoreItemsFromDataSourceAndUpdate()
		{
			
			yield return new WaitForSeconds(.5f);
			gra.Request();
		}

		void OnDataRetrieved(MyListItemModel[] newItems)
		{
			Data.InsertItemsAtEnd(newItems);
		}
	}
	
	public class MyListItemModel
	{
	
		
		//玩家id
		public string uid;
		
		//玩家昵称
		public string nickName;
		
		//玩家头像id，全部设置为userhead.png
		public int avatar;
		
		//用户奖杯
		public int trophy;
		
		public string thirdAvatar;
		public int onlineStatus;
		public int role;
		public string abb;
	}


	// This class keeps references to an item's views.
	// Your views holder should extend BaseItemViewsHolder for ListViews and CellViewsHolder for GridViews
	public class MyListItemViewsHolder : BaseItemViewsHolder
	{
		public Image backgroundImage;
		
		//自定义组件
		public Text nickName;
		//奖杯
		public Text trophy;
        //文字排名
		public Text wenzipai;
		//图片排名
		public Image image;

		public Image duanwei;
		
		public override void CollectViews()
		{
			base.CollectViews();
			//获取设置组件
			root.GetComponentAtPath("nickName", out nickName);
			root.GetComponentAtPath("BackgroundImage", out backgroundImage);
			root.GetComponentAtPath("paiming", out image);
			root.GetComponentAtPath("wenpai", out wenzipai);
			root.GetComponentAtPath("trophy", out trophy);
			root.GetComponentAtPath("duanwei", out duanwei);
		}

		
	}
}

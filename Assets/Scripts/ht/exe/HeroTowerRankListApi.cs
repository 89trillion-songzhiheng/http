using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using Your.Namespace.Here.UniqueStringHereToAvoidNamespaceConflicts.Lists;

public class HeroTowerRankListApi : BaseAPI
{
    public HeroTowerRankListApi(GameObject gameObject) : base(gameObject)
    {

    }

    public void Request(int seasonId = 0, int page = 1, bool isForceRequest = false)
    {
        var httpClientBuilder = CreateHttpClientBuilder(seasonId, page, isForceRequest);
        SendRequest(httpClientBuilder);
    }

    private HttpClientBuilder CreateHttpClientBuilder(int seasonId = 0, int page = 1, bool isForceRequest = false)
    {
        ForceRequest = isForceRequest;
        isEncode = false;
        
        string path = "admin/rankList";
        HttpClientBuilder httpClientBuilder = new HttpClientBuilder(DomainType.Pvp)
            .Path(path)
            .Param("page", page)
            .Param("type","1")
            .Param("season","18")
            .Param("token","eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiI0MzY4NjY1MjcifQ.drFj2OtLEjgE452sgtHPG73xU-yQ-OXvbz4Utxl2M1k")
            .Method(HttpMethod.Get);
        if (seasonId > 0)
        {
            httpClientBuilder.Param("seasonId", seasonId);
        }

        return httpClientBuilder;
    }

    public static MyListItemModel[] ParseResponse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }
        
        JSONNode n = JSONNode.Parse(data);
        int count = n["data"]["list"].Count;
        var  li=new MyListItemModel[count];
        for (int i = 0; i < count; ++i)
        {
            var newItems = n["data"]["list"][i];
            var model = new MyListItemModel()
            {
                uid = newItems["uid"],
                nickName = newItems["nickName"],
                avatar = newItems["avatar"],
                trophy = newItems["trophy"],
                thirdAvatar = newItems["thirdAvatar"],
                onlineStatus = newItems["onlineStatus"],
                role = newItems["role"],
                abb = newItems["abb"]
            };
            li[i] = model;
        }
        //数据排序
        for(int i=0;i<count-1;i++)
        {
            for(int j=count-1;j>=i+1;j--) 
            {
                if(li[j-1].trophy<li[j].trophy) {
                    MyListItemModel tem=li[j-1];
                    li[j-1]=li[j];
                    li[j]= tem;
                }
			
            }
        }
       
        return li;
    }

    // private static HeroTowerRankItemInfo ParseItem(JSONNode itemNode)
    // {
    //     int score = itemNode["score"];
    //     int ranking = itemNode["ranking"];
    //     int rankStage = itemNode["rankStageV2"];
    //     if (score == 0)
    //     {
    //         ranking = 0;
    //     }
    //
    //     string pic = itemNode["profileUrl"];
    //     string fbId = "";
    //     if (!string.IsNullOrEmpty(pic))
    //     {
    //         string[] str = pic.Split('/');
    //         if (str.Length >= 4)
    //         {
    //             fbId = str[3];
    //         }
    //     }
    //
    //     return new MyListItemModel
    //     {
    //         uid = itemNode["userId"],
    //         nickName = itemNode["name"],
    //         trophy = pic,
    //         avatar = itemNode["imageId"],
    //         thirdAvatar = itemNode["avatarId"],
    //         abb = (AuthType) itemNode["authType"].AsInt,
    //         onlineStatus = score,
    //         role = ranking,
            // FacebookId = fbId,
            // RankAtkValue = itemNode["combatPoints"],
            // RankStage = rankStage,
            // WinCount = itemNode["winCount"],
            // BattlePassSeasonId = itemNode["battlePassSeasonId"],
            // GuildInfo = GuildInfo.CreateWithJson(itemNode["teamData"])
        // };
    // }
}
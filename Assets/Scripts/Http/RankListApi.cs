using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using Your.Namespace.Here.UniqueStringHereToAvoidNamespaceConflicts.Lists;


/// <summary> MyMethod is a method in the MyClass class.
/// http请求获取数据
/// </summary>
public class RankListApi : BaseAPI
{
    public RankListApi(GameObject gameObject) : base(gameObject)
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
        
        JSONNode  jsonNode = JSONNode.Parse(data);
        int count = jsonNode["data"]["list"].Count;
        var  jsonList = new MyListItemModel[count];
        
        for (int i = 0; i < count; ++i)
        {
            var newItems = jsonNode["data"]["list"][i];
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
            jsonList[i] = model;
        }
        
        //数据排序
        Array.Sort(jsonList, (a, b) =>
        {
            return b.trophy - a.trophy;
        });
        return jsonList;
    }
}
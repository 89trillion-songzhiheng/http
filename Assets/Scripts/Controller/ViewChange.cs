using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 场景变换
 */
public class ViewChange : MonoBehaviour
{
    public Button backButton;//退出按钮
    public Button startButton;//进入按钮
    public GameObject startView;//开始场景
    
    void Start()
    {
        startView.SetActive(true);
        startButton.onClick.AddListener(startGame);
        backButton.onClick.AddListener(back);
    }

    public void startGame()
    {
        startView.SetActive(false);
    }

    public void back()
    {
        startView.SetActive(true);
    }
}

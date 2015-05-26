using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpriteManger : MonoBehaviour {
    //存放所有物品图片
    public  Sprite[] inventoryArray;
    public static Dictionary<string, Sprite> spriteDic = new Dictionary<string, Sprite>();
    void Awake()
    {
        initDic();

        //通过键的集合取
        //foreach (string key in spriteDic.Keys)
        //{
        //    print(key + "===="+spriteDic[key]);
        //}
    }
    // Use this for initialization
    void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //初始化物品图片
    void initDic()
    {
        //所有音频放在字典中
        foreach (Sprite item in inventoryArray)
        {
            spriteDic.Add(item.name, item);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServerController : MonoBehaviour {
    //服务器实体类
    ServerEntity sp;
    //服务器面板
    public GameObject panelServer;
    //开始页面板
    public GameObject panelStart;
    //流畅服务器prefab
    public GameObject button_server_green;
    //火爆服务器prefab
    public GameObject button_server_red;
    //服务器列表
    public GameObject serverList;
    //已选中服务器
    public GameObject buttonServerSelected;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Awake()
    {
            InitServerList();
            
    }
    public void InitServerList()
    {
        //1，连接服务器 取得游戏服务器列表信息
        //TODO
        //2，根据上面的信息 添加服务器列表
        string[] serverNames={"蜀南竹海","天外飞仙","一剑诛仙","五谷丰登"};
        sp = new ServerEntity();
        GameObject go;
        for (int i = 0; i <30; i++)
        {
            string Ip = "127.0.0.1:9080";
            string Name = serverNames[Random.Range(0, serverNames.Length)];
            int Count = Random.Range(0, 100);
            if (sp.Count > 50)
            {
                //火爆
                go = GameObject.Instantiate(button_server_red);
            }
            else
            {
                //流畅
                go = GameObject.Instantiate(button_server_green);
            }
            go.GetComponentInChildren<Text>().text = Name;
            //组件赋值
            sp = go.GetComponent<ServerEntity>();
            sp.Name = Name;
            sp.Count = Count;
            sp.Ip = Ip;
            //默认选中第一个
            if (i == 0)
            {
                //初始化开始页的服务器
                GameObject.Find("StartController").SendMessage("RecMsgFromServerController", go);
            }
            //go.transform.localScale = new Vector3(2, 2, 2);
            //通过此方法，添加给父对象的prefab的scale属性才不会变为0
            go.transform.SetParent(serverList.transform,false);

        }
    }
    /// <summary>
    /// 点击服务器列表里面的按钮，已选中服务器替换
    /// </summary>
    /// <param name="go">选中serverButton</param>
    public void RecMsgFromServerEvent(GameObject go)
    {
        buttonServerSelected.GetComponentInChildren<Text>().text = go.GetComponentInChildren<Text>().text;
        buttonServerSelected.GetComponentInChildren<Text>().color = go.GetComponentInChildren<Text>().color;
        buttonServerSelected.GetComponentInChildren<Image>().sprite = go.GetComponentInChildren<Image>().sprite;
    }
    /// <summary>
    /// 开始页点击进入服务器选择页的时候，初始化加载当前选中服务器buttonServerSelected。
    /// 问：为什么不初始化list的时候就设置默认值呢？ 
    /// 答：因为起父对象初始为Active，就无法获取此对象buttonServerSelected
    /// </summary>
    public void RecMsgFromStartController(GameObject go)
    {
        //当前临时获取服务器列表中的第一个对象，传来的值未使用
        GameObject tempGo = serverList.transform.GetChild(0).gameObject;
        buttonServerSelected.GetComponentInChildren<Text>().text = tempGo.GetComponentInChildren<Text>().text;
        buttonServerSelected.GetComponentInChildren<Text>().color = tempGo.GetComponentInChildren<Text>().color;
        buttonServerSelected.GetComponentInChildren<Image>().sprite = tempGo.GetComponentInChildren<Image>().sprite;
    }
    /// <summary>
    /// 服务器选择按钮确定选中,向游戏开始页面发送消息通知
    /// </summary>
    public void OnButtonServerSelectedClick()
    {
        GameObject.Find("StartController").SendMessage("RecMsgFromServerController", buttonServerSelected);
        panelStart.SetActive(true);
        panelServer.SetActive(false);
    }

}

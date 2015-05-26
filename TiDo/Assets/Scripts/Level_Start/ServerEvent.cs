using UnityEngine;
using System.Collections;
/// <summary>
/// 服务器Button自身点击事件
/// </summary>
public class ServerEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// 点击后将当前选择Button传递给ServerController进行后续操作
    /// </summary>
    public void OnButtonServerClick()
    {
        GameObject.Find("ServerController").SendMessage("RecMsgFromServerEvent", this.gameObject);
    }

}

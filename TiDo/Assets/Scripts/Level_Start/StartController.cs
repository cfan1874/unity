using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartController : MonoBehaviour {
    //服务器面板
    public GameObject panelServer;
    //开始页面板
    public GameObject panelStart;
    //登录面板
    public GameObject panelLogin;
    //开始页的服务器
    public GameObject buttonServer;
    //游戏设置面板动画
    public Animator gameSettingAnimator;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   /// <summary>
   /// 服务器选择页
   /// </summary>
    public void OnButtonServerClick()
    {
        panelServer.SetActive(true);
        GameObject.Find("ServerController").SendMessage("RecMsgFromStartController", buttonServer);
    }
    /// <summary>
    /// 转到登录页面
    /// </summary>
    public void OnButtonUserClick()
    {
        panelLogin.SetActive(true);
    }
    /// <summary>
    /// 游戏开始
    /// </summary>
    public void OnButtonStartClick()
    {
        //todo  携程异步加载场景
        StartCoroutine("ChangeScene");

    }
    IEnumerator ChangeScene()
    {
        AsyncOperation async = Application.LoadLevelAsync("Level_001");
        yield return async;
    }
    /// <summary>
    /// 服务器选中后的消息通知
    /// </summary>
    /// <param name="go"></param>
    public void RecMsgFromServerController(GameObject go)
    {
        buttonServer.GetComponentInChildren<Text>().text = go.GetComponentInChildren<Text>().text;
    }
    /// <summary>
    /// 设置游戏
    /// </summary>
    public void OnButtonGameSettingDown()
    {

        gameSettingAnimator.SetBool("gameSettingFlag", true);
        GameAudioManger.EffectAudioPlay("AudioEffect_GUn_Reload");
    }
    /// <summary>
    /// 设置完成
    /// </summary>
    public void OnButtonGameSettingUp()
    {

        gameSettingAnimator.SetBool("gameSettingFlag", false);
        GameAudioManger.EffectAudioPlay("AudioEffect_GUn_Reload");
    }
}

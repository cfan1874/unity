using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginController : MonoBehaviour
{
    //开始页面板
    public GameObject panelStart;
    //注册面板
    public GameObject panelRegister;
    //登录面板
    public GameObject panelLogin;
    //登录结果提示
    public Text textMsg;
    public InputField textUsername;
    public InputField textPassword;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnButtonLoginClick()
    {
        if (LoginCheck(textUsername.text, textPassword.text))
        {
            panelStart.SetActive(true);
            panelLogin.SetActive(false);
        }
        else
        {
            textMsg.text = "用户名或密码错误！";
        }
    }
    public void OnButtonRegisterClick()
    {

            panelRegister.SetActive(true);
            panelLogin.SetActive(false);

    }
    /// <summary>
    /// 登录验证
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool LoginCheck(string username, string password)
    {
        if ("admin".Equals(username.Trim()) && "123456".Equals(password.Trim()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
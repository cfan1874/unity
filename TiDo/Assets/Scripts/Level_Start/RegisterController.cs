using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class RegisterController : MonoBehaviour
{
    //开始页面板
    public GameObject panelStart;
    //注册面板
    public GameObject panelRegister;
    //登录面板
    public GameObject panelLogin;
    //提示
    public Text textUsernameMsg;
    public Text textPasswordMsg;
    public Text textPassword2Msg;
    public Text textEmailMsg;
    //输入域
    public InputField textUsername;
    public InputField textPassword;
    public InputField textPassword2;
    public InputField textEmail;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnButtonSubmitClick()
    {
        if (RegisterCheck())
        {
            panelStart.SetActive(true);
            panelRegister.SetActive(false);
        }
    }
    public void OnButtonCancelClick()
    {
        panelLogin.SetActive(true);
        panelRegister.SetActive(false);
    }
    /// <summary>
    /// 输入check
    /// </summary>
    /// <returns></returns>
    public bool RegisterCheck()
    {
        bool checkResult = true;
        //用户名
        if (!RegexMatch(textUsername.text.Trim(), @"^[a-zA-Z][a-zA-Z0-9]{3,15}$"))
        {
            textUsernameMsg.text = "字母打头的3到15位字母或数字";
            checkResult = false;
        }
        else
        {
            textUsernameMsg.text = "";
        }
        //密码
        if (textPassword.text.Trim().Length < 6)
        {
            textPasswordMsg.text = "至少6位";
            checkResult = false;
        }
        else if (RegexMatch(textPassword.text.Trim(), @"^[0-9]*$"))
        {
            textPasswordMsg.text = "不能为纯数字";
            checkResult = false;
        }
        else if (RegexMatch(textPassword.text.Trim(), @"[^\x00-\xff]"))
        {
            textPasswordMsg.text = "有中文或全角输入";
            checkResult = false;
        }
        else
        {
            textPasswordMsg.text = "";
        }
        //密码重复
        if (textPassword.text.Trim() != textPassword2.text.Trim())
        {
            textPassword2Msg.text = "密码输入不一样";
            checkResult = false;
        }
        else
        {
            textPassword2Msg.text = "";
        }
        //邮箱
        if (!RegexMatch(textEmail.text.Trim(), @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
        {
            textEmailMsg.text = "邮箱格式不对";
            checkResult = false;
        }
        else
        {
            textEmailMsg.text = "";
        }
        return checkResult;
    }
    /// <summary>
    /// 正则表达式验证  ps.后期考虑作为工具类
    /// </summary>
    /// <param name="content">验证内容</param>
    /// <param name="regex">正则表达式</param>
    /// <returns></returns>
    private bool RegexMatch(string content,string regex)
    {
        Regex r = new Regex(regex);  
        return r.IsMatch(content);
    }
}

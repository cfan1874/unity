using UnityEngine;
using System.Collections;
/// <summary>
/// 点击关闭其父对象
/// </summary>
public class ButtonClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// 点击关闭其父对象
    /// </summary>
    public void OnButtonClick()
    {
        GameObject parent = this.transform.parent.gameObject;
        parent.SetActive(false);
    }
}

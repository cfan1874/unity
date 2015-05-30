using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
    public GameObject player;
    //记录鼠标点击的3D坐标点
    private Vector3 point;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            MouseLeftClick();
        }
	}
    void MouseLeftClick()
    {

        //从摄像机的原点向鼠标点击的对象身上设法一条射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //当射线彭转到对象时
        if (Physics.Raycast(ray, out hit))
        {
            //目前场景中只有地形
            //其实应当在判断一下当前射线碰撞到的对象是否为地形。

            //得到在3D世界中点击的坐标
            point = hit.point;
  
            player.transform.LookAt(new Vector3(point.x, player.transform.position.y, point.z));
        }
    }
}

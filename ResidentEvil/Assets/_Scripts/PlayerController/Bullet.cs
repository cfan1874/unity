using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed=20;
	// Use this for initialization
	void Start () {
	
	}
	
	// 每帧向前移动一段距离
	void Update () {
        Vector3 oriPos = transform.position;
        transform.Translate(-transform.forward * speed * Time.deltaTime);
        Vector3 moveDir = transform.position - oriPos;
        //一帧移动的距离
        float lenght = moveDir.magnitude;
        RaycastHit hitInfo;
        bool isCollider = Physics.Raycast(oriPos, moveDir,out hitInfo, lenght);
        if (isCollider)
        {
            if (hitInfo.collider.gameObject.name == "Obstacle")
            {
                print("Duang~~~");
            }
            //碰撞物体
        }
	}
}

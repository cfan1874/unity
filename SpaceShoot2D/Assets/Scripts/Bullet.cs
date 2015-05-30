using UnityEngine;
using System.Collections;
/// <summary>
/// 子弹类，属于自动发射
/// </summary>
public class Bullet : MonoBehaviour {
    public float speed = 1.0f;

	// Update is called once per frame
	void Update () {
            gameObject.transform.Translate(Vector3.up * speed);
	}
    
}

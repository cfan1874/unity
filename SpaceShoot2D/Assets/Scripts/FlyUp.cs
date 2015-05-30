using UnityEngine;
using System.Collections;
/// <summary>
/// 游戏运行时，画面一直向上
/// </summary>
public class FlyUp : MonoBehaviour
{
    //速度
    public static float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        //自向上飞行
        transform.Translate(Vector2.up * speed * Time.deltaTime); 
    }
}

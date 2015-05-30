using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    //屏幕中心位置（暂时以摄像机为中心点）
    public Transform centerPos;
    public GameObject bullet;
    //子弹的初始位置
    public Transform bulletPos;
    //发射频率(此处为一秒4次)
    public float fireTime = 1f;
    private float fireNextTime = 0f;
    //边界偏移量
    public float xOffset = 6f;
    public float yOffset = 4f;

    // Update is called once per frame
    void Update()
    {
        BulletShoot();
        Move(speed);
    }
    //子弹生成
    private void BulletShoot()
    {
        //控制子弹自动发射
        fireNextTime += Time.deltaTime;
        if (fireNextTime >= fireTime)
        {
            Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
            fireNextTime = 0f;
        }
        
    }
    //控制移动
    private void Move(float speed)
    {
        //自向上飞行
        transform.Translate(Vector3.forward * FlyUp.speed*Time.deltaTime); 
        //this.GetComponent<Rigidbody>().velocity = Vector3.forward * FlyUp.speed;
        //控制移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(h, v);
        this.GetComponent<Rigidbody>().velocity = move * speed;
        //限制移动边框
        this.GetComponent<Rigidbody>().position = new Vector2(
        Mathf.Clamp(this.transform.position.x, centerPos.position.x - xOffset, centerPos.position.x + xOffset),
        Mathf.Clamp(this.transform.position.y, centerPos.position.y - yOffset, centerPos.position.y + yOffset));
    }
}

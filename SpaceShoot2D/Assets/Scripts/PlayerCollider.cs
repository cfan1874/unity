using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour{

    public GameObject effect;
    /// <summary>
    /// 碰撞发生时触发
    /// </summary>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            //添加特效
            GameObject currentEffect = GameObject.Instantiate(effect) as GameObject;
            currentEffect.transform.position = collider.gameObject.transform.position;
            //销毁
            BulletDestroy(this.gameObject, currentEffect, 1f);
        }
    }
    /// <summary>
    /// 子弹的销毁
    /// </summary>
    /// <param name="bullet"></param>
    private void BulletDestroy(GameObject bullet)
    {
        Destroy(bullet);
    }
    /// <summary>
    /// 子弹和特效的销毁
    /// </summary>
    /// <param name="bullet"></param>
    /// <param name="effect"></param>
    /// <param name="playTime">特效的销毁时间，如果立即销毁就看不到特效</param>
    private void BulletDestroy(GameObject bullet, GameObject effect, float playTime)
    {
        BulletDestroy(bullet);
        Destroy(effect, playTime);
    }

}
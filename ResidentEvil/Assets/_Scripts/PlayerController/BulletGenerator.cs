using UnityEngine;
using System.Collections;

public class BulletGenerator : MonoBehaviour {

    public GameObject bulletPrefab;
    //发射的频率,每秒多少发
    public float shootRate=10;
    
    private float shootTime;
    private bool isFiring=false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }
        if (isFiring)
        {
            shootTime += Time.deltaTime;
            if (shootTime > 1 / shootRate)
            {
                Shoot();
                shootTime = 0;
            }
        }
    }
    void Shoot(){
        print(transform.position+"---"+ transform.rotation);
        GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}

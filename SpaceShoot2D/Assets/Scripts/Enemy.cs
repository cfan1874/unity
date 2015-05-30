using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float speed = 2f;
	// Use this for initialization
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.down * speed;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

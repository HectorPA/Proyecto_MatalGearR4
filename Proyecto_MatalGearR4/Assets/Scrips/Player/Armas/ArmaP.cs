using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaP : MonoBehaviour {

    public float speed;
    Vector3 playerPos;
    Vector3 moveDir;
    public int Hurt =10;

    public virtual void Start()
    {
        playerPos = GameObject.Find("Enemy").transform.position;
        moveDir = (playerPos - transform.position).normalized;
    }

    public virtual void Movement()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void Update()
    {
        Movement();
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
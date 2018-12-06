using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    public float speed;
    Vector3 playerPos;
    Vector3 moveDir;

    public virtual void Start()
    {
        playerPos = GameObject.Find("Player").transform.position;
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
        if (col.tag == "Player")
        {
            print("Colisión Con Jugador");
            Destroy(gameObject);
        }
    }
}
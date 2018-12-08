using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    public float speed;
    Vector3 playerP;
    Vector3 dire;
    public int Hurt = 10;

    public virtual void Start()
    {
        playerP = GameObject.Find("Player").transform.position;
        dire = (playerP - transform.position).normalized;
    }

    public virtual void mueve()
    {
        transform.position += dire * speed * Time.deltaTime;
    }

    void Update()
    {
        mueve();
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
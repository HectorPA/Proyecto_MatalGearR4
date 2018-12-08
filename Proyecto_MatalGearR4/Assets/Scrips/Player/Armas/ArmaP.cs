using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaP : MonoBehaviour {

    public float speed;
    Vector3 enemyP;
    Vector3 dire;
    public int Hurt =10;

    public virtual void Start()
    {
        enemyP = GameObject.Find("Enemy").transform.position;
        dire = (enemyP - transform.position).normalized;
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
        if (col.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
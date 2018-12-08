using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMina : MonoBehaviour {
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            Player player = obj.GetComponent<Player>();
            player.CanMi += 2;
            Destroy(rb.gameObject);
        }
    }
}

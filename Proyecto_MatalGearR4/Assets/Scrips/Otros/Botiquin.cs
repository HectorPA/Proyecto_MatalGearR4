using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour {

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
            player.hp += 10;
            GameObject hpBarP = GameObject.Find("hpBarP");
            Vector3 scale = hpBarP.transform.localScale;
            scale.x = (float)player.hp / 100f;
            hpBarP.transform.localScale = scale;
            Destroy(rb.gameObject);
        }

    }
}

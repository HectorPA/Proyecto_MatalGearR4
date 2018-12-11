using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotiquinPela : MonoBehaviour {
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (col.tag.Equals("Enemy"))
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
            GranJefaso enemy = obj.GetComponent<GranJefaso>();
            enemy.vida += 50;
            GameObject hpBarP = GameObject.Find("hpBarP");
            Vector3 scale = hpBarP.transform.localScale;
            scale.x = (float)enemy.vida / 1000f;
            hpBarP.transform.localScale = scale;
            Destroy(rb.gameObject);
        }
    }
}

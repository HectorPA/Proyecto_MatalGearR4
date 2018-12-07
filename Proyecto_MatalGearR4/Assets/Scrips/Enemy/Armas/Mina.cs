using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : Arma {

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            Player player = obj.GetComponent<Player>();
            player.hp -= Hurt+10;

            if (player.hp < 0)
            {
                player.hp = 0;
            }

            GameObject HpBar = GameObject.Find("HpBar");
            Vector3 scale = HpBar.transform.localScale;
            scale.x = (float)player.hp / 100f;
            HpBar.transform.localScale = scale;

            if (player.hp <= 0)
            {
                Destroy(col.gameObject);
            }

            Destroy(gameObject);
        }
    }
}

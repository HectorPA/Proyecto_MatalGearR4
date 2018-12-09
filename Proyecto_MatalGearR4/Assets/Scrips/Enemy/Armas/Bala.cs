using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : Arma {

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            Player player = obj.GetComponent<Player>();
            if (player.Chaleco > 0) {
                player.Chaleco -= Hurt;
                if (player.Chaleco < 0)
                {
                    player.Chaleco = 0;
                }

                GameObject Escudo = GameObject.Find("Escudo");
                Vector3 scale = Escudo.transform.localScale;
                scale.x = (float)player.Chaleco / 100f;
                Escudo.transform.localScale = scale;
            }
            else
            {
                player.hp -= Hurt;
                if (player.hp < 0)
                {
                    player.hp = 0;
                }

                GameObject HpBar = GameObject.Find("HpBar");
                Vector3 scale = HpBar.transform.localScale;
                scale.x = (float)player.hp / 100f;
                HpBar.transform.localScale = scale;
            }

            

            if (player.hp <= 0)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        if (col.tag == "Obstaculo")
        {
            Destroy(gameObject);
        }
    }
}

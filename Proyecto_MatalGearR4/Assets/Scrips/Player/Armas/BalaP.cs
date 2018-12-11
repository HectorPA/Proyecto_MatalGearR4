using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaP : ArmaP {

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
            GranJefaso Enemy= obj.GetComponent<GranJefaso>();
            Enemy.vida-= Hurt;

            if (Enemy.vida < 0)
            {
                Enemy.vida = 0;
            }

            GameObject HpBarE = GameObject.Find("HpBarE");
            Vector3 scale = HpBarE.transform.localScale;
            scale.x = (float)Enemy.vida / 1000f;
            HpBarE.transform.localScale = scale;

            if (Enemy.vida <= 0)
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

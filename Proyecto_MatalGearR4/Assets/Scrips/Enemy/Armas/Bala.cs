using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : Arma {

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (col.gameObject.layer == 9)
        {
            print("Colisión con Obstaculo");
            Destroy(gameObject);
        }
    }
}

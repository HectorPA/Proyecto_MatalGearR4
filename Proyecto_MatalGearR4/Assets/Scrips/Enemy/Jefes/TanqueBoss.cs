using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TanqueBoss : BaseEnemy {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Caja")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Bala")
        {
            vida -= 10;
            Destroy(collision.gameObject);
        }
    }
}

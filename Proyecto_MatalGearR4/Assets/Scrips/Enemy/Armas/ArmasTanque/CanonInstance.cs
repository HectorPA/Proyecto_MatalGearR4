using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonInstance : MonoBehaviour {
    public bool canon = false;
    TanqueBoss tanboss;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "Player")
        {
            canon = true;
            if (canon == true)
            {
                tanboss.Bola();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canon = false;

    }
}

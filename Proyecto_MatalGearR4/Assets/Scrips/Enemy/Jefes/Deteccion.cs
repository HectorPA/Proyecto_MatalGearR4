using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour {

    public bool deteccion;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && !deteccion)
        {
            deteccion = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            deteccion = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colliders)
    {
        if (colliders.tag == "Player")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Torreta");
            Turret padre = obj.GetComponent<Turret>();
            padre.empezarAtaque = true;
        }
    }

    void OnTriggerExit2D(Collider2D colliders)
    {
        if (colliders.tag == "Player")
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Torreta");
            Turret padre = obj.GetComponent<Turret>();
            padre.empezarAtaque = false;
        }
    }
}

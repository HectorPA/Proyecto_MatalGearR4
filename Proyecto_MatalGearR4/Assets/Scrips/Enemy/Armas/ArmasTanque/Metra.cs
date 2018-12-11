using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metra : MonoBehaviour {

    public bool Metral = false;
    public GameObject balaM;
    public GameObject Spawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Metral = true;
            if (Metral == true)
            {
                Metras();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Metral = false;
    }
    public void Metras()
    {
        StartCoroutine("Metralla");
    }
    IEnumerator Metralla()
    {
        Instantiate(balaM, Spawn.transform.position, Spawn.transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Metras();
    }
}

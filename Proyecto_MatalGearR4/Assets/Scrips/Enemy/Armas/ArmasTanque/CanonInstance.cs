using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CanonInstance : MonoBehaviour {

    public bool canon = false;
    public bool Metral = false;
    public GameObject balaM;
    public GameObject balaC;
    public GameObject Spawn;
    AIPath aipathh;


    private void Start()
    { 

    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            canon = true;
            if (canon == true)
            {
                Bola();

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canon = false;
    }
    public void Bola()
    {
        StartCoroutine("Bolac");
    }
    IEnumerator Bolac()
    {
        Instantiate(balaC, Spawn.transform.position, Spawn.transform.rotation);
        yield return new WaitForSeconds(2.5f);
        Bola();
    }
}

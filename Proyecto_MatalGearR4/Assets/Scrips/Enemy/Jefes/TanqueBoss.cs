using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueBoss : MonoBehaviour
{
    public GameObject Bala;
    public GameObject BalaCanon;
    

    private void Start()
    {

    }
    private void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Caja")
        {
            obj.gameObject.SetActive(false);
        }
    }
    public void Bola()
    {
        StartCoroutine("CanA");
    }
    public IEnumerator CanA()
    {
        Debug.Log("Holaaaaaaaaaaa");
        Instantiate(BalaCanon, BalaCanon.transform.position, BalaCanon.transform.rotation);
        yield return new WaitForSeconds(0.8f);
    }
}
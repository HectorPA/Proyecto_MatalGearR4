using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDoor : MonoBehaviour {

    [Header("Datos de la puerta laser")]
    public float distanciaAtacarX;
    public float distanciaAtacarY;
    public bool sensorActivar;
    public GameObject target;
    public GameObject laser;

    // Use this for initialization
    void Start()
    {
        sensorActivar = false;
        laser.SetActive(false);
        StartCoroutine(EstadoDesactivado());
    }

    // Update is called once per frame
    void Update()
    {
        Ataque();

        if (target.transform.position.x > (transform.position.x - distanciaAtacarX) && target.transform.position.y > (transform.position.y - distanciaAtacarY) && target.transform.position.x < (transform.position.x + distanciaAtacarX) && target.transform.position.y < (transform.position.y + distanciaAtacarY))
        {
            StartCoroutine(EstadoActivado());
        }
        else
        {
            StartCoroutine(EstadoDesactivado());
        }
    }

    public void Ataque()
    {
        if (sensorActivar)
        {
            laser.SetActive(true);
        }
        else
        {
            laser.SetActive(false);
        }
    }

    IEnumerator EstadoDesactivado()
    {
        sensorActivar = false;
        yield return null;
    }

    IEnumerator EstadoActivado()
    {
        sensorActivar = true;
        yield return null;
    }
}

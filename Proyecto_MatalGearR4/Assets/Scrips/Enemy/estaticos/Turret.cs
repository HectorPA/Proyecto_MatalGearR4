using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [Header("Datos de la torreta")]
    public float fireRate;
    public float nextFire;
    public float grados; //grados para que servira para moverse a la izquierda
    public float gradosMaximos; //grados que se servira para moverse a la derecha
    public float distanciaAtacar;
    public float velocidad;
    public float renaudarVelocidad;
    public int hp;
    public int maxHp;
    public int municion;
    public int municionMax;

    public bool empezarAtaque;
    public bool recargar;
    public bool esperaVigilancia;

    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject target;
    public GameObject canion;

	// Use this for initialization
	void Start () {
        empezarAtaque = false;
        recargar = false;
        municion = municionMax;
        maxHp = hp;
        esperaVigilancia = false;

	}
	
	// Update is called once per frame
	void Update () {
        Vigilancia();
        Ataque();
    }

    void Vigilancia()
    {
        if (!empezarAtaque)
        {
            Debug.Log("vigilando");
            if (canion.transform.localEulerAngles.z > grados && canion.transform.localEulerAngles.z < gradosMaximos)
            {
                Debug.Log("Cambiando direccion");
                if (!esperaVigilancia)
                {
                    esperaVigilancia = true;
                    StartCoroutine(Espera());
                }
            } 
            canion.transform.Rotate(Vector3.forward * velocidad * Time.deltaTime);
        }

        else
        {
            
            Debug.Log("hora de atacar");
            Vector2 direccion = target.transform.position - canion.transform.position;
            float anguloAtaque = Mathf.Atan2(direccion.x, direccion.y) * Mathf.Rad2Deg;
            canion.transform.rotation = Quaternion.AngleAxis(anguloAtaque, Vector3.back);
        }

    }

    void Ataque()
    {
        if(Time.time > nextFire && !recargar && empezarAtaque)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            municion--;
            if(municion <= 0 && !recargar)
            {
                recargar = true;
                StartCoroutine(RecargaMunicion());
            }
        }
    }

    IEnumerator Espera()
    {
        renaudarVelocidad = velocidad;
        velocidad = 0;
        Debug.Log("Esperando");
        yield return new WaitForSeconds(2.0f);
        velocidad = renaudarVelocidad;
        velocidad *= -1;
        yield return new WaitForSeconds(2.0f);
        esperaVigilancia = false;
    }

    IEnumerator RecargaMunicion()
    {
        yield return new WaitForSeconds(3.0f);
        municion = municionMax;
        recargar = false;
    }
}

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
    public int hp;
    public int maxHp;
    public int municion;

    public bool empezarAtaque;
    public bool recargar;

    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject target;

	// Use this for initialization
	void Start () {
        empezarAtaque = false;
        recargar = true;

	}
	
	// Update is called once per frame
	void Update () {
        Vigilancia();

        if (target.transform.position.x > -distanciaAtacar && target.transform.position.y < distanciaAtacar && target.transform.position.x < distanciaAtacar)
        {
            empezarAtaque = true;
        }

        else
        {
            empezarAtaque = false;

        }
    }

    void Vigilancia()
    {
        if (!empezarAtaque)
        {
            if (bulletSpawn.transform.localEulerAngles.z > grados && bulletSpawn.transform.localEulerAngles.z < gradosMaximos)
            {
                Debug.Log("Cambiando direccion");
                velocidad *= -1;
            }

            bulletSpawn.transform.Rotate(Vector3.forward * velocidad * Time.deltaTime);
        }

        else
        {
            Vector2 direccion = target.transform.position - bulletSpawn.transform.position;
            float anguloAtaque = Mathf.Atan2(direccion.x * -1, direccion.y * -1) * Mathf.Rad2Deg;
            bulletSpawn.transform.rotation = Quaternion.AngleAxis(anguloAtaque, Vector3.back);
            Ataque();
        }
    }

    void Ataque()
    {
        if(Time.time > nextFire && !recargar)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            municion--;
            if(municion <= 0 && !recargar)
            {
                recargar = true;
            }
        }
    }
}

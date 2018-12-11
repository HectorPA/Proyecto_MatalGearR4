using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GranJefaso : BaseEnemy{

    public bool Points = false;
    public bool next = false;
    public int peligro;
    public int rand;
    int maxV;

    public GameObject Pistola;
    public GameObject Metralleta;
    public GameObject Minas;
    public GameObject player;    
    public Deteccion sensor1, sensor2;


    public enum Status { Face1, Face2 }
    public Status estado;
    public enum Colliding { None, Sensor1, Sensor2 }
    public Colliding colicion;


    AIDestinationSetter destino;
    AILerp aiLerp;

    Coroutine Arma1, Arma2, DejarMina;
    // Use this for initialization
    void Awake()
    {
        aiLerp = GetComponent<AILerp>();
        maxV = vida;
        estado = Status.Face1;
        colicion = Colliding.None;
        //player = GameObject.FindGameObjectWithTag("Player");
        destino = GetComponent<AIDestinationSetter>();
        indexWayPoints = 0;

        rand = Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        estado = EstaActu();
        colicion = ColiCon();
        //puedes usar el arma de
        Shoot(colicion);
        aiLerp.speed = VelociEstado(estado);
        MinaEstado(estado);
        //intento de rotacion
        /*
            float a = player.transform.position.y - transform.position.y;
            float b = player.transform.position.x - transform.position.x;
            float c = Mathf.Sqrt(a * a + b * b);

            float ang = Mathf.Asin(a / c);

            transform.rotation = Quaternion.EulerAngles(0, 0, ang);
            */
        Movement();

    }
    public override void Movement()
    {
        //adonde vamos
        while (next==true) {
            rand = Random.Range(0, 9);
            break;
        }        
        //modo de caminar
        if (Points==true)
        {
            //Si es jugador el obejtico cambialo 
            if (destino.target == player.gameObject.transform) {
                destino.target = points[rand];
            }
            //camina a este lugar
            if (Vector3.Distance(transform.position, destino.target.position) < 0.1f)            
            {
                indexWayPoints = (rand) % points.Length;
                destino.target = points[indexWayPoints];
                //ya estamos en ese lugar puedes busacar otro
                if (transform.position == points[indexWayPoints].transform.position)
                {
                    next = true;
                }
            }
        }
        //estamos chidos busca y destruir
        else if(Points == false)
        {
            destino.target = player.gameObject.transform;
        }
    }
    void MinaEstado(Status current)
    {
        switch (current)
        {
            case Status.Face2:
                if (DejarMina == null) DejarMina = StartCoroutine(Mina());
                break;
            default:
                if (DejarMina != null)
                {
                    StopCoroutine(DejarMina);
                    DejarMina = null;
                }
                break;
        }
    }
    //puedes atacar de esta forma 
    void Shoot(Colliding current)
    {
        switch (current)
        {
            case Colliding.Sensor1:
                //estamos lejos dale con la metra
                if (Arma2 != null)
                {
                    StopCoroutine(Arma2);
                    Arma2= null;
                }
                if (Arma1 == null)
                {
                    Arma1 = StartCoroutine(MetraD());                        
                       }
                break;
            case Colliding.Sensor2:
                //muy serca saca la pistola
                if (Arma1 != null)
                {
                    StopCoroutine(Arma1);
                    Arma1 = null;
                }
                if (Arma2 == null)
                {
                    Arma2 = StartCoroutine(PistolaD());
                }
                break;
            case Colliding.None:
                if (Arma1 != null)
                {
                    StopCoroutine(Arma1);
                    Arma1 = null;
                }
                if (Arma2 != null)
                {
                    StopCoroutine(Arma2);
                    Arma2 = null;
                }
                break;
        }
    }
    //como caminamos
    float VelociEstado(Status current)
    {
        float value = 0.1f;
        switch (current)
        {
            //todo chido muerte a los infieles
            case Status.Face1:
                value = speed;
                break;
            //corre perra corre 
            case Status.Face2:
                value = speed2;
                Points = true;
                break;
        }
        return value;
    }
    //minas
    IEnumerator Mina()
    {
        while (true)
        {
            Instantiate(Minas, transform.position, Minas.transform.rotation);
            yield return new WaitForSeconds(2.5f);
        } 
    }
    //pistola
    IEnumerator PistolaD()
    {
        while (true)
        {
            Instantiate(Pistola, transform.position, Pistola.transform.rotation);
            yield return new WaitForSeconds(1.2f);
        }
    }
    //metra
    IEnumerator MetraD()
    {
        while (true)
        {
            Instantiate(Metralleta, transform.position, Metralleta.transform.rotation);
            yield return new WaitForSeconds(0.7f);
        }
    }

    //estamos en 
    Status EstaActu()
    {
        Status value = Status.Face1;
        if (vida < peligro)
        {
            value = Status.Face2;
        }
        return value;
    }

    //coliciona con 
    Colliding ColiCon()
    {
        Colliding value = Colliding.None;
        if (sensor1.deteccion && !sensor2.deteccion)
        {
            value = Colliding.Sensor1;
        }
        else if (sensor2.deteccion)
        {
            value = Colliding.Sensor2;
        }
        return value;
    }

}

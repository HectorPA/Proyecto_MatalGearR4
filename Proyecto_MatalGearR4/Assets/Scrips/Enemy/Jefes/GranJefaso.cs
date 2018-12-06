using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GranJefaso : BaseEnemy{

    
    int maxLife;
    [Range(0.1f, 0.99f)]
    public double phase2Percentage;
    [Range(0.1f, 3f)]
    public float velocity1, velocity2;

    public GameObject prefabBalaMetralla;
    public GameObject prefabBalaEscopeta;
    public GameObject prefabMina;

    public Deteccion sensor1, sensor2;

    public enum Status { Phase1, Phase2 }
    public Status status;
    public enum Colliding { None, Sensor1, Sensor2 }
    public Colliding colliding;

    AILerp aiLerp;

    Coroutine shooting1Co, shooting2Co, minaCo;
    // Use this for initialization
    void Start()
    {
        aiLerp = GetComponent<AILerp>();
        maxLife = vida;
        status = Status.Phase1;
        colliding = Colliding.None;
    }

    // Update is called once per frame
    void Update()
    {
        status = StatusHandler();
        colliding = CollitionHandler();

        Shoot(colliding);
        aiLerp.speed = VelocityHandler(status);
        MinaHandler(status);
    }

    void MinaHandler(Status current)
    {
        switch (current)
        {
            case Status.Phase2:
                if (minaCo == null) minaCo = StartCoroutine(Mina());
                break;
            default:
                if (minaCo != null)
                {
                    StopCoroutine(minaCo);
                    minaCo = null;
                }
                break;
        }
    }

    void Shoot(Colliding current)
    {
        switch (current)
        {
            case Colliding.Sensor1:
                if (shooting2Co != null)
                {
                    StopCoroutine(shooting2Co);
                    shooting2Co = null;
                }
                if (shooting1Co == null) shooting1Co = StartCoroutine(Shooting1());
                break;
            case Colliding.Sensor2:
                if (shooting1Co != null)
                {
                    StopCoroutine(shooting1Co);
                    shooting1Co = null;
                }
                if (shooting2Co == null) shooting2Co = StartCoroutine(Shooting2());
                break;
            case Colliding.None:
                if (shooting1Co != null)
                {
                    StopCoroutine(shooting1Co);
                    shooting1Co = null;
                }
                if (shooting2Co != null)
                {
                    StopCoroutine(shooting2Co);
                    shooting2Co = null;
                }
                break;
        }
    }

    float VelocityHandler(Status current)
    {
        float value = 0.1f;
        switch (current)
        {
            case Status.Phase1:
                value = velocity1;
                break;
            case Status.Phase2:
                value = velocity2;
                break;
        }
        return value;
    }

    IEnumerator Mina()
    {
        while (true)
        {
            print("Mina");
            Instantiate(prefabMina, transform.position, prefabMina.transform.rotation);
            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator Shooting1()
    {
        while (true)
        {
            //print("Shot1");
            Instantiate(prefabBalaMetralla, transform.position, prefabBalaMetralla.transform.rotation);
            yield return new WaitForSeconds(1.2f);
        }
    }

    IEnumerator Shooting2()
    {
        while (true)
        {
            //print("Shot2");
            Instantiate(prefabBalaEscopeta, transform.position, prefabBalaEscopeta.transform.rotation);
            yield return new WaitForSeconds(0.7f);
        }
    }

    Status StatusHandler()
    {
        Status value = Status.Phase1;
        if (vida < maxLife * phase2Percentage)
        {
            print("Deberia Funcionar");
            value = Status.Phase2;
        }
        return value;
    }

    Colliding CollitionHandler()
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

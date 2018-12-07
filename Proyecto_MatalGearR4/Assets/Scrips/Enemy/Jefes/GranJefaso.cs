using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GranJefaso : BaseEnemy{

    
    int maxLife;
    [Range(0.1f, 0.99f)]
    public double phase2Percentage;
    [Range(0.1f, 3f)]
    public float speed2;

    public GameObject prefabBalaMetralla;
    public GameObject prefabBalaEscopeta;
    public GameObject prefabMina;
    public GameObject player;
    public bool Points = false;
    public Deteccion sensor1, sensor2;


    public enum Status { Phase1, Phase2 }
    public Status status;
    public enum Colliding { None, Sensor1, Sensor2 }
    public Colliding colliding;


    AIDestinationSetter destino;
    AILerp aiLerp;

    Coroutine shooting1Co, shooting2Co, minaCo;
    // Use this for initialization
    void Start()
    {
        aiLerp = GetComponent<AILerp>();
        maxLife = vida;
        status = Status.Phase1;
        colliding = Colliding.None;
        player = GameObject.FindGameObjectWithTag("Player");
        destino = GetComponent<AIDestinationSetter>();
        indexWayPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        status = StatusHandler();
        colliding = CollitionHandler();

        Shoot(colliding);
        aiLerp.speed = VelocityHandler(status);
        MinaHandler(status);
    /*
        float a = player.transform.position.y - transform.position.y;
        float b = player.transform.position.x - transform.position.x;
        float c = Mathf.Sqrt(a * a + b * b);

        float ang = Mathf.Asin(a / c);

        transform.rotation = Quaternion.EulerAngles(0, 0, ang);
        */
        

    }
    public override void Movement()
    {
        if (!Points)
        {
            if (transform.position == points[indexWayPoints].position)
            {
                indexWayPoints = (indexWayPoints + 1) % points.Length;
                destino.target = points[indexWayPoints];
            }
        }
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
                value = speed;
                break;
            case Status.Phase2:
                value = speed2;
                Points = true;
                break;
        }
        return value;
    }

    IEnumerator Mina()
    {
        while (true)
        {
            Instantiate(prefabMina, transform.position, prefabMina.transform.rotation);
            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator Shooting1()
    {
        while (true)
        {
            Instantiate(prefabBalaMetralla, transform.position, prefabBalaMetralla.transform.rotation);
            yield return new WaitForSeconds(1.2f);
        }
    }

    IEnumerator Shooting2()
    {
        while (true)
        {
            Instantiate(prefabBalaEscopeta, transform.position, prefabBalaEscopeta.transform.rotation);
            yield return new WaitForSeconds(0.7f);
        }
    }

    Status StatusHandler()
    {
        Status value = Status.Phase1;
        if (vida < maxLife * phase2Percentage)
        {
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

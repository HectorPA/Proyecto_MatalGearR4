using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
    [Header ("Waypoints")]
    
    public Transform[] points;  
    [Range(1.0f, 10.0f)]
    public float speed,speed2;

    private Vector3 currentPoint;
    protected int indexWayPoints = 0;
    protected GameObject thePlayer;
    public int vida;


    void Start()
    {
        thePlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update ()
    {
        Movement();
    }

  

    public virtual void Movement()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (transform.position == points[i].transform.position)
            {
                if (transform.position == points[points.Length - 1].transform.position)
                {
                    currentPoint = points[0].transform.position;
                }
                else
                {
                    currentPoint = points[i + 1].transform.position;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, currentPoint, speed * Time.deltaTime);//mivimiento de un punto a otro lileanal

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class EnemigoMovv : BaseEnemy {
  
    AIDestinationSetter destino;

    bool playerDec = false;

    public Deteccion sensor1;

    public GameObject Metralleta;
    public enum Colliding { None, Sensor1}
    public Colliding colicion;
    
    void Awake()
    {
        //Se llama el scrip
        destino = GetComponent<AIDestinationSetter>();
        indexWayPoints = 0;
        colicion = Colliding.None;
        //destino.target = points[currentPoint];
    }

    // Update is called once per frame
    


    public override void Movement()
    {
        if (!playerDec)
        {
            if (transform.position == points[indexWayPoints].position)
            {
                indexWayPoints = (indexWayPoints + 1) % points.Length;
                destino.target = points[indexWayPoints];
            }
        }   
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player"){
            playerDec = true;
            destino.target = obj.transform;
            GameObject texObj = GameObject.Find("EstadoJugador");
            Text txt = texObj.GetComponent<Text>();
            txt.text = "[DETECTADO]";
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            playerDec = false;
            StartCoroutine(AlarmaOff());
        }
    }

    IEnumerator AlarmaOff()
    {
        GameObject texObj = GameObject.Find("EstadoJugador");
        Text txt = texObj.GetComponent<Text>();
        txt.text = "[ESCAPANDO EN 3]";
        yield return new WaitForSeconds(1.0f);
        txt.text = "[ESCAPANDO EN 2]";
        yield return new WaitForSeconds(1.0f);
        txt.text = "[ESCAPANDO EN 1]";
        yield return new WaitForSeconds(1.0f);
        txt.text = "[OCULTO]";
        destino.target = points[indexWayPoints];
    }
    void Shoot(Colliding current)
    {
        switch (current)
        {
            case Colliding.Sensor1:
                //estamos lejos dale con la metra
               StartCoroutine(MetraD());
                break;
            case Colliding.None:
              
                break;
        }
    }
    IEnumerator MetraD()
    {
        while (true)
        {
            Instantiate(Metralleta, transform.position, Metralleta.transform.rotation);
            yield return new WaitForSeconds(0.7f);
        }
    }
    Colliding ColiCon()
    {
        Colliding value = Colliding.None;
        if (sensor1.deteccion)
        {
            value = Colliding.Sensor1;
        }
        return value;
    }
    /*public virtual void Movement(){
        //Se quita movimiento anterio no deja el vector 3 deo current        
        if (Vector3.Distance(transform.position, destino.target.position) < 0.1f){
            currentPoint ++;
            if (currentPoint >= points.Length) {
                currentPoint = 0;
            }
            destino.target = points[currentPoint];
        }       
    }*/
}

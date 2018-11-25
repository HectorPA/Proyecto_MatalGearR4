using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float forceX = 10;
    public float forceY = 10;
    public float maxX = 4;
    public float maxY = 4;
    public int hp = 100;
    public int shield = 100;//por si quieren escudo 
    public int disparos = 4;
    public GameObject arma1;

    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        movimiento();
    }
    void movimiento(){
        float valX = Input.GetAxis("Horizontal");
        float valY = Input.GetAxis("Vertical");

        float velX = valX * forceX;
        float velY = valY * forceY;

        rb.AddForce(new Vector2(velX, velY));
        //caminar
        if (rb.velocity.x > maxX || rb.velocity.x < -maxX)
        {
            Vector2 limit = rb.velocity;
            if (limit.x > 0)
            {
                limit.x = maxX;
            }
            else
            {
                limit.x = -maxX;
            }
            rb.velocity = limit;
        }
        if (rb.velocity.y > maxY || rb.velocity.y < -maxY)
        {
            Vector2 limit = rb.velocity;
            if (limit.y > 0)
            {
                limit.y = maxY;
            }
            else
            {
                limit.y = -maxY;
            }
            rb.velocity = limit;
        }
        //freno
        if (valX == 0)
        {
            Vector2 freno = rb.velocity;
            freno.x -= rb.velocity.x * 0.1f;
            rb.velocity = freno;
        }
        if (valY == 0)
        {
            Vector2 freno = rb.velocity;
            freno.y -= rb.velocity.y * 0.1f;
            rb.velocity = freno;
        }
    }
}

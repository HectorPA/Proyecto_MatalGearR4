using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EcenaControl : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D rb;
    public string identificador;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag.Equals("Player"))
        {
            switch (identificador) {
                case "PortalZ1":
                    SceneManager.LoadScene("Level1Vics");
                    break;
                case "PortalZ1_1":
                    SceneManager.LoadScene("Level2Vics");
                    break;
                case "PortalZ1_2":
                    SceneManager.LoadScene("Level3Vics");
                    break;
                case "PortalZ1_3":
                    SceneManager.LoadScene("boos1");
                    break;
                case "PortalZ2":
                    SceneManager.LoadScene("Level1Vics");
                    break;
                case "PortalZ2_3":
                    SceneManager.LoadScene("RicTanqueBoss");
                    break;
            }
        }        
    }
}

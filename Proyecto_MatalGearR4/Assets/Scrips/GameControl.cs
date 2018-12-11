using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    int numlar = 1;
    public GameObject BotiquinP;
    public GameObject BotiquinP1;
    public GameObject BotiquinP2;
    public GameObject BotiquinP3;
    public GameObject BotiquinP4;
    public GameObject MinasP;


	// Use this for initialization
	void Awake() {
        StartCoroutine("SpawSelecion");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawSelecion() {
        int rand = Random.Range(0, 5);
        switch (rand)
        {
            case 0:
                //StartCoroutine("SpawnBotiquin");
                break;
            case 1:
                StartCoroutine("SpawnBotiquin");
                break;
            case 2:
                StartCoroutine("SpawnBotiquin");
                break;
            case 3:
               // StartCoroutine("SpawnBotiquin");
                break;
            case 4:
                StartCoroutine("SpawnBotiquin");
                break;
            case 5:
                StartCoroutine("SpawnBotiquin");
                break;
        }


    }
    IEnumerator SpawnBotiquin()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        Player player = obj.GetComponent<Player>();
        int rand1 = Random.Range(0, 4);
        switch (rand1)
        {
            case 0:
                if (player.hp < 70)
                {
                    for (int i = 0; i < numlar; i++)
                    {
                        Instantiate(BotiquinP);
                        yield return new WaitForSeconds(0);
                    }
                }
                break;
            case 1:
                if (player.hp < 70)
                {
                    for (int i = 0; i < numlar; i++)
                    {
                        Instantiate(BotiquinP1);
                        yield return new WaitForSeconds(0);
                    }
                }
                break;
            case 2:
                if (player.hp < 70)
                {
                    for (int i = 0; i < numlar; i++)
                    {
                        Instantiate(BotiquinP);
                        yield return new WaitForSeconds(0);
                    }
                }
                break;
            case 3:
                if (player.hp < 70)
                {
                    for (int i = 0; i < numlar; i++)
                    {
                        Instantiate(BotiquinP3);
                        yield return new WaitForSeconds(0);
                    }
                }
                break;
            case 4:
                if (player.hp < 70)
                {
                    for (int i = 0; i < numlar; i++)
                    {
                        Instantiate(BotiquinP4);
                        yield return new WaitForSeconds(0);
                    }
                }
                break;
        }
        SpawSelecion();
    }
    public void lose()
    {

        GameObject obj = GameObject.Find("loseText");
        Text txt = obj.GetComponent<Text>();
        txt.enabled = true;
        StartCoroutine(loseProcess());
    }

    IEnumerator loseProcess()
    {
        yield return new WaitForSeconds(3.0F);
        SceneManager.LoadScene("menu");

    }
    public void Win()
    {

        GameObject obj = GameObject.Find("WinText");
        Text txt = obj.GetComponent<Text>();
        txt.enabled = true;
        StartCoroutine(WinP());
    }

    IEnumerator WinP()
    {
        yield return new WaitForSeconds(3.0F);
        SceneManager.LoadScene("menu");

    }
}

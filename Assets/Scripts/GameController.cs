using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public bool bulletammo;
    [HideInInspector] public int ammo;
    [HideInInspector] public bool pickupammo;
    public Transform enemy;
    public GameObject player;
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;
    [HideInInspector] public int wave;
    GameObject[] enemiesleft;
    [HideInInspector] public int enemleft;
    [HideInInspector] public int newenemies;
    private bool waveover;
    [HideInInspector] public int money;


    private void Start()
    {
        bulletammo = true;
        ammo = 100;
        pickupammo = false;
        wave = 1;
        money = 0;
        newenemies = newenem();
        waveover = true;
        spawning();
    }

    public void Update()
    {
        if(ammo > 0)
        {
            bulletammo = true;
        }
        else
        {
            bulletammo = false;
        }
        enemiesleft = GameObject.FindGameObjectsWithTag("Enemy");
        enemleft = enemiesleft.Length;
        if(enemleft == 0)
        {
            waveover = true;
            Debug.Log("Wave over");
            wave++;
            spawning();
            waveover = false;
        }
        else
        {
            waveover = false;
        }
    }

    public void looseammo()
    {
        if(ammo > 0)
        {
            ammo = ammo - 1;
            bulletammo = true;
        }
        else
        {
            ammo = 0;
            bulletammo = false;
        }
    }

    IEnumerator spawnwave()
    {
        Debug.Log("Next wave incoming");
        newenemies = newenem();
        //yield return new WaitForSeconds(5.0f);
        for (int i = 0; i < newenemies; i++)
        {
            int num = randomspawn();
            switch (num)
            {
                case 1:
                        Instantiate(enemy, spawnpoint1.transform.position, spawnpoint1.transform.rotation);
                        yield return new WaitForSeconds(1.5f);
                        break;
                case 2:
                        Instantiate(enemy, spawnpoint2.transform.position, spawnpoint2.transform.rotation);
                        yield return new WaitForSeconds(1.5f);
                        break;
                case 3:
                        Instantiate(enemy, spawnpoint3.transform.position, spawnpoint3.transform.rotation);
                        yield return new WaitForSeconds(1.5f);
                        break;
            }
            
        }
    }

    private void spawning()
    {
        enemiesleft = GameObject.FindGameObjectsWithTag("Enemy");
        enemleft = enemiesleft.Length;

        if ((enemleft == 0) && (waveover == true))
        {
            StartCoroutine(spawnwave());
        }
    }


    //berechnet zufaellige x oder y koordinate fuer Gegnerspawnposition
    //evtl nicht beoetigt wenn fester spawnpunkt
    private float randompos()
    {
        float randx1 = Random.Range(-20.0f, (player.transform.position.x - 0.5f)); //zufaellige x-Koordinate Links oder unten vom Player
        float randx2 = Random.Range((player.transform.position.x + 0.5f), 20.0f); //zufaellige x-Koordinate rechts oder oben vom Player
        
        int randud = Random.Range(1, 2); //Zufallszahl 1 oder 2 -> zum auswaehlen ob randx1 oder randx2

        if (randud == 1)
        {
            return randx1;
        }
        else
        {
            return randx2;
        }
    }

    private int randomspawn()
    {
        int spawn = Random.Range(1, 4);
        return spawn;
    }

    private int newenem()
    {
        int c = wave * (wave + 5) / 2;
        return c;
    }

}

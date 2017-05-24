using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public bool bulletammo;
    [HideInInspector] public int ammo;
    [HideInInspector] public bool pickupammo;
    private float pickupammotime;
    private int wave;
    private bool waveover;
    private int enemiesinfield;
    public GameObject enemy;
    public GameObject player;

    private void Start()
    {
        bulletammo = true;
        ammo = 100;
        pickupammo = false;
        wave = 1;
        waveover = true;
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

    //zustaendig fuer das spawnen der Gegnerwellen

    //UNFERTIG
    public void wavecontroll()
    {
        if (waveover == true)
        {
            
        } 
    }

    //berechnet zufaellige x oder y koordinate fuer Gegnerspawnposition
    public float randompos()
    {
        float randx1 = Random.Range(-8.0f, (player.transform.position.x - 0.5f)); //zufaellige x-Koordinate Links oder unten vom Player
        float randx2 = Random.Range((player.transform.position.x + 0.5f), 8.0f); //zufaellige x-Koordinate rechts oder oben vom Player
        
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

    public void wave1()
    {
        GameObject newenemy = Instantiate(enemy) as GameObject;
        newenemy.transform.position = new Vector3(this.randompos(), this.randompos(), 0);
        waveover = false;
    }
}

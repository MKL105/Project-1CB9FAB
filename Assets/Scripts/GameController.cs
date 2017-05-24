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

    public void wavecontroll()
    {
        if ((waveover == true) && (wave == 1))
        {
            GameObject newenemy = Instantiate(enemy) as GameObject;
            newenemy.transform.position = new Vector3();
        } 
    }

    public void randompos()
    {
        float randx1 = Random.Range(-8.0f, (player.transform.position.x - 0.5f));
        float randx2 = Random.Range((player.transform.position.x + 0.5f), 8.0f);
        float randy1 = Random.Range(-8.0f, (player.transform.position.y - 0.5f));
        float randy2 = Random.Range((player.transform.position.y + 0.5f), 8.0f);
    }
}

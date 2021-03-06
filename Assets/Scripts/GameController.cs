﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool bulletammo;
    [HideInInspector] public int ammo;
    [HideInInspector] public int maxammo;
    [HideInInspector] public int ammocost;
    [HideInInspector] public int ammoupgradecost;
    [HideInInspector] public int manacost;
    [HideInInspector] public int lifecost;
    [HideInInspector] public bool pickupammo;
    public Transform enemy;
    public Transform enemy2;
    public Transform boss;
    public GameObject player;
    public PlayerController playcon;
    public GameObject manabar;
    public Mana manacon;
    public GameObject healthbar;
    public Health healthcon;
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;
    public GameObject spawnpoint4;
    public GameObject spawnpoint5;
    public GameObject spawnpoint6;
    public GameObject spawnpoint7;
    public GameObject spawnpoint8;
    public GameObject spawnpoint9;
    public GameObject spawnpoint10;
    public GameObject spawnpoint11;
    public GameObject spawnpoint12;
    public GameObject spawnpointboss;
    [HideInInspector] public int wave;
    [HideInInspector] public static int endwave;
    GameObject[] enemiesleft;
    GameObject[] bossleft;
    [HideInInspector] public int enemleft;
    [HideInInspector] public int boleft;
    [HideInInspector] public int newenemies;
    private bool waveover;
    [HideInInspector] public int money;
    [HideInInspector] public float damage;
    [HideInInspector] public int damagecost;
    [HideInInspector] public int mscost;
    [HideInInspector] public int tpcost;
    [HideInInspector] public int mscdr;
    [HideInInspector] public int mscdrcost;
    [HideInInspector] public int tpcdr;
    [HideInInspector] public int tpcdrcost;
    [HideInInspector] public int tpmanareducecosts;
    [HideInInspector] public int tpmanared;
    [HideInInspector] public int msmanareducecosts;
    [HideInInspector] public int msmanared;
    [HideInInspector] public int tprangecosts;
    [HideInInspector] public int tprangeup;
    [HideInInspector] public int speedupcost;
    [HideInInspector] public int spup;
    public GameObject tpupgrades;
    public GameObject msupgrades;
    public AudioSource music;
    public AudioSource bossmusic;

    private void Start()
    {
        playcon = player.GetComponent<PlayerController>();
        manacon = manabar.GetComponent<Mana>();
        healthcon = healthbar.GetComponent<Health>();
        bulletammo = true;
        mscdr = 1;
        tpcdr = 1;
        tpmanared = 1;
        msmanared = 1;
        mscdrcost = 200;
        tpcdrcost = 750;
        tpmanareducecosts = 500;
        msmanareducecosts = 150;
        tprangecosts = 400;
        speedupcost = 500;
        spup = 1;
        tprangeup = 1;
        ammo = 100;
        maxammo = 200;
        pickupammo = false;
        mscost = 150;
        tpcost = 500;
        manacost = 200;
        lifecost = 200;
        wave = 1; // test, nachher wiered auf 1
        money = 0; //zum testen ändern aber wieder auf 0 zurücksetzen
        damage = 1;
        damagecost = 25;
        ammocost = 50;
        ammoupgradecost = 50;
        endwave = wave - 1;
        tpupgrades.gameObject.SetActive(false);
        msupgrades.gameObject.SetActive(false);
        newenemies = newenem();
        waveover = true;
        music.Play();
        music.loop = true;
        spawning();
    }

    public void Update()
    {
        damage = playcon.damage;
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
        bossleft = GameObject.FindGameObjectsWithTag("Boss");
        boleft = bossleft.Length;
        endwave = wave - 1;

        if ((enemleft == 0) && (boleft == 0))
        {
            waveover = true;
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
        newenemies = newenem();
        if ((wave != 10))
        {
            for (int i = 0; i < newenemies; i++)
            {
                int num = randomspawn();
                bossmusic.Pause();
                music.mute = false;
                    switch (num)
                    {
                        case 1:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint1.transform.position, spawnpoint1.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint1.transform.position, spawnpoint1.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 2:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint2.transform.position, spawnpoint2.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint2.transform.position, spawnpoint2.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 3:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint3.transform.position, spawnpoint3.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint3.transform.position, spawnpoint3.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 4:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint4.transform.position, spawnpoint4.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint4.transform.position, spawnpoint4.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 5:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint5.transform.position, spawnpoint5.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint5.transform.position, spawnpoint5.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 6:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint6.transform.position, spawnpoint6.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint6.transform.position, spawnpoint6.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 7:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint7.transform.position, spawnpoint7.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint7.transform.position, spawnpoint7.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 8:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint8.transform.position, spawnpoint8.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint8.transform.position, spawnpoint8.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 9:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint9.transform.position, spawnpoint9.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint9.transform.position, spawnpoint9.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 10:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint10.transform.position, spawnpoint10.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint10.transform.position, spawnpoint10.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 11:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint11.transform.position, spawnpoint11.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint11.transform.position, spawnpoint11.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 12:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpoint12.transform.position, spawnpoint12.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpoint12.transform.position, spawnpoint12.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                        case 13:
                            if (this.randomenemy() == 1)
                            {
                                Instantiate(enemy, spawnpointboss.transform.position, spawnpointboss.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                            else
                            {
                                Instantiate(enemy2, spawnpointboss.transform.position, spawnpointboss.transform.rotation);
                                yield return new WaitForSeconds(1.5f);
                                break;
                            }
                    }
            }
        }
        else
        {
            Instantiate(boss, spawnpointboss.transform.position, spawnpointboss.transform.rotation);
            music.mute = true;
            bossmusic.Play();
            bossmusic.loop = true;
            yield return new WaitForSeconds(1.5f);
        }
            
    }

    private void spawning()
    {
        enemiesleft = GameObject.FindGameObjectsWithTag("Enemy");
        enemleft = enemiesleft.Length;
        bossleft = GameObject.FindGameObjectsWithTag("Boss");
        boleft = bossleft.Length;

        if ((enemleft == 0) && (waveover == true) && (boleft == 0))
        {
            StartCoroutine(spawnwave());
        }
    }

    private int randomspawn()
    {
        int room = playcon.room;

        switch(room)
        {
            case 1:
                return Random.Range(1, 4);
            case 2:
                return Random.Range(4, 8);
            case 3:
                return Random.Range(8, 10);
            case 4:
                return Random.Range(10, 13);
            case 5:
                return 13;
            default:
                return Random.Range(1, 4);
        }
    }

    private int newenem()
    {
        if (wave !=10)
        {
            int c = wave * (wave + 5) / 2;
            return c;
        }
        return 1;
    }

    public void damageup()
    {
        if (money >= damagecost)
        {
            playcon.damage++;
            money -= damagecost;
            damagecost = damagecost*2;
        }
    }

    public void ammoup()
    {
        if (money >= ammocost)
        {
            this.ammo = maxammo;
            money -= ammocost;
        }
    }

    public void unlockmultishot()
    {
        if((money >= mscost) && (playcon.msunlock == false))
        {
            playcon.msunlock = true;
            money -= mscost;
            msupgrades.gameObject.SetActive(true);
        }
    }

    public void unlockteleport()
    {
        if ((money >= tpcost) && (playcon.msunlock == false))
        {
            playcon.tpunlock = true;
            money -= tpcost;
            tpupgrades.gameObject.SetActive(true);
        }
    }

    public void tomenu()
    {
        SceneManager.LoadScene(1);
    }

    public void manabuy()
    {
        if (money >= manacost)
        {
            if (manacon.AktuelleMana < 50.0f)
            {
                manacon.AktuelleMana += 50.0f;
                money -= manacost;
                manacon.setvalue();
            }
            else
            {
                manacon.AktuelleMana = manacon.MaxMana;
                money -= manacost;
                manacon.setvalue();
            }
        }
    }

    public void lifebuy()
    {
        if (money >= lifecost)
        {
            if (healthcon.AktuelleLeben < 70.0f)
            {
                healthcon.AktuelleLeben += 30.0f;
                money -= lifecost;
                healthcon.setvalue();
            }
            else
            {
                healthcon.AktuelleLeben = healthcon.MaxLeben;
                money -= lifecost;
                healthcon.setvalue();
            }
        }
    }

    private int randomenemy()
    {
        int num = Random.Range(1, 101);

        
            if (num <= 7) //Schneller Gegner
            {
                return 2;
            }
            else //normaler Gegner
            {
                return 1;
            }
        
       
    }

    public void upgrademaxammo()
    {
        if (money >= ammoupgradecost)
        {
            maxammo += 50;
            money -= ammoupgradecost;
            ammoupgradecost += 50;
            
        }
    }

    public void reducemscd()
    {
        if ((money >= mscdrcost) && (mscdr < 6))
        {
            playcon.cdmultishot -= 1.0f;
            money -= mscdrcost;
            mscdrcost += 100;
            mscdr++;
            
        }
    }

    public void reducetpcd()
    {
        if ((money >= tpcdrcost) && (tpcdr < 7))
        {
            playcon.cdteleport -= 5.0f;
            money -= tpcdrcost;
            tpcdrcost += 150;
            tpcdr++;
            
        }
    }

    public void reducetpmana()
    {
        if ((money >= tpmanareducecosts) && (tpmanared < 7))
        {
            playcon.tpmana -= 2.0f;
            money -= tpmanareducecosts;
            tpmanareducecosts += 150;
            tpmanared++;
            
        }
    }

    public void reducemsmana()
    {
        if ((money >= msmanareducecosts) && (msmanared < 6))
        {
            playcon.msmana -= 1.0f;
            money -= msmanareducecosts;
            msmanareducecosts += 100;
            msmanared++;
            
        }
    }

    public void upgraderange()
    {
        if ((money >= tprangecosts) && (tprangeup < 6))
        {
            playcon.tprange++;
            money -= tprangecosts;
            tprangecosts += 150;
            tprangeup++;
            
        }
    }

    public void speedbuy()
    {
        if ((money >= speedupcost) && (spup < 4))
        {
            playcon.speed++;
            money -= speedupcost;
            speedupcost += 200;
            spup++;
        }
    }

    public void stopmusic()
    {
        music.Pause();
        bossmusic.Pause();
    }
}


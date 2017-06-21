using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool bulletammo;
    [HideInInspector] public int ammo;
    [HideInInspector] public int ammocost;
    [HideInInspector] public int manacost;
    [HideInInspector] public int lifecost;
    [HideInInspector] public bool pickupammo;
    public Transform enemy;
    public Transform enemy2;
    public GameObject player;
    public PlayerController playcon;
    public GameObject manabar;
    public Mana manacon;
    public GameObject healthbar;
    public Health healthcon;
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;
    [HideInInspector] public int wave;
    GameObject[] enemiesleft;
    [HideInInspector] public int enemleft;
    [HideInInspector] public int newenemies;
    private bool waveover;
    [HideInInspector] public int money;
    [HideInInspector] public float damage;
    [HideInInspector] public int damagecost;
    [HideInInspector] public int mscost;
    [HideInInspector] public int tpcost;


    private void Start()
    {
        playcon = player.GetComponent<PlayerController>();
        manacon = manabar.GetComponent<Mana>();
        healthcon = healthbar.GetComponent<Health>();
        bulletammo = true;
        ammo = 100;
        pickupammo = false;
        mscost = 150;
        tpcost = 500;
        manacost = 200;
        lifecost = 200;
        wave = 1;
        money = 0;
        damage = 1;
        damagecost = 25;
        ammocost = 25;
        newenemies = newenem();
        waveover = true;
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
        newenemies = newenem();
        for (int i = 0; i < newenemies; i++)
        {
            int num = randomspawn();
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
            this.ammo += 25;
            money -= ammocost;
        }
    }

    public void unlockmultishot()
    {
        if(money >= mscost)
        {
            playcon.msunlock = true;
            money -= mscost;
        }
    }

    public void unlockteleport()
    {
        if (money >= tpcost)
        {
            playcon.tpunlock = true;
            money -= tpcost;
        }
    }

    public void tomenu()
    {
        SceneManager.LoadScene(0);
    }

    public void manabuy()
    {
        if (money >= manacost)
        {
            if (manacon.AktuelleMana < 50)
            {
                manacon.AktuelleMana += 50;
            }
            else
            {
                manacon.AktuelleMana = manacon.MaxMana;
            }
        }
    }

    public void lifebuy()
    {
        if (money >= lifecost)
        {
            if (healthcon.AktuelleLeben < 70)
            {
                healthcon.AktuelleLeben += 30;
            }
            else
            {
                healthcon.AktuelleLeben = healthcon.MaxLeben;
            }
        }
    }

    private int randomenemy()
    {
        int num = Random.Range(1, 101);

        if (num <= 3)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}

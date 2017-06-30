using System.Collections;
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
    [HideInInspector] public int wave;
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
        money = 99990; //zum testen ändern aber wieder auf 0 zurücksetzen
        damage = 1;
        damagecost = 25;
        ammocost = 50;
        ammoupgradecost = 50;
        tpupgrades.gameObject.SetActive(false);
        msupgrades.gameObject.SetActive(false);
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
        bossleft = GameObject.FindGameObjectsWithTag("Boss");
        boleft = bossleft.Length;

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
        if (wave != 3)
        {
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
        else
        {
            Instantiate(boss, spawnpoint2.transform.position, spawnpoint2.transform.rotation);
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
        if (wave !=3)
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
        SceneManager.LoadScene(0);
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
            ammoupgradecost += 50;
            money -= ammoupgradecost;
        }
    }

    public void reducemscd()
    {
        if ((money >= mscdrcost) && (mscdr < 6))
        {
            playcon.cdmultishot -= 1.0f;
            mscdrcost += 100;
            mscdr++;
            money -= mscdrcost;
        }
    }

    public void reducetpcd()
    {
        if ((money >= tpcdrcost) && (tpcdr < 7))
        {
            playcon.cdteleport -= 5.0f;
            tpcdrcost += 150;
            tpcdr++;
            money -= tpcdrcost;
        }
    }

    public void reducetpmana()
    {
        if ((money >= tpmanareducecosts) && (tpmanared < 7))
        {
            playcon.tpmana -= 2.0f;
            tpmanareducecosts += 150;
            tpmanared++;
            money -= tpmanareducecosts;
        }
    }

    public void reducemsmana()
    {
        if ((money >= msmanareducecosts) && (msmanared < 6))
        {
            playcon.msmana -= 1.0f;
            msmanareducecosts += 100;
            msmanared++;
            money -= msmanareducecosts;
        }
    }

    public void upgraderange()
    {
        if ((money >= tprangecosts) && (tprangeup < 6))
        {
            playcon.tprange++;
            tprangecosts += 150;
            tprangeup++;
            money -= tprangecosts;
        }
    }

    public void speedbuy()
    {
        if ((money >= speedupcost) && (spup < 4))
        {
            playcon.speed++;
            speedupcost += 200;
            spup++;
            money -= speedupcost;
        }
    }
}


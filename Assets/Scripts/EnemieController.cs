using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour {

    public GameObject player;
    public PlayerController playcon;
    public GameObject area;
    public GameController gamecon;
    private float speed;
    public Rigidbody2D rb;
    public float AktuelleLeben;
    [HideInInspector] public float MaxLeben;
    public GameObject ammodrop;
    public GameObject staminup;
    public GameObject instakill;
    public GameObject damageup;
    public GameObject maxammo;
    private int value; //wie viel Geld der gegner beim tod gibt
    [HideInInspector] public int damage;
    private float ddamage;
    public GameObject healthbar;
    public Health healthcon;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playcon = player.GetComponent<PlayerController>();
        area = GameObject.FindGameObjectWithTag("Wall");
        gamecon = area.GetComponent<GameController>();
        healthbar = GameObject.FindGameObjectWithTag("Health");
        healthcon = healthbar.GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        speed = 2f;
        value = gamecon.wave;
        MaxLeben = gamecon.wave;
        AktuelleLeben = MaxLeben;
        damage = 30;
        ddamage = (float)damage;
    }

    private void Update()
    {
        Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);//berechnet player Poistion
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y); //berechnet Vector2 von eigener Position
        Vector2 direction = playerpos - mypos; //berechnet Richtungsvektor
        direction.Normalize(); //gibt Vektor die Länge 1
        rb.velocity = direction * speed; //sorgt für Bewegung des Enemy

        if (AktuelleLeben <= 0)// Überprüft ob Leben vorhanden ist
        { 
            Die(); // falls nein wird Die() ausgeführt
        }
    }

    // Reduziert verbleibende Leben
    void DealDamage(float Schaden)
    {
        AktuelleLeben -= Schaden/2; //wird durch 2 geteilt da der Enemy doppelt so viel schaden bekommt wie er sollte
    }
 
    void Die()
    {
        int num = randitem();
        switch (num)
        {
            case 1:
                if (this.dropitem(5.0f) == true)
                {
                    GameObject newammo = Instantiate(ammodrop) as GameObject;
                    newammo.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }

            case 2:
                if (this.dropitem(5.0f) == true)
                {
                    GameObject newmaxammo = Instantiate(maxammo) as GameObject;
                    newmaxammo.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }

            case 3:
                if (this.dropitem(5.0f) == true)
                {
                    GameObject newstaminup = Instantiate(staminup) as GameObject;
                    newstaminup.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }

            case 4:
                if (this.dropitem(5.0f) == true)
                {
                    GameObject newdamageup = Instantiate(damageup) as GameObject;
                    newdamageup.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }

            case 5:
                if (this.dropitem(5.0f) == true)
                {
                    GameObject newinstakill = Instantiate(instakill) as GameObject;
                    newinstakill.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    gamecon.money += value;
                    Destroy(gameObject);
                    break;
                }
        }
        
    }

    //Untersucht ob der Enemy eine Kugel berührt
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // falls ja
        {
            DealDamage(playcon.damage);// soll Schaden zugefügt werden 
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                healthcon.DealDamage(this.ddamage);
            }
        }
    }

    //berechnet Dropchance fuer Items
    //gibt true zurück, wenn Item gedroppt werden soll
    private bool dropitem(float dropchance) //in % -> 50.0 = 50%ige Chance
    {
        float drc = dropchance;
        float num = Random.Range(0.0f, 100.0f); //errechnet Zufallszahl zwischen 0 und 100

        if (num < drc) //Item wird fallengelassen
        {
            return true;
        }
        else //Item wird nicht fallengelassen
        {
            return false;
        }
    }

    private int randitem()
    {
        float chan = Random.Range(0.0f, 100.0f);
        if (chan <= 25f) //Munition 25%
        {
            return 1;
        }
        else
        {
            if ((chan > 25f) && (chan <= 37.5)) //Max. Munition 12.5%
            {
                return 2;
            }
            else
            {
                if ((chan > 37.5f) && (chan <= 62.5f)) //Staminup 25%
                {
                    return 3;
                }
                else
                {
                    if ((chan > 62.5f) && (chan <= 87.5f)) // DamageUp 25%
                    {
                        return 4;
                    }
                    else // Instakill 12.5%
                    {
                        return 5;
                    }
                }
            }
        }
    }
}

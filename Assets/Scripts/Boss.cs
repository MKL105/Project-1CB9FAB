using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public GameObject player;
    public PlayerController playcon;
    private float speed;
    public Rigidbody2D rb;
    public float AktuelleLeben;
    [HideInInspector] public float MaxLeben;
    [HideInInspector] public int damage;
    public GameObject area;
    public GameController gamecon;
    private float ddamage;
    private int value;
    public GameObject healthbar;
    public Health healthcon;
    public GameObject bullet; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bul1;
    public GameObject bul2;
    public GameObject bul3;
    public GameObject bul4;
    public GameObject bul5;
    [HideInInspector] public float cdattack; //Cooldownzeit fuer Attacke
    [HideInInspector] public float nextfireatk; //Zeit, wenn die Attacke wieder aufgeladen ist

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playcon = player.GetComponent<PlayerController>();
        healthbar = GameObject.FindGameObjectWithTag("Health");
        healthcon = healthbar.GetComponent<Health>();
        area = GameObject.FindGameObjectWithTag("Wall");
        gamecon = area.GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        speed = 1.5f;
        MaxLeben = 1500f;
        AktuelleLeben = MaxLeben;
        damage = 50;
        ddamage = (float)damage;
        cdattack = 1f;
        value = gamecon.wave * 10;
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
        attack();
    }

    private void Die()
    {
        gamecon.money += value;
        Debug.Log("Boss finished");
        Destroy(gameObject);
    }

    void DealDamage(float Schaden)
    {
        AktuelleLeben -= Schaden; //wird durch 2 geteilt da der Enemy doppelt so viel schaden bekommt wie er sollte
    }

    private void shooting()
    {
        Vector3 bosspos = rb.position; //gibt eigene Position als Vektor aus
       
        if ((Time.time > nextfireatk))
        {
            nextfireatk = Time.time + cdattack;
            GameObject newbullet = Instantiate(bullet) as GameObject; //Object wird von Prefab "geklont"
            newbullet.transform.position = new Vector3(bosspos.x, bosspos.y, bosspos.z); //neues Objekt wird beim Player gespawnt
        }
    }

    private void special()
    {
        Vector3 bosspos = rb.position; //gibt eigene Position als Vektor aus

        if ((Time.time > nextfireatk))
        {
            nextfireatk = Time.time + cdattack;
            GameObject newbullet = Instantiate(bul5) as GameObject;
            newbullet.transform.position = new Vector3(bosspos.x, bosspos.y, bosspos.z);
            GameObject newbullet1 = Instantiate(bul1) as GameObject;
            newbullet1.transform.position = new Vector3(bosspos.x, bosspos.y, bosspos.z);
            GameObject newbullet2 = Instantiate(bul2) as GameObject;
            newbullet2.transform.position = new Vector3(bosspos.x, bosspos.y, bosspos.z);
            GameObject newbullet3 = Instantiate(bul3) as GameObject;
            newbullet3.transform.position = new Vector3(bosspos.x, bosspos.y, bosspos.z);
            GameObject newbullet4 = Instantiate(bul4) as GameObject;
            newbullet4.transform.position = new Vector3(bosspos.x, bosspos.y, bosspos.z);
        }
    }

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

    private void attack()
    {
        int num = Random.Range(1, 11);

        if (num == 1)
        {
            special();
        }
        else
        {
            shooting();
        }
    }
}

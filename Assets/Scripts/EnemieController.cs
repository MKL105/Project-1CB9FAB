using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour {

    public GameObject player;
    public PlayerController playcon;
    private float speed;
    public Rigidbody2D rb;
    private float mH; //moveHorizontal Variable
    private float mV; //moveVertical Variable
    public float AktuelleLeben;
    [HideInInspector] public float MaxLeben;
    public GameObject ammodrop;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playcon = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
        MaxLeben = 3.0f;
        AktuelleLeben = MaxLeben;
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
        if (this.dropammo(10.0f) == true)
        {
            GameObject newammo = Instantiate(ammodrop) as GameObject;
            newammo.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Untersucht ob der Enemy eine Kugel berührt
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // falls ja
        {
            DealDamage(playcon.damage);// soll Schaden zugefügt werden 
        }
    }

    //berechnet Dropchance fuer Munition
    //gibt true zurück, wenn Munition gedroppt werden soll
    private bool dropammo(float dropchance) //in % -> 50.0 = 50%ige Chance
    {
        float drc = dropchance;
        float num = Random.Range(0.0f, 100.0f); //errechnet Zufallszahl zwischen 0 und 100

        if (num < drc) //Munition wird fallengelassen
        {
            return true;
        }
        else //Munition wird nicht fallengelassen
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbullet4 : MonoBehaviour {

    public Rigidbody2D bul;
    public float speed;
    public GameObject player;
    public GameObject boss;
    public Boss bosscon;
    public GameObject healthbar;
    public Health healthcon;
    public GameObject bullet;

    //wird bei der Initialisierung aufgerufen
    private void Start()
    {
        bul = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        bosscon = boss.GetComponent<Boss>();
        healthbar = GameObject.FindGameObjectWithTag("Health");
        healthcon = healthbar.GetComponent<Health>();
        speed = 10;
        this.shooting();
    }

    //bewegt die Kugel
    private void shooting()
    {
        Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y); //berechnet Vector2 von eigener Position
        Vector2 direction = playerpos - mypos; //berechnet Richtungsvektor
        direction.Normalize(); //gibt Vektor die Länge 1
        direction = Quaternion.Euler(0f, 0f, 315f) * direction;
        if (direction.x > 0)
        {
            float ang = (180f * Mathf.Atan(direction.y / direction.x)) / Mathf.PI;
            bullet.transform.Rotate(0f, 0f, ang);
        }
        else
        {
            float ang = (180f * Mathf.Atan(direction.y / direction.x)) / Mathf.PI;
            bullet.transform.Rotate(0f, 0f, (ang + 180f));
        }
        bul.velocity = direction * speed; //sorgt für Bewegung der Kugel
    }

    //sorgt dafuer dass die Kugel bei Beruehrung mit der Wand zerstoert wird
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                healthcon.DealDamage(bosscon.damage);
                Destroy(gameObject);
            }
        }
    }
}

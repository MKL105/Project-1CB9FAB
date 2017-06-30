using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject bullet;
    public Rigidbody2D bul;
    public float speed;

    //wird bei der Initialisierung aufgerufen
    private void Start()
    {
        bul = GetComponent<Rigidbody2D>();
        speed = 15;
        this.shooting();
    }

    //bewegt die Kugel
    private void shooting()
    {
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); //wandelt Mauszeigerposition in Weltkoordinaten um
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y); //berechnet Vector2 von eigener Position
        Vector2 direction = mouseInWorld - mypos; //berechnet Richtungsvektor
        direction.Normalize(); //gibt Vektor die Länge 1
        if (direction.x > 0)
        {
            float ang = (180f * Mathf.Atan(direction.y / direction.x)) / Mathf.PI;
            bullet.transform.Rotate(0f, 0f, ang);
        }
        else
        {
            float ang = (180f * Mathf.Atan(direction.y / direction.x)) / Mathf.PI;
            bullet.transform.Rotate(0f, 0f, (ang+180f));
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
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
            else
            {
                if (other.gameObject.CompareTag("Boss"))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

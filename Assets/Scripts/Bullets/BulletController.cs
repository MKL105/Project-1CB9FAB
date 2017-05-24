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
        speed = 10;
        this.shooting();
    }

    //bewegt die Kugel
    private void shooting()
    {
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); //wandelt Mauszeigerposition in Weltkoordinaten um
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y); //berechnet Vector2 von eigener Position
        Vector2 direction = mouseInWorld - mypos; //berechnet Richtungsvektor
        direction.Normalize(); //gibt Vektor die Länge 1
        bul.velocity = direction * speed; //sorgt für Bewegung der Kugel
	}

    //sorgt dafuer dass die Kugel bei Beruehrung mit der Wand zerstoert wird
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bul5controller : MonoBehaviour {

    public GameObject bullet5;
    public Rigidbody2D bul5;
    public float speed;

    //wird bei der Initialisierung aufgerufen
    private void Start()
    {
        bul5 = GetComponent<Rigidbody2D>();
        speed = 10;
        this.shooting();
    }

    //bewegt die Kugel
    private void shooting()
    {
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = mouseInWorld - mypos;
        direction.Normalize();
        direction = Quaternion.Euler(0, 0, 135) * direction; //dreht Bewegungsrichtung um 135°
        bul5.velocity = direction * speed;
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

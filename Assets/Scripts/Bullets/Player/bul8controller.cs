using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bul8controller : MonoBehaviour {

    public GameObject bullet8;
    public Rigidbody2D bul8;
    public float speed;

    //wird bei der Initialisierung aufgerufen
    private void Start()
    {
        bul8 = GetComponent<Rigidbody2D>();
        speed = 15;
        this.shooting();
    }

    //bewegt die Kugel
    private void shooting()
    {
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = mouseInWorld - mypos;
        direction.Normalize();
        if (direction.x > 0)
        {
            float ang = (180f * Mathf.Atan(direction.y / direction.x)) / Mathf.PI;
            bullet8.transform.Rotate(0f, 0f, ang);
        }
        else
        {
            float ang = (180f * Mathf.Atan(direction.y / direction.x)) / Mathf.PI;
            bullet8.transform.Rotate(0f, 0f, (ang + 180f));
        }
        bul8.velocity = direction * speed;
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

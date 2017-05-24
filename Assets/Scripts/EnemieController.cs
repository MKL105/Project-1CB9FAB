using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour {

    public GameObject player;
    private float speed;
    public Rigidbody2D rb;
    private float mH; //moveHorizontal Variable
    private float mV; //moveVertical Variable
    [HideInInspector] public float AktuelleLeben;
    [HideInInspector] public float MaxLeben;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
        MaxLeben = 50f;
        AktuelleLeben = MaxLeben;
    }

    private void Update()
    {
        Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);//berechnet player Poistion
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y); //berechnet Vector2 von eigener Position
        Vector2 direction = playerpos - mypos; //berechnet Richtungsvektor
        direction.Normalize(); //gibt Vektor die Länge 1
        rb.velocity = direction * speed; //sorgt für Bewegung des Enemy
    }

    void DealDamage(float Schaden) // Reduziert verbleibende Leben
    {
        AktuelleLeben -= Schaden;
        if (AktuelleLeben <= 0) // Überprüft ob Leben vorhanden ist
            Die(); // falls nein wird Die() ausgeführt
    }

    float Lebenerrechnen()
    {
        return AktuelleLeben / MaxLeben;
    }

    void Die() //Printet in der Console das kein Leben mehr vorhanden ist soll später den Enemy zerstören
    {
        AktuelleLeben = 0;
        Destroy(gameObject);
        Debug.Log("Enemy Dead");

    }

    void OnTriggerEnter2D(Collider2D collision) //Untersucht ob der Enemy eine Kugel berührt
    {
        if (collision.gameObject.CompareTag("Bullet")) // falls ja
        {
            DealDamage(50f);// soll Schaden zugefügt werden 
        }
    }
}

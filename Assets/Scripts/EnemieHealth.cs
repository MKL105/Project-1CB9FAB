using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour
{

    public float AktuelleLeben;
    public float MaxLeben;

    private void Start() // setzt zum Beginn die Aktuellen Leben auf Max
    {
        MaxLeben = 50f;
        AktuelleLeben = MaxLeben;
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

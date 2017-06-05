using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float AktuelleLeben;
    public float MaxLeben;
    private bool beruehrt = false; // variable welche angibt ob man einen Gegner berührt
    public Slider Healthbar; // Ist für Optische Anzeige zuständig
    //private bool Lebendig = true;

    private void Start() // setzt zum Beginn die Aktuellen Leben auf Max
    {
        MaxLeben = 100f;
        AktuelleLeben = MaxLeben;

        Healthbar.value = Lebenerrechnen(); //Errechnet wert der Healthbar
    }

    void DealDamage(float Schaden) // Reduziert verbleibende Leben
    {
        AktuelleLeben -= Schaden;
        Healthbar.value = Lebenerrechnen();
        if (AktuelleLeben <= 0) // Überprüft ob Leben vorhanden ist
            Die(); // falls nein wird Die() ausgeführt
    }

    float Lebenerrechnen() // Errechnet prozentualen Anteil der Aktuellen Leben
    {
        return AktuelleLeben / MaxLeben;
    }

    void Die() //Printet in der Console das kein Leben mehr vorhanden ist soll später den Spieler zerstören und das Spiel beenden
    {
        Debug.Log("Game Over");
        AktuelleLeben = 0;
    }




    void OnTriggerEnter2D(Collider2D collision) //Untersucht ob der Spieler einen Gegner berührt
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            DealDamage(30f);
        }
    }
}

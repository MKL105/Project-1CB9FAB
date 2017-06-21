using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int AktuelleLeben;
    public int MaxLeben;
    public Slider Healthbar; // Ist für Optische Anzeige zuständig

    private void Start() // setzt zum Beginn die Aktuellen Leben auf Max
    {
        MaxLeben = 100;
        AktuelleLeben = MaxLeben;
        Healthbar.value = Lebenerrechnen(); //Errechnet wert der Healthbar
    }

    public void DealDamage(int Schaden) // Reduziert verbleibende Leben
    {
        AktuelleLeben -= Schaden;
        Healthbar.value = Lebenerrechnen();
        if (AktuelleLeben <= 0) // Überprüft ob Leben vorhanden ist
            Die(); // falls nein wird Die() ausgeführt
    }

    float Lebenerrechnen() // Errechnet prozentualen Anteil der Aktuellen Leben
    {
        Debug.Log(AktuelleLeben / MaxLeben);
        return AktuelleLeben / MaxLeben;
    }

    void Die() //Printet in der Console das kein Leben mehr vorhanden ist soll später den Spieler zerstören und das Spiel beenden
    {
        Debug.Log("Game Over");
        AktuelleLeben = 0;
    }
}

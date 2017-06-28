using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    public float AktuelleLeben;
    public float MaxLeben;
    public Slider Healthbar; // Ist für Optische Anzeige zuständig

    private void Start() // setzt zum Beginn die Aktuellen Leben auf Max
    {
        MaxLeben = 100.0f;
        AktuelleLeben = MaxLeben;
        setvalue(); //Errechnet wert der Healthbar
    }

    public void DealDamage(float Schaden) // Reduziert verbleibende Leben
    {
        AktuelleLeben -= Schaden;
        setvalue();
        if (AktuelleLeben <= 0.0f) // Überprüft ob Leben vorhanden ist
            Die(); // falls nein wird Die() ausgeführt
    }

    float Lebenerrechnen() // Errechnet prozentualen Anteil der Aktuellen Leben
    {
        return AktuelleLeben / MaxLeben;
    }

    void Die() //Printet in der Console das kein Leben mehr vorhanden ist soll später den Spieler zerstören und das Spiel beenden
    {
        AktuelleLeben = 0;
        SceneManager.LoadScene(2);
    }

    public void setvalue()
    {
        Healthbar.value = Lebenerrechnen();
    }
}

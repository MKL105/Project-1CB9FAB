using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float AktuelleLeben;
    public float MaxLeben;
    public Slider Healthbar; // Ist für Optische Anzeige zuständig
    public GameObject allesandere;
    public GameObject deathmenu;
    public GameObject area;
    public GameController gamecon;
    public Text deathtext;

    private void Start() // setzt zum Beginn die Aktuellen Leben auf Max
    {
        MaxLeben = 100.0f;
        AktuelleLeben = MaxLeben;
        setvalue(); //Errechnet wert der Healthbar
        deathmenu.gameObject.SetActive(false);
        gamecon = area.GetComponent<GameController>();
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
        Time.timeScale = 0;
        gamecon.stopmusic();
        deathtext.text = "You survived " + (gamecon.wave - 1).ToString() + " waves";
        deathmenu.gameObject.SetActive(true);
        allesandere.gameObject.SetActive(false);
    }

    public void setvalue()
    {
        Healthbar.value = Lebenerrechnen();
    }
}

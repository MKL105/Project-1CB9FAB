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

    private void Update()
    {
        if (beruehrt)//Wenn eine Berührung vorliegt erleidet der Spieler Schaden
        {
            DealDamage(30f);
        }
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
        AktuelleLeben = 0;
        Debug.Log("Get Rekt");
        //Lebendig = false;
    }




    void OnTriggerEnter2D(Collider2D collision) //Untersucht ob der Spieler einen Gegner berührt
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //beruehrt = true;// setzt bei berührung beruehrt auf true
            // wait();
            //beruehrt = false;
            DealDamage(30f);
            //StartCoroutine(wait());
            //DealDamage(30f);

        }
    }

    //IEnumerator wait()
    //{
        //yield return new WaitForSeconds(10f);
   // }


    // private void OnTriggerExit(Collider other) // Versuch zu verhindern das der Spieler Schaden bekommt nachdem er den Gegner nicht mehr berührt
    //  {
    //   if (other.gameObject.CompareTag("Enemy"))
    // {
    // beruehrt = false;
    // }
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{

    public float AktuelleMana;
    public float MaxMana;
    public Slider Manabar; // Ist für Optische Anzeige zuständig

    private void Start() // setzt zum Beginn die Aktuellen Mana auf Max 
    {
        MaxMana = 100f;
        AktuelleMana = MaxMana;

        Manabar.value = ManaErrechnen(); //Errechnet wert der Manabar
    }

    private void Update()
    {

    }

    public void DealManaDamage(float ManaSchaden) // Reduziert verbleibende Mana
    {
        AktuelleMana -= ManaSchaden;
        Manabar.value = ManaErrechnen();
        if (AktuelleMana <= 0) // Überprüft ob Mana vorhanden ist
            NoSpell(); // falls nein wird noSpell() ausgeführt
    }

    float ManaErrechnen() // Errechnet prozentualen Anteil der Aktuellen Mana
    {
        return AktuelleMana / MaxMana;
    }

    void NoSpell() //Printet in der Console das kein Mana mehr vorhanden ist soll später das wirken von Spells verhindern
    {
        AktuelleMana = 0;
        Debug.Log("No Mana left");
    }
}

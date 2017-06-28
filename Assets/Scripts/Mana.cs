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
        MaxMana = 100.0f;
        AktuelleMana = MaxMana;
        setvalue(); //Errechnet wert der Manabar
    }

    public void DealManaDamage(float ManaSchaden) // Reduziert verbleibende Mana
    {
        AktuelleMana -= ManaSchaden;
        setvalue();
        if (AktuelleMana <= 0.0f) // Überprüft ob Mana vorhanden ist
            NoSpell(); // falls nein wird noSpell() ausgeführt
    }

    float ManaErrechnen() // Errechnet prozentualen Anteil der Aktuellen Mana
    {
        return AktuelleMana / MaxMana;
    }

    void NoSpell() //Printet in der Console das kein Mana mehr vorhanden ist soll später das wirken von Spells verhindern
    {
        AktuelleMana = 0;
    }

    public void setvalue()
    {
        Manabar.value = ManaErrechnen();
    }
}

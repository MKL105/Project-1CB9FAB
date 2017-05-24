using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultishotCDcon : MonoBehaviour{ //steuert die Animation für den Multishot

    public GameObject player;
    private Vector3 offset;
    public Animator anim; //Animator für die Animation des Cooldownsymbols
    private bool active;
    public PlayerController playcon; //Referenz auf das PlayerController Skript

    //wird beim Initialisieren aufgerufen
    void Start()
    {
        offset = transform.position - player.transform.position;
        anim = GetComponent<Animator>();
        playcon = player.GetComponent<PlayerController>();
    }

    //wird vor jedem Frame aufgerufen
    private void Update()
    {
        if (playcon.multishot == true)
        {
            anim.SetBool("Active", true); //Aktiviert Skill-Animation
        }
        else
        {
            anim.SetBool("Active", false); //deaktiviert Skill-Animation
        }
    }

    //sorgt dafuer dass sich sich der Multishot-Skill mit dem Spieler mitbewegt
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

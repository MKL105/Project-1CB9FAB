using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCDcon : MonoBehaviour{ //steuert die Animation für den Teleport

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
        if (playcon.tp == true)
        {
            anim.SetBool("tpakt", true); //Aktiviert Skill-Animation
        }
        else
        {
            anim.SetBool("tpakt", false); //deaktiviert Skill-Animation
        }
    }

    //sorgt dafuer dass sich sich der Teleport-Skill mit dem Spieler mitbewegt
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

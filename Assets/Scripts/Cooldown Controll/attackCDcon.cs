using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCDcon : MonoBehaviour { //steuert die Animation für die Standardattacke

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
        if (playcon.attack == true)
        {
            anim.SetBool("atk", true); //Aktiviert Skill-Animation
        }
        else
        {
            anim.SetBool("atk", false); //deaktiviert Skill-Animation
        }
    }

    //sorgt dafuer dass sich sich der Attack-Skill mit dem Spieler mitbewegt
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

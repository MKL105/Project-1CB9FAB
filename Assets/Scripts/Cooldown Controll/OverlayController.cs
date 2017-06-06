using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayController : MonoBehaviour { //steuert das Overlay fuer das Spiel

    public GameObject player; //Spieler
    [HideInInspector] public PlayerController playcon; //PlayerController Skript

    public GameObject atkcd; //Attacken-Cooldownsymbol
    private Vector3 offsetatk; //Abstandsvektor
    [HideInInspector]  public Animator animatk; //Animator für die Animation des Cooldownsymbols

    public GameObject mscd; //Multishot-Cooldownsymbol
    private Vector3 offsetms; //Abstandsvektor
    [HideInInspector] public Animator animms; //Animator für die Animation des Cooldownsymbols

    public GameObject tpcd; //Teleport-Cooldownsymbol
    private Vector3 offsettp; //Abstandsvektor
    [HideInInspector] public Animator animtp; //Animator für die Animation des Cooldownsymbols

    public GameObject ammobullet; //Munitionssymbol
    private Vector3 offsetammo; //Abstandsvektor
    [HideInInspector] public Animator animammo; //Animator für die Animation der Munition

    public GameObject overlay; //Overlay
    private Vector3 offsetoverlay; //Abstandsvektor

    [HideInInspector] public GameController gamecon; //Gamecontroller Skript
    public GameObject area; //Arena
    private int ammo;
    public Text ammotext;
    private int wave;
    public Text wavetext;
    private int enemleft;
    public Text enemlefttext;

   

    //wird beim Initialisieren aufgerufen
    void Start()
    {
        playcon = player.GetComponent<PlayerController>();
        gamecon = area.GetComponent<GameController>();

        offsetatk = atkcd.transform.position - player.transform.position;
        animatk = atkcd.GetComponent<Animator>();

        offsetms = mscd.transform.position - player.transform.position;
        animms = mscd.GetComponent<Animator>();

        offsettp = tpcd.transform.position - player.transform.position;
        animtp = tpcd.GetComponent<Animator>();

        offsetoverlay = overlay.transform.position - player.transform.position;

        offsetammo = ammobullet.transform.position - player.transform.position;
        animammo = ammobullet.GetComponent<Animator>();

        ammo = gamecon.ammo;
        wave = gamecon.wave;
        enemleft = gamecon.enemleft;

        this.settexts();
    }

    //wird vor jedem Frame aufgerufen
    private void Update()
    {
        this.setcooldowns();
        this.setammo();
        this.settexts();
    }

    //sorgt dafuer dass sich sich die Symbole mit dem Spieler mitbewegen
    void LateUpdate()
    {
        atkcd.transform.position = player.transform.position + offsetatk;
        mscd.transform.position = player.transform.position + offsetms;
        tpcd.transform.position = player.transform.position + offsettp;
        ammobullet.transform.position = player.transform.position + offsetammo;
        overlay.transform.position = player.transform.position + offsetoverlay;
    }

    //Steuert die Animator fuer die Cooldowns
    private void setcooldowns()
    {
        if (playcon.attack == true)
        {
            animatk.SetBool("atk", true); //Aktiviert Skill-Animation
            if (playcon.multishot == true)
            {
                animms.SetBool("Active", true); //Aktiviert Skill-Animation
                if (playcon.tp == true)
                {
                    animtp.SetBool("tpakt", true); //Aktiviert Skill-Animation
                }
                else
                {
                    animtp.SetBool("tpakt", false); //deaktiviert Skill-Animation
                }
            }
            else
            {
                animms.SetBool("Active", false); //deaktiviert Skill-Animation
                if (playcon.tp == true)
                {
                    animtp.SetBool("tpakt", true); //Aktiviert Skill-Animation
                }
                else
                {
                    animtp.SetBool("tpakt", false); //deaktiviert Skill-Animation
                }
            }
        }
        else
        {
            animatk.SetBool("atk", false); //deaktiviert Skill-Animation
            if (playcon.multishot == true)
            {
                animms.SetBool("Active", true); //Aktiviert Skill-Animation
                if (playcon.tp == true)
                {
                    animtp.SetBool("tpakt", true); //Aktiviert Skill-Animation
                }
                else
                {
                    animtp.SetBool("tpakt", false); //deaktiviert Skill-Animation
                }
            }
            else
            {
                animms.SetBool("Active", false); //deaktiviert Skill-Animation
                if (playcon.tp == true)
                {
                    animtp.SetBool("tpakt", true); //Aktiviert Skill-Animation
                }
                else
                {
                    animtp.SetBool("tpakt", false); //deaktiviert Skill-Animation
                }
            }
           
        }
    }

    //Steuert den Animator fuer die Munition
    private void setammo()
    {
        if(gamecon.bulletammo == true)
        {
            animammo.SetBool("ammo", true);
            this.settexts();
        }
        else
        {
            animammo.SetBool("ammo", false);
            this.settexts();
        }
    }

    //Setzt den Minutionscount und Wavecount
    private void settexts()
    {
        ammo = gamecon.ammo;
        ammotext.text = ammo.ToString() + "x";
        wave = gamecon.wave;
        wavetext.text = "Wave: " + wave.ToString();
        enemleft = gamecon.enemleft;
        enemlefttext.text = "Enemies left: " + enemleft.ToString();
    }
}

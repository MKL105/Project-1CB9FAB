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

    public GameObject coin;
    private Vector3 offsetcoin;

    [HideInInspector] public GameController gamecon; //Gamecontroller Skript
    public GameObject area; //Arena
    private int ammo;
    public Text ammotext;
    private int ammocost;
    public Text ammocosttext;
    private int wave;
    public Text wavetext;
    private int enemleft;
    public Text enemlefttext;
    private int money;
    public Text moneytext;
    private float damage;
    public Text damagetext;
    private int damagecost;
    public Text damagecosttext;
    private int manacost;
    public Text manacosttext;
    private int lifecost;
    public Text lifecosttext;
    private int mscost;
    public Text msunlock;
    private int tpcost;
    public Text tpunlock;
    private int ammoupgradecost;
    public Text ammoupgradetext;
    private int mscdrcost;
    private int mscdr;
    public Text mscdrtext;
    private int tpcdrcost;
    private int tpcdr;
    public Text tpcdrtext;
    private int tpmanared;
    private int tpmanaredcost;
    public Text tpmanaredtext;
    private int msmanared;
    private int msmanaredcost;
    public Text msmanaredtext;
    private int tprangecosts;
    private int tprangeup;
    public Text tprangetext;
    private int speedupcost;
    private int spup;
    public Text speeduptext;


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

        offsetcoin = coin.transform.position - player.transform.position;

        ammo = gamecon.ammo;
        ammocost = gamecon.ammocost;
        wave = gamecon.wave;
        enemleft = gamecon.enemleft;
        money = gamecon.money;
        damage = gamecon.damage;
        damagecost = gamecon.damagecost;
        mscost = gamecon.mscost;
        tpcost = gamecon.tpcost;
        manacost = gamecon.manacost;
        lifecost = gamecon.lifecost;
        ammoupgradecost = gamecon.ammoupgradecost;
        mscdrcost = gamecon.mscdrcost;
        mscdr = gamecon.mscdr;
        tpcdrcost = gamecon.tpcdrcost;
        tpcdr = gamecon.tpcdr;
        tpmanared = gamecon.tpmanared;
        tpmanaredcost = gamecon.tpmanareducecosts;
        msmanaredcost = gamecon.msmanareducecosts;
        msmanared = gamecon.msmanared;
        tprangecosts = gamecon.tprangecosts;
        tprangeup = gamecon.tprangeup;
        speedupcost = gamecon.speedupcost;
        spup = gamecon.spup;

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
        coin.transform.position = player.transform.position + offsetcoin;
    }

    //Steuert die Animator fuer die Cooldowns
    private void setcooldowns()
    {
        if (playcon.attack == true)
        {
            animatk.SetBool("atk", true); //Aktiviert Skill-Animation
            if ((playcon.multishot == true) && (playcon.msunlock == true))
            {
                animms.SetBool("Active", true); //Aktiviert Skill-Animation
                if ((playcon.tp == true) && (playcon.tpunlock == true))
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
                if ((playcon.tp == true) && (playcon.tpunlock == true))
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
            if ((playcon.multishot == true) && (playcon.msunlock == true))
            {
                animms.SetBool("Active", true); //Aktiviert Skill-Animation
                if ((playcon.tp == true) && (playcon.tpunlock == true))
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
                if ((playcon.tp == true) && (playcon.tpunlock == true))
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
        money = gamecon.money;
        moneytext.text = money.ToString();
        damage = gamecon.damage;
        damagetext.text = "Damage: " + damage.ToString();
        damagecost = gamecon.damagecost;
        damagecosttext.text = "Cost: " + damagecost.ToString();
        ammocost = gamecon.ammocost;
        ammocosttext.text = "Ammo refill \n Cost: " + ammocost.ToString();
        manacost = gamecon.manacost;
        manacosttext.text = "Pieros Arznei \n Cost: " + manacost.ToString();
        lifecost = gamecon.lifecost;
        lifecosttext.text = "Sokolov's Elixir \n Cost: " + lifecost.ToString();
        ammoupgradecost = gamecon.ammoupgradecost;
        ammoupgradetext.text = "Cost: " + ammoupgradecost.ToString();
        mscdr = gamecon.mscdr;
        tpcdr = gamecon.tpcdr;
        tpmanared = gamecon.tpmanared;
        msmanared = gamecon.msmanared;
        tprangeup = gamecon.tprangeup;
        speedupcost = gamecon.speedupcost;
        spup = gamecon.spup;

        if (playcon.msunlock == true)
        {
            msunlock.text = "Unlocked";
        }
        else
        {
            mscost = gamecon.mscost;
            msunlock.text = "Cost: " + mscost.ToString();
        }

        if (playcon.tpunlock == true)
        {
            tpunlock.text = "Unlocked";
        }
        else
        {
            tpcost = gamecon.tpcost;
            tpunlock.text = "Cost: " + tpcost.ToString();
        }

        if (mscdr < 6)
        {
            mscdrcost = gamecon.mscdrcost;
            mscdrtext.text = "Cost: " + mscdrcost.ToString();
        }
        else
        {
            mscdrtext.text = "Max. Level";
        }

        if (tpcdr < 7)
        {
            tpcdrcost = gamecon.tpcdrcost;
            tpcdrtext.text = "Cost: " + tpcdrcost.ToString();
        }
        else
        {
            tpcdrtext.text = "Max. Level";
        }

        if (tpmanared < 7)
        {
            tpmanaredcost = gamecon.tpmanareducecosts;
            tpmanaredtext.text = "Cost: " + tpmanaredcost.ToString(); 
        }
        else
        {
            tpmanaredtext.text = "Max. Level";
        }

        if (msmanared < 6)
        {
            msmanaredcost = gamecon.msmanareducecosts;
            msmanaredtext.text = "Cost: " + msmanaredcost.ToString();
        }
        else
        {
            msmanaredtext.text = "Max. Level";
        }

        if (tprangeup < 6)
        {
            tprangecosts = gamecon.tprangecosts;
            tprangetext.text = "Cost: " + tprangecosts.ToString();
        }
        else
        {
            tprangetext.text = "Max. Level";
        }

        if (damage > 9999999999999f)
        {
            damagetext.text = "Instakill";
        }
        else
        {
            damage = gamecon.damage;
            damagetext.text = "Damage: " + damage.ToString();
        }

        if (spup < 4)
        {
            speedupcost = gamecon.speedupcost;
            speeduptext.text = "Cost: " + speedupcost.ToString();
        }
        else
        {
            speeduptext.text = "Max. Level";
        }
    }
}

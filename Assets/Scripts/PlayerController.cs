using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [HideInInspector] public float speed; //Geschwindigkeit des Spielers
    [HideInInspector] public Rigidbody2D rb; //Rigidbody2D des Spielers
    private float mH; //moveHorizontal Variable
    private float mV; //moveVertical Variable
    [HideInInspector] public Animator anim; //Animator, der fuer die Animationen des Spielers verantwortlich ist
    public GameObject bullet; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bullet1; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bullet2; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bullet3; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bullet4; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bullet5; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bullet6; //Kugel, die beim Schiessen erzeugt wird
    public GameObject bullet7; //Kugel, die beim Schiessen erzeugt wird
    [HideInInspector] public float cdmultishot; //Cooldownzeit fuer Multishot
    [HideInInspector] public float cdattack; //Cooldownzeit fuer Attacke
    [HideInInspector] public float cdteleport; //Cooldownzeit fuer Teleport
    [HideInInspector] public float nextfirems; //Zeit, wenn der Multishot wieder aufgeladen ist
    [HideInInspector] public float nextfireatk; //Zeit, wenn die Attacke wieder aufgeladen ist
    [HideInInspector] public float nextfiretp; //Zeit, wenn der Teleport wieder aufgeladen ist
    [HideInInspector] public bool multishot; //true wenn Multishot aufgeladen ist
    [HideInInspector] public bool attack; //true wenn Attacke aufgeladen ist
    [HideInInspector] public bool tp; //true wenn Teleport aufgeladen ist
    public GameObject area;
    [HideInInspector] public GameController gamecon;
    private bool ammo;
    public GameObject manabar;
    public Mana manacon;
    [HideInInspector] public float damage;

    //wird beim Initialisieren aufgerufen
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gamecon = area.GetComponent<GameController>();
        speed = 4;
        cdmultishot = 5.0f;
        cdattack = 0.1f;
        cdteleport = 60.0f;
        multishot = true;
        attack = true;
        tp = true;
        ammo = true;
        manacon = manabar.GetComponent<Mana>();
        damage = 1.0f;
    }

    //wird vor jedem Frame aufgerufen
    private void Update()
    {
        this.animate();
        this.shooting();
        this.multishotskill();
        this.teleport();
        this.cooldownms();
        this.cooldownatk();
        this.cooldowntp();
    }

    //wird vor allem was mit physics zu tun hat aufgerufen
    private void FixedUpdate()
    {
        this.moving();
    }

    //sorgt dafuer, dass die Spielfigur sich auf Tastendruck bewegt
    private void moving()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        mV = moveVertical;
        mH = moveHorizontal;
    }

    //laesst den Spieler in Richtung der Maus schauen
    private void animate()
    {
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); //wandelt Mauskoordinaten on Weltkoordinaten um
        float myx = rb.transform.position.x; //Spieler X-Position
        float myy = rb.transform.position.y; //Spieler Y-Position
        float mox = mouseInWorld.x; //Maus X-Position
        float moy = mouseInWorld.y; //Maus Y-Position
        float xdif = mox - myx; //X-Differenz von Maus und Spieler  //positiv wenn Maus rechts von Spieler
        float ydif = moy - myy; //Y-Differenz von Maus und Spieler  //positiv wenn Maus über von Spieler
        float rise = ydif/xdif; //Steigung von Spieler zu Maus

            if ((rise < 1) && (rise > 0))
            {
                if (xdif > 0) //rechts schauend
                {
                     if ((mV == 0) && (mH == 0))
                     {
                         anim.SetInteger("direction", 6);
                     }
                     else
                     {
                         anim.SetInteger("direction", 3);
                     }
                }
                else //links schauend
                {
                     if ((mV == 0) && (mH == 0))
                     {
                         anim.SetInteger("direction", 7);
                     }
                     else
                     {
                         anim.SetInteger("direction", 4);
                     }
                }
            }
            else
            {
                if ((rise > 1) && (rise > 0))
                {
                    if(ydif > 0) //hoch schauend
                    {
                        if ((mV == 0) && (mH == 0))
                        {
                            anim.SetInteger("direction", 5);
                        }
                        else
                        {
                        anim.SetInteger("direction", 1);
                        }
                    }
                    else //runter schauend
                    {
                        if ((mV == 0) && (mH == 0))
                        {
                            anim.SetInteger("direction", 0);
                        }
                        else
                        {
                            anim.SetInteger("direction", 2);
                        }
                    }
                }
                else
                {
                    if ((rise < 0) && (rise < -1))
                    {
                        if (xdif < 0) //hoch schauend
                        {
                            if ((mV == 0) && (mH == 0))
                            {
                                anim.SetInteger("direction", 5);
                            }
                            else
                            {
                                anim.SetInteger("direction", 1);
                            }
                        }
                        else //runter schauend
                        {
                            if ((mV == 0) && (mH == 0))
                                {
                                    anim.SetInteger("direction", 0);
                                }
                            else
                            {
                                anim.SetInteger("direction", 2);
                            }
                        }
                    }
                    else
                    {
                        if ((rise < 0) && (rise > -1))
                        {
                            if (ydif > 0) //links schauend
                            {
                                if ((mV == 0) && (mH == 0))
                                {
                                    anim.SetInteger("direction", 7);
                                }
                                else
                                {
                                    anim.SetInteger("direction", 4);
                                }
                            }
                            else //rechts schauend
                            {
                                if ((mV == 0) && (mH == 0))
                                {
                                    anim.SetInteger("direction", 6);
                                }
                                else
                                {
                                    anim.SetInteger("direction", 3);
                                }
                            }
                        }
                    }
                }

            }
    }

    //laesst den Spieler in Richtung der Maus schiessen
    //linke Maustaste
    //0.1s Cooldown
    private void shooting()
    {
        Vector3 playerpos = rb.position; //gibt eigene Position als Vektor aus
        if(gamecon.ammo > 0)
        {
            ammo = true;
        }
        else
        {
            ammo = false;
        }

        if (Input.GetMouseButtonDown(0) && (Time.time > nextfireatk) && (ammo == true)) //linke Maustaste gedrückt
        {
            nextfireatk = Time.time + cdattack; 
            GameObject newbullet = Instantiate(bullet) as GameObject; //Object wird von Prefab "geklont"
            newbullet.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z); //neues Objekt wird beim Player gespawnt
            gamecon.looseammo();
        }
    }

    //laesst den Spieler in alle Richtungen schiessen
    //rechte Maustaste
    //5s Cooldown
    private void multishotskill()
    {
        Vector3 playerpos = rb.position; //gibt eigene Position als Vektor aus

        if ((Input.GetMouseButtonDown(1)) && (Time.time > nextfirems)) //rechte Maustaste gedrückt + Skill aktiv
        {
            nextfirems = Time.time + cdmultishot;
            GameObject newbullet = Instantiate(bullet) as GameObject;
            newbullet.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            GameObject newbullet1 = Instantiate(bullet1) as GameObject;
            newbullet1.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            GameObject newbullet2 = Instantiate(bullet2) as GameObject;
            newbullet2.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            GameObject newbullet3 = Instantiate(bullet3) as GameObject;
            newbullet3.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            GameObject newbullet4 = Instantiate(bullet4) as GameObject;
            newbullet4.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            GameObject newbullet5 = Instantiate(bullet5) as GameObject;
            newbullet5.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            GameObject newbullet6 = Instantiate(bullet6) as GameObject;
            newbullet6.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            GameObject newbullet7 = Instantiate(bullet7) as GameObject;
            newbullet7.transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);
            manacon.DealManaDamage(10);
        }
    }

    //aktiviert Multishot Skill nach 5s
    public void cooldownms()
    {
        if (Time.time > nextfirems)
        {
            multishot = true;
        }
        else
        {
            multishot = false;
        }
    }

    //aktiviert Teleport Skill nach 1min
    public void cooldowntp()
    {
        if (Time.time > nextfiretp)
        {
            tp = true;
        }
        else
        {
            tp = false;
        }
    }

    //aktiviert Attacke nach 0.1s
    public void cooldownatk()
    {
        if (Time.time > nextfireatk)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }
    }

    //Teleportiert Spieler eine bestimmte Weite in Richtung Maus
    //Taste E
    //1min Cooldown

    //FEHLER: TELEPORTIEREN AUS SPIELWELT MOEGLICH  
    private void teleport()
    {
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mypos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = mouseInWorld - mypos;
        direction.Normalize();
        direction = direction * 5;
        float tox = transform.position.x + direction.x;
        float toy = transform.position.y + direction.y;
        float toz = transform.position.z;

        if ((Input.GetKeyDown(KeyCode.E)) && (Time.time > nextfiretp))
        {
            nextfiretp = Time.time + cdteleport;
            rb.transform.position = new Vector3(tox, toy, toz);
            manacon.DealManaDamage(25);
        }
    }
}
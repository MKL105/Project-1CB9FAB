using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [HideInInspector] public float speed;
    private Rigidbody2D rb;
    private float mH; //moveHorizontal Variable
    private float mV; //moveVertical Variable
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        this.animate();
    }

    //wird vor allem was mit physics zu tun hat aufgerufen
    private void FixedUpdate()
    {
        this.moving();
    }

    //sorgt dafuer, dass die Spielfigur sich auf Tastendruck bewegt
    private void moving()
    {
        speed = 4;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        mV = moveVertical;
        mH = moveHorizontal;
    }

    //weist der Bewegung die Animation zu
    private void animate()
    {
        if ((mV > 0) && (mH == 0)) //Bewegung nur nach oben
        {
            anim.SetInteger("direction", 1);
        }
        else
        {
            if ((mV < 0) && (mH == 0)) //Bewegung nur nach unten
            {
                anim.SetInteger("direction", 2);
            }
            else
            {
                if ((mV == 0) && (mH > 0)) //Bewegung nur nach rechts
                {
                    anim.SetInteger("direction", 3);
                }
                else
                {
                    if ((mV == 0) && (mH < 0)) //Bewegung nur nach links
                    {
                        anim.SetInteger("direction", 4);
                    }
                    else
                    {
                        if ((mV > 0) && (mH > 0)) //Bewegung nach rechts oben
                        {
                            anim.SetInteger("direction", 3);
                        }
                        else
                        {
                            if ((mV > 0) && (mH < 0)) //Bewegung nach links oben
                            {
                                anim.SetInteger("direction", 4);
                            }
                            else
                            {
                                if ((mV < 0) && (mH > 0)) //Bewegung nach rechts unten
                                {
                                    anim.SetInteger("direction", 3);
                                }
                                else
                                {
                                    if ((mV < 0) && (mH < 0)) //Bewegung nach links unten
                                    {
                                        anim.SetInteger("direction", 4);
                                    }
                                    else //Figur steht still
                                    {
                                        anim.SetInteger("direction", 0);
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}


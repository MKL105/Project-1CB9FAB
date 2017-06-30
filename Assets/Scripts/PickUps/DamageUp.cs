using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{

    public GameObject Player;
    public PlayerController playercon;
    public float DauerDamageUp;
    private bool inuse = false;
    private SpriteRenderer Sr;
    private float aktuellerschaden;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playercon = Player.GetComponent<PlayerController>();
        DauerDamageUp = 10f;
        Sr = GetComponent<SpriteRenderer>();
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Color uns = Sr.color;
            uns.a = 0;
            Sr.color = uns;
            if (inuse == false)
            {

                StartCoroutine(memes());

            }
        }
    }

    IEnumerator memes()
    {
        inuse = true;
        playercon.damage += 3.5f;
        yield return new WaitForSeconds(DauerDamageUp);
        playercon.damage -= 3.5f;
        Destroy(gameObject);
        inuse = false;
    }
}

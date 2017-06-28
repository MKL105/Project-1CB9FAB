using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{

    private GameController gamecon;
    public GameObject area;
    public GameObject Player;
    public PlayerController playercon;
    public float DauerDamageUp;
    private bool inuse = false;
    private SpriteRenderer Sr;
    private float aktuellerschaden;
    void Start()
    {
        gamecon = area.GetComponent<GameController>();
        playercon = Player.GetComponent<PlayerController>();
        DauerDamageUp = 10f;
        Sr = GetComponent<SpriteRenderer>();
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            aktuellerschaden = playercon.damage;
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
        playercon.damage = playercon.damage + 3.5f;

        yield return new WaitForSeconds(DauerDamageUp);
        playercon.damage = aktuellerschaden;
        Destroy(gameObject);
        inuse = false;
    }
}

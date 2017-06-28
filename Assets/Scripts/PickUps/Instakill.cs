using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instakill : MonoBehaviour
{

    private GameController gamecon;
    public GameObject area;
    public GameObject Player;
    public PlayerController playercon;
    public float DauerInstakill;
    private bool inuse = false;
    private SpriteRenderer Sr;
    private float aktuellerschaden;
    void Start()
    {
        gamecon = area.GetComponent<GameController>();
        playercon = Player.GetComponent<PlayerController>();
        DauerInstakill = 10f;
        Sr = GetComponent<SpriteRenderer>();
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            aktuellerschaden = playercon.erhoehterdamage;
            Color uns = Sr.color;
            uns.a = 0;
            Sr.color = uns;
            if (inuse == false)
            {

                StartCoroutine(inst());

            }
        }
    }

    IEnumerator inst()
    {
        inuse = true;
        playercon.erhoehterdamage = playercon.erhoehterdamage + 9999999999999999f;

        yield return new WaitForSeconds(DauerInstakill);
        playercon.erhoehterdamage = aktuellerschaden;
        Destroy(gameObject);
        inuse = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instakill : MonoBehaviour
{

    public GameObject Player;
    public PlayerController playercon;
    public GameObject area;
    public GameController gamecon;
    public float DauerInstakill;
    private bool inuse = false;
    private SpriteRenderer Sr;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        area = GameObject.FindGameObjectWithTag("Wall");
        gamecon = area.GetComponent<GameController>();
        playercon = Player.GetComponent<PlayerController>();
        Sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if ((inuse == true) && (gamecon.wave == 10))
        {
            playercon.damage -= 999999f;
        }
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
                StartCoroutine(inst());
            }
        }
    }

    IEnumerator inst()
    {
        inuse = true;
        playercon.damage += 999999f;
        yield return new WaitForSeconds(10);
        playercon.damage -= 999999f;
        Destroy(gameObject);
        inuse = false;
    }
}

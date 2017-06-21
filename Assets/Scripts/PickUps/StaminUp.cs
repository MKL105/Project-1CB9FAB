using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminUp : MonoBehaviour {

    private GameController gamecon;
    public GameObject area;
    public GameObject Player;
    public PlayerController playercon;
    public float DauerStaminUp;
    private bool inuse = false;
    private SpriteRenderer Sa;

    void Start () {
        gamecon = area.GetComponent<GameController>();
        playercon = Player.GetComponent<PlayerController>();
        DauerStaminUp = 5.0f;
        Sa = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Color uns = Sa.color;
            uns.a = 0;
            Sa.color = uns;
            if (  inuse == false)
           {
               
                StartCoroutine(memes());
                
            }
        }
    }

    IEnumerator memes()
    {
        inuse = true;
        playercon.speed = playercon.speed + 10;

        yield return new WaitForSeconds(5);
        playercon.speed = 4;
        Destroy(gameObject);
        inuse = false;
    }
}

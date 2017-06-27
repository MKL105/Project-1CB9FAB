using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminUp : MonoBehaviour {

    public GameObject player;
    public PlayerController playcon;
    public float DauerStaminUp;
    private bool inuse = false;
    private SpriteRenderer Sa;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playcon = player.GetComponent<PlayerController>();
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
            if (inuse == false)
            {
                StartCoroutine(memes());
            }
        }
    }

    IEnumerator memes()
    {
        inuse = true;
        playcon.speed = playcon.speed + 10;
        yield return new WaitForSeconds(5);
        playcon.speed = 4;
        Destroy(gameObject);
        inuse = false;
    }
}

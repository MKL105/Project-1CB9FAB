using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instakill : MonoBehaviour
{

    public GameObject Player;
    public PlayerController playercon;
    public float DauerInstakill;
    private bool inuse = false;
    private SpriteRenderer Sr;
    private float aktuellerschaden;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playercon = Player.GetComponent<PlayerController>();
        DauerInstakill = 10f;
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
                StartCoroutine(inst());
            }
        }
    }

    IEnumerator inst()
    {
        inuse = true;
        playercon.damage += 9999999999999999f;
        Debug.Log("testtest");
        yield return new WaitForSeconds(DauerInstakill);
        playercon.damage = aktuellerschaden;
        Destroy(gameObject);
        inuse = false;
    }
}

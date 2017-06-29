using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmo : MonoBehaviour {

    public GameController gamecon;
    public GameObject area;

    void Start()
    {
        area = GameObject.FindGameObjectWithTag("Wall");
        gamecon = area.GetComponent<GameController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                gamecon.ammo = gamecon.maxammo;
                Destroy(gameObject);
        }
    }
}

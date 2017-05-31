using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmoCon : MonoBehaviour {

    public GameController gamecon;
    public GameObject area;

	void Start ()
    {
        gamecon = area.GetComponent<GameController>();
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gamecon.ammo = gamecon.ammo + 50;
            Destroy(gameObject);
        }
    }
}

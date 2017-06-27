using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillmenu : MonoBehaviour {

    private bool ispaused;
    public GameObject skillmenu;
    public GameObject pausemenu;
    public GameObject skills;
    public GameObject shop;

	void Start ()
    {
        ispaused = false;
        skillmenu.gameObject.SetActive(false);
	}
	
	void Update ()
    {
        if ((Input.GetKeyDown(KeyCode.P)))
        {
            ispaused = !ispaused;
            if (ispaused == true)
            {
                pauseon();
            }
            else
            {
                pauseoff();
            }
        }
        if (ispaused == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                tomenu();
            }
        }
	}

    private void pauseon()
    {
        
        Time.timeScale = 0; //pausiert des Spiel
        skillmenu.gameObject.SetActive(true);
        pausemenu.gameObject.SetActive(true);
        skills.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
    }

    private void pauseoff()
    {
        Time.timeScale = 1; //setzt Spiel fort
        skillmenu.gameObject.SetActive(false);
    }

    public void toskills()
    {
        pausemenu.gameObject.SetActive(false);
        skills.gameObject.SetActive(true);
    }

    public void toshop()
    {
        pausemenu.gameObject.SetActive(false);
        shop.gameObject.SetActive(true);
    }

    public void tomenu()
    {
        pausemenu.gameObject.SetActive(true);
        skills.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
    }
}

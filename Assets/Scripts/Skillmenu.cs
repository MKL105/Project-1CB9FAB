using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillmenu : MonoBehaviour {

    private bool ispaused;
    public GameObject skillmenu;

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
            if (ispaused)
            {
                pauseon();
            }
            else
            {
                pauseoff();
            }
        }
	}

    private void pauseon()
    {
        
        Time.timeScale = 0; //pausiert des Spiel
        skillmenu.gameObject.SetActive(true);
    }

    private void pauseoff()
    {
        Time.timeScale = 1; //setzt Spiel fort
        skillmenu.gameObject.SetActive(false);
    }

}

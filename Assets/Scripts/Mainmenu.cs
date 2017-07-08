using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour {

    public GameObject play;
    public GameObject end;
    public GameObject credits;
    public GameObject credit;
    public Text credittext;

    private void Start()
    {
        play.gameObject.SetActive(true);
        end.gameObject.SetActive(true);
        credits.gameObject.SetActive(true);
        credit.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void creditscall()
    {
        play.gameObject.SetActive(false);
        end.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        credit.gameObject.SetActive(true);
    }
}

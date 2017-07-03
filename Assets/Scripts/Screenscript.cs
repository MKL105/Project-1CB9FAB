using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screenscript : MonoBehaviour {

	void Start ()
    {
        StartCoroutine(wait());
	}

    IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start() //wird beim Initialisieren aufgerufen
    {
        offset = transform.position - player.transform.position; //berechnet Abstand von Kamera zum Spieler
    }

    void LateUpdate() //wird fuer Kamerabewegung genutzt
    {
        transform.position = player.transform.position + offset; //bewegt die Kamera mit dem Spieler mit
    }
}

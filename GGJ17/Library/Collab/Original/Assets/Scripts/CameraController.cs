using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    PlayerController thePlayer;
	// Use this for initialization
	void Start () {
		if(thePlayer == null)
        {
            thePlayer = GameObject.FindObjectOfType<PlayerController>();
        }
      //  transform.Rotate()
	}
	
	// Update is called once per frame
	void Update () {
		if(thePlayer)
        {
            transform.position = thePlayer.transform.position - new Vector3(0, -1, 10);
        }
	}
}

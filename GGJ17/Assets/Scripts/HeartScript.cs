using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour {
    Canvas myCanvas;
	// Use this for initialization
	void Start () {
        if(transform.parent.GetComponent<Canvas>())
        {
            myCanvas = transform.parent.GetComponent<Canvas>();
        }

        if(myCanvas)
        {
            myCanvas.renderMode = RenderMode.ScreenSpaceCamera;
           // myCanvas.
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

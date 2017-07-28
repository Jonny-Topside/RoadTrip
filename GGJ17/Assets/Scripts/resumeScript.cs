using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeScript : MonoBehaviour {
    
    EventManager manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindObjectOfType<EventManager>();
	}
    
    public void onClick()
    {
        manager.resume();
    }
}

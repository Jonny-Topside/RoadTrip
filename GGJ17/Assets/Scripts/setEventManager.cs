using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setEventManager : MonoBehaviour {
    EventManager eve;
    Button[] options;
    Button resume;
    Button quit;
	// Use this for initialization
	void Start () {
        //FIND EVENTMANAGER 
        eve = FindObjectOfType<EventManager>();
        //attach script to buttons
        options = FindObjectsOfType<Button>();
        options[0] = resume;
        options[1] = quit;
        options[0].GetComponent<EventManager>().resume();
        options[1].GetComponent<EventManager>().pauseQuit();
       // options[].GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setter()
    {
        
    }
}

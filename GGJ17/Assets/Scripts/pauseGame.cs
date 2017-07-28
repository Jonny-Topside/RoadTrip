using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseGame : MonoBehaviour {
    public EventManager manager;

    void Start()
    {
        manager = GameObject.FindObjectOfType<EventManager>();
    }

    void pause()
    {
        manager.pause();    
    }
}

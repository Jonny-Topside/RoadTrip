using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour {
   // Canvas canvas;
    float resumeTimer;
    bool isPaused;
   public Canvas _canvas;
    gameOver gameOverCanvas;
    PlayerController player;
    // Use this for initialization
    void Start () {
        resumeTimer = 0.0f;
       // canvas = GetComponent<Canvas>();
       

        isPaused = false;
        _canvas   = GameObject.FindObjectOfType<Canvas>();
        _canvas.GetComponent<Canvas>().enabled = false;
        player = GameObject.FindObjectOfType<PlayerController>();
       
        gameOverCanvas = GameObject.FindObjectOfType<gameOver>();
        if(gameOverCanvas)
        {
        gameOverCanvas.GetComponent<Canvas>().enabled = false;

        }
    }

    // Update is called once per frame
    void Update () {
        gameOver();
        pause();
    }

    public void resume()
    {
        _canvas.enabled = false;
        Time.timeScale = 1.0f;
        if (Input.GetKeyDown(KeyCode.Escape))
            {
            Time.timeScale = 1.0f;
                isPaused = false;
           }
       
    }

    public void pauseQuit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void continueFromCheckpoint()
    {
    //   if(check2)
    //   {
    //       player.transform.position = check2.transform.position;
    //   }
    //   if (check1)
    //   {
    //       player.transform.position = check1.transform.position;
    //   }
    //   else if (startPos)
    //   {
    //       player.transform.position = startPos.transform.position;
    //   }
    }

    public void gameOver()
    {
        if(player)
        {
            if (player.GetComponent<PlayerController>().lives <= 0)
            {
                if (gameOverCanvas.GetComponent<Canvas>())
                {
                    gameOverCanvas.GetComponent<Canvas>().enabled = true;
                }
            }
        }
    }

    public void pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            isPaused = true;
            if (isPaused == true)
            {
                Time.timeScale = 0.0f;
                _canvas.enabled = true;
            }
            
          
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void newGame()
    {
        SceneManager.LoadScene("");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    
    float resumeTimer;
    bool loseOverlay, isPaused;
    public Canvas _canvas;
    gameOver gameOverCanvas;
    PlayerController player;
    GameObject pausePanel;
    GameObject deadPanel;
    // Use this for initialization


    void Start()
    {

        loseOverlay = false;
        //continueFromCheckpoint();
        resumeTimer = 0.0f;
        isPaused = false;
        player = GameObject.FindObjectOfType<PlayerController>();
        if(_canvas)
        _canvas.enabled = false;
        gameOverCanvas = GameObject.FindObjectOfType<gameOver>();
        if (gameOverCanvas)
        {
            gameOverCanvas.GetComponent<Canvas>().enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
      //  while(loseOverlay == true)
      //  {
        gameOver();
            //if()
       // }
        pause();
    }

    public void resume()
    {
        if (_canvas)
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
        player.lives = 3;
       // loseOverlay = false;
        gameOverCanvas.GetComponent<Canvas>().enabled = false;
        player.ContuneFromCheckpoint();
    }
    //once they die continue menu 
    public void gameOver()
    {
        if (player)
        {
            if (player.GetComponent<PlayerController>().lives <= 0)
            {
          //   loseOverlay = true;
                //while(loseOverlay)
               // {
                gameOverCanvas.GetComponent<Canvas>().enabled = true;
                   
                //}

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    Slider volSlider;
    float resumeTimer;
    bool loseOverlay, isPaused;
    public Canvas _canvas;
    gameOver gameOverCanvas;
    youWinScript youWin;
    PlayerController player;
    GameObject pausePanel;
    GameObject deadPanel;
    // Use this for initialization


    void Start()
    {
        volSlider = GetComponent<Slider>();
        loseOverlay = false;
        //continueFromCheckpoint();
        resumeTimer = 0.0f;
        isPaused = false;
        player = GameObject.FindObjectOfType<PlayerController>();
        youWin = GameObject.FindObjectOfType<youWinScript>();
        if (youWin)
            youWin.GetComponent<youWinScript>().enabled = false;
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
        uWin();
        gameOver();
         
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
            _canvas.enabled = false;
        }

    }

    public void pauseQuit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void continueFromCheckpoint()
    {
        Time.timeScale = 1;
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
                Time.timeScale = 0;
          //   loseOverlay = true;
                //while(loseOverlay)
               // {
                gameOverCanvas.GetComponent<Canvas>().enabled = true;
                   
                //}

            }
        }
    }
    
    public void options()
    {
     //  volSlider.
     //  // AudioSource.volume;
     //   Screen.SetResolution(1920, 1080, true, 60);
     //   Screen.SetResolution(1920, 1200, true, 60);
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
    public void uWin()
    {
        //put the collider check right here 
        //if()
        if(youWin)
        youWin.GetComponent<youWinScript>().enabled = true;
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

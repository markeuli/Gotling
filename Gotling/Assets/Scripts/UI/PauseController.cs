using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool isPaused;
    private float previousTimeScale;
    //each of the references to menu controllers requiring to pauses will be dragged into here from the unity editor
    public PauseMenuController _pauseMenuController;
    public GameOverMenu _gameOverMenu;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        ClearMenus();
    }

    // Update is called once per frame
    //void Update() {}

    //TogglePause(string menu) will require a menu option each time the game is paused for some reason
    public void TogglePause(string menu)
    {
            if (Time.timeScale > 0)
            {
                previousTimeScale = Time.timeScale;
                Time.timeScale = 0;
                AudioListener.pause = true;

                isPaused = true;
                HandleMenu(menu, true);
            }
            else
            {
                HandleMenu(menu, false);
                Time.timeScale = previousTimeScale;
                AudioListener.pause = false;
                isPaused = false;
            }
    }
    
    public void HandleMenu(string menu, bool b)
    {
        //this method will decide which menu to display given the reason for the pause
        switch(menu)
        {
            case "PlayerPause":
                _pauseMenuController.displayPauseMenu(b);
                break;
            case "PlayerDeath":
                _gameOverMenu.displayGameOverMenu(b);
                break;
            case "PlayerDecision":
                Debug.Log("Player Decision Menu not implemented! Get on that.");
                break;
            case "Cutscene":
                Debug.Log("We don't have the budget for that.");
                break;
            default:
                Debug.Log("Incorrect menu option in TogglePause call");
                break;
        }
    }

    public void ClearMenus()
    {
        _pauseMenuController.displayPauseMenu(false);
        _gameOverMenu.displayGameOverMenu(false);
    }
}

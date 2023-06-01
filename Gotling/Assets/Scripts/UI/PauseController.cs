using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool isPaused;
    private float previousTimeScale;
    public PauseMenuController _pauseMenuController;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        _pauseMenuController.displayPauseMenu(false);
    }

    // Update is called once per frame
    //void Update() {}

    public void TogglePause()
    {
        if (Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;

            isPaused = true;
            _pauseMenuController.displayPauseMenu(true);
        }
        else
        {
            _pauseMenuController.displayPauseMenu(false);
            Time.timeScale = previousTimeScale;
            AudioListener.pause = false;
            isPaused = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    private Button _resumeButton;
    private Button _mainMenuButton;
    private Button _quitButton;
    private SceneController _sceneController;
    private UIDocument _doc;
    [SerializeField] PauseController _pauseController;

    private void Awake()
    {

        _sceneController = GetComponent<SceneController>(); //can find scene controller because it is a component of menu in this scene
        _doc = GetComponent<UIDocument>();

        _resumeButton = _doc.rootVisualElement.Q<Button>("ResumeButton");
        _mainMenuButton = _doc.rootVisualElement.Q<Button>("MainMenuButton");
        _quitButton = _doc.rootVisualElement.Q<Button>("QuitButton");
  
        _resumeButton.clicked += ResumeButtonOnClicked; // () => {DoSomething();};
        _mainMenuButton.clicked += MainMenuButtonOnClicked;
        _quitButton.clicked += QuitButtonOnClicked;

        
    }

    private void QuitButtonOnClicked()
    {
        Application.Quit();
    }

    private void MainMenuButtonOnClicked()
    {
        
        _sceneController.SceneChange("Start");
        _pauseController.TogglePause("PlayerPause");
        Debug.Log("Main menu button clicked");
    }

    private void ResumeButtonOnClicked()
    {
        _pauseController.TogglePause("PlayerPause");
    }

    public void displayPauseMenu(bool b)
    {
        if(b)
        {
            _doc.rootVisualElement.style.display = DisplayStyle.Flex;
        }
        else
        {
            _doc.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    //void Update() {}
   
    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class GameOverMenu : MonoBehaviour
{
    [SerializeField] PauseController _pauseController;
    private Button _mainMenuButton;
    private Button _quitButton;
    private SceneController _sceneController;
    private UIDocument _doc;
    // Start is called before the first frame update
    private void Awake()
    {

        _sceneController = GetComponent<SceneController>(); //can find scene controller because it is a component of menu in this scene
        _doc = GetComponent<UIDocument>();

        
        _mainMenuButton = _doc.rootVisualElement.Q<Button>("MainMenuButton");
        _quitButton = _doc.rootVisualElement.Q<Button>("QuitButton");

        _mainMenuButton.clicked += MainMenuButtonOnClicked;
        _quitButton.clicked += QuitButtonOnClicked;


    }

    private void QuitButtonOnClicked()
    {
        Application.Quit();
    }

    private void MainMenuButtonOnClicked()
    {
        _pauseController.TogglePause("PlayerDeath");
        _sceneController.SceneChange("Start");
        Debug.Log("Main menu button clicked");
    }


    public void displayGameOverMenu(bool b)
    {
        if (b)
        {
            _doc.rootVisualElement.style.display = DisplayStyle.Flex;
        }
        else
        {
            _doc.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}

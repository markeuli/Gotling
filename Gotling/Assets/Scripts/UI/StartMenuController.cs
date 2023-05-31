using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartMenuController : MonoBehaviour
{
    //handle mute button sprites
    //will do the same for other buttons if sprites are added for them
    [Header("Mute Button Variables")]
    [SerializeField]
    private Sprite _mutedSprite;
    [SerializeField]
    private Sprite _unmutedSprite;
    private bool _muted;

    // Make variables to allow for second visual tree asset for secondary menu options (options, later for play->char sel)
    [Header("Options Menu Variables")]
    [SerializeField]
    private VisualTreeAsset _optionsButtonsTemplate; //drag and drop in inspector
    private VisualElement _optionsButtons; //create visual elements based on visual tree asset from above var

    [Header("Character Menu Variables")]
    [SerializeField]
    private VisualTreeAsset _charButtonsTemplate; //drag and drop in inspector
    private VisualElement _charButtons; //create visual elements based on visual tree asset from above var

    //create variables to connect to components and visual elements
    SceneController _sceneController;
    CharacterSelector _charSelector;
    private VisualElement _buttonsWrapper;
    private UIDocument _doc;
    private Button _playButton; //will take to character screen
    private Button _optionsButton;
    private Button _exitButton;
    private Button _muteButton;

    private void Awake()
    {
        //initialize secondary menu options from templates dropped in inspector
        _optionsButtons = _optionsButtonsTemplate.CloneTree();
        _charButtons = _charButtonsTemplate.CloneTree();

        //on awake, connect variable fields to components and visual elements
        _sceneController = GetComponent<SceneController>();
        _charSelector = GameObject.Find("CharacterSelector").GetComponent<CharacterSelector>();
        _doc = GetComponent<UIDocument>();
        
        _buttonsWrapper = _doc.rootVisualElement.Q<VisualElement>("Buttons");
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _optionsButton = _doc.rootVisualElement.Q<Button>("OptionsButton");
        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        _muteButton = _doc.rootVisualElement.Q<Button>("MuteButton");
        var _robinButton = _charButtons.Q<Button>("Robin");
        var _backButton = _optionsButtons.Q<Button>("BackButton");

        //add actions to be done each time buttons are clicked
        _playButton.clicked += PlayButtonOnClicked; // () => {DoSomething();};
        _exitButton.clicked += ExitButtonOnClicked;
        _muteButton.clicked += MuteButtonOnClicked;
        _optionsButton.clicked += OptionsButtonOnClicked;
        _backButton.clicked += BackButtonOnClicked;
        _robinButton.clicked += RobinButtonOnClicked;
       
    }

    private void RobinButtonOnClicked()
    {
        _charSelector.SelectCharacter(_charSelector.character1);
        _sceneController.SceneChange("Game");
    }
    private void BackButtonOnClicked()
    {
        //potential limitation: no visual tree asset for main menu buttons (play/opt/exit) so if we 
        // add more options, we'll have to make sure to readd them here
        //potential solution: make new visual tree asset for main menu items, so that here we can simply add the visual tree asset
        // as in OptionsButtonOnClicked()
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_playButton);
        _buttonsWrapper.Add(_optionsButton);
        _buttonsWrapper.Add(_exitButton);
    }
    private void OptionsButtonOnClicked()
    {
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_optionsButtons);
    }

    private void PlayButtonOnClicked()
    {
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_charButtons);
    }
    private void MuteButtonOnClicked()
    {
        _muted = !_muted;
        var bg = _muteButton.style.backgroundImage; //create bg to grab mute button background image
        bg.value = Background.FromSprite(_muted ? _mutedSprite : _unmutedSprite); //change based on _muted
        _muteButton.style.backgroundImage = bg; //set actual image to new image (copy/swap)

        AudioListener.volume = _muted ? 0 : 1;
    }

    //delete when play button works ;)
    /*private void PlayButtonOnClicked()
    {
        // FIX LATER: For now, takes you to Ben's scene where you choose starting character
        // Later, this will be a dynamic section similar to the OptionButtonOnClicked()
        _sceneController.SceneChange("Menu");
    }*/

    private void ExitButtonOnClicked()
    {
        Debug.Log("Exit button clicked.");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

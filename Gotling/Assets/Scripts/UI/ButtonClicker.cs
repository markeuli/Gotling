using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class ButtonClicker : MonoBehaviour
{

    UIDocument buttonDocument;
    Button uiButton;


    private void OnEnable()
    {
        //UIDocument would be the uxml doc that is the source asset in the object
        buttonDocument = GetComponent<UIDocument>();

        //check 
        if(buttonDocument == null)
        {
            Debug.LogError("No button document found");
        }

        //Here, getting the visual element in the uxml document and saving it as a Button
        uiButton = buttonDocument.rootVisualElement.Q("StartButton") as Button;

        if(uiButton != null)
        {
            Debug.Log("Found Button.");
        }

        uiButton.RegisterCallback<ClickEvent>(OnButtonClick);

    }

    public void OnButtonClick(ClickEvent evt)
    {
        Debug.Log("The UI Button has been clicked.");
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

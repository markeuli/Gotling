using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using HudElements;

public class HealthBarController : MonoBehaviour
{
    private HealthBar element;

    // Start is called before the first frame update
    void Start()
    {
        var UIDoc = GetComponent<UIDocument>();
        element = UIDoc.rootVisualElement.Q<HealthBar>();
    }

    public void SetHealthbar(float hp, float max)
    {
        element.value = hp / max;
    }
}
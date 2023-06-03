using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using HudElements;

public class HealthBarController : MonoBehaviour
{
    public Transform TransformToFollow;

    private VisualElement container;
    private HealthBar healthbar;
    public DamageableObject player;


    // Start is called before the first frame update
    void Start()
    {
        
        player = GetComponent<DamageableObject>();
        container = GetComponent<UIDocument>().rootVisualElement.Q("Container");
        
        healthbar = container.Q<HealthBar>();

        SetPosition();
    }

    private void LateUpdate()
    {
        if (TransformToFollow != null)
        {
            Debug.Log("Transform to follow should be set");
            Debug.Log("is visible? " + healthbar.visible);
            SetPosition();
        }
    }
    public void UpdateHUD()
    {
        healthbar.value = player.currentHp / player.maximumHp;
    }

    

    public void SetPosition()
    {

        //Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(
        //    container.panel, TransformToFollow.position, camera);

        //container.style.position = TransformToFollow.position;
        //container.style.top = TransformToFollow.position.y;
        //container.style.left = TransformToFollow.position.x;
        //Debug.Log(newPosition + "To Follow");
        //Debug.Log(container.transform.position + "Actual Position");
    }
}

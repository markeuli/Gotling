using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UIToolkitFollow : MonoBehaviour
{
	private VisualElement container;
    public Transform TransformToFollow;
    new private Camera camera;

	private void Start()
    {
        var UIDoc = GetComponent<UIDocument>();
        container = UIDoc.rootVisualElement.Children().FirstOrDefault();
        camera = Camera.main;

        if (TransformToFollow == null)
		{
            TransformToFollow = transform;
		}
	}

	private void LateUpdate()
    {
        if (TransformToFollow != null)
        {
            SetPosition();
        }
    }

    public void SetPosition()
    {
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(container.panel, TransformToFollow.position, camera);
        container.transform.position = new Vector2(newPosition.x - container.layout.width / 2, newPosition.y);
    }
}

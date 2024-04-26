using UnityEngine;

public class rain2 : MonoBehaviour
{
    private GameObject objectToDrag;
    private Vector3 offset;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    objectToDrag = new GameObject("Draggable Object");
                    objectToDrag.transform.position = new Vector3(touchPosition.x, touchPosition.y, 0);
                    offset = objectToDrag.transform.position - touchPosition;
                    break;
                case TouchPhase.Moved:
                    if (objectToDrag != null)
                    {
                        Vector3 newPosition = new Vector3(touchPosition.x, touchPosition.y, 0) + offset;
                        objectToDrag.transform.position = newPosition;
                    }
                    break;
                case TouchPhase.Ended:
                    if (objectToDrag != null)
                    {
                        Destroy(objectToDrag);
                    }
                    break;
            }
        }
    }
}

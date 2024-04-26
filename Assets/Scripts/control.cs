using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging && Time.timeScale > 0.1f)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}

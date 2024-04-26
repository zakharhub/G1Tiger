using UnityEngine;
using System.Collections;

public class Transformation : MonoBehaviour
{
    public float speed = 2f; 
    private float targetX; 
    private bool isPaused = false; 

    void Start()
    {
        
        transform.position = new Vector2(-2f, transform.position.y);
       
        targetX = 2f;
        
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        while (true)
        {
            if (!isPaused)
            {
                
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, transform.position.y), speed * Time.deltaTime);

                
                if (Mathf.Approximately(transform.position.x, targetX))
                {
                    if (targetX == 2f)
                    {
                        targetX = -2f;
                    }
                    else
                    {
                        targetX = 2f;
                    }
                }
            }

            
            yield return null;
        }
    }

    
    public void PauseAndResume()
    {
        if (!isPaused)
        {
            isPaused = true;
            StartCoroutine(ResumeAfterDelay(5f)); 
        }
    }

    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isPaused = false;
    }
}

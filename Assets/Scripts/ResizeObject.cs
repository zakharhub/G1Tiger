using UnityEngine;
using System.Collections;

public class ResizeObject : MonoBehaviour
{
    public GameObject objectToResize;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = objectToResize.transform.localScale;
    }

    public void Resize()
    {
        if (ShopMenu.small > 0)
        {
            if (objectToResize != null)
            {
                StartCoroutine(ResizeOverTime(0.5f, 2f));
            }
        }

    }

    IEnumerator ResizeOverTime(float targetScaleMultiplier, float duration)
    {


        Vector3 targetScale = originalScale * targetScaleMultiplier;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            objectToResize.transform.localScale = Vector3.Lerp(originalScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        objectToResize.transform.localScale = targetScale;

        yield return new WaitForSeconds(4f);

        StartCoroutine(ReturnToOriginalSize(1f));


    }

    IEnumerator ReturnToOriginalSize(float duration)
    {


        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            objectToResize.transform.localScale = Vector3.Lerp(objectToResize.transform.localScale, originalScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        objectToResize.transform.localScale = originalScale;


    }
}

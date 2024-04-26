using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbStop : MonoBehaviour
{
    public Button stopButton;

    void Start()
    {
        stopButton.onClick.AddListener(stopExecution);
    }

    void stopExecution()
    {
        StartCoroutine(WaitAndStop());
    }

    IEnumerator WaitAndStop()
    {
        yield return new WaitForSeconds(5f);
    }
}

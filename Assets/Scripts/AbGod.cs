using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
    public GameObject player;

    public void DisableTriggerForPlayer()
    {
        player.GetComponent<Collider2D>().isTrigger = false;
        StartCoroutine(EnableTriggerAfterDelay(5f));
    }

    IEnumerator EnableTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.GetComponent<Collider2D>().isTrigger = true;
    }
}

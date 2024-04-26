using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene2D : MonoBehaviour
{
    public int playerGoToScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(playerGoToScene);
        }
    }
}

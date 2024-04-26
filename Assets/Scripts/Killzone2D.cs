using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone2D : MonoBehaviour
{
    static bool killPlayer = true;

    public void TransparentMode()
    {
        if (ShopMenu.ghost > 0)
        {
            killPlayer = false;
            Invoke("F1", 1.5f);
        }      
    }

    void F1()
    {
        killPlayer = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (killPlayer == true && other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

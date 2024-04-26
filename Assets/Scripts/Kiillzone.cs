using UnityEngine;

public class Killzone : MonoBehaviour
{
    public bool killPlayer;
    public HealthManager healthManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && killPlayer)
        {
            healthManager.TakeDamage(1);
        }
    }

}

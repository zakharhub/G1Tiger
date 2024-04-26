using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 5; 
    private int currentHealth; 

    
    public GameObject[] heartIcons;

    void Start()
    {
        currentHealth = maxHealth; 
    }

    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; 

        
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                heartIcons[i].SetActive(true); 
            }
            else
            {
                heartIcons[i].SetActive(false); 
            }
        }

        
        if (currentHealth <= 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

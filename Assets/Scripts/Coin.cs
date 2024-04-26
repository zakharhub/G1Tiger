using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private int bonus = 100;
    public Text coinText;

    void Start()
    {
        UpdateCoinCount();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GrantBonus();
            UpdateCoinCount();
            Destroy(gameObject);
        }
    }

    private void GrantBonus()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        currentCoins += bonus;
        PlayerPrefs.SetInt("Coins", currentCoins);
    }

    private void UpdateCoinCount()
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);

        if (coinText != null)
        {
            coinText.text = " " + currentCoins.ToString();
        }
    }
}

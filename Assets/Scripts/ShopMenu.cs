using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    public GameObject insufficientMoneyImage;

    public static int ghost = 0;
    public static int speed = 0;
    public static int small = 0;

    public Image greenImage;
    public Image redImage;
    public Image standartImage;
    public static int greenSkin = 0;
    public static int redSkin = 0;
    public static int standartSkin = 0;

    public TextMeshProUGUI tGhost;
    public TextMeshProUGUI tSpeed;
    public TextMeshProUGUI tSmall;

    int currentCoins = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            currentCoins = PlayerPrefs.GetInt("Coins");
        }

        if (PlayerPrefs.HasKey("Ghost"))
        {
            ghost = PlayerPrefs.GetInt("Ghost");
        }

        if (PlayerPrefs.HasKey("Speed"))
        {
            speed = PlayerPrefs.GetInt("Speed");
        }

        if (PlayerPrefs.HasKey("Small"))
        {
            small = PlayerPrefs.GetInt("Small");
        }

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (PlayerPrefs.HasKey("RedSkin"))
            {
                redSkin = PlayerPrefs.GetInt("RedSkin");
                if (redSkin == 1)
                {
                    redImage.color = new Color(0, 1, 0, 1);
                }
            }

            if (PlayerPrefs.HasKey("GreenSkin"))
            {
                greenSkin = PlayerPrefs.GetInt("GreenSkin");
                if (greenSkin == 1)
                {
                    greenImage.color = new Color(0, 1, 0, 1);
                }
            }

            if (PlayerPrefs.HasKey("StandartSkin"))
            {
                standartSkin = PlayerPrefs.GetInt("StandartSkin");
                if (standartSkin == 1)
                {
                    standartImage.color = new Color(0, 1, 0, 1);
                }
            }
        }

        

        if (tGhost != null)
        {
            tGhost.text = "x" + ghost;
            tSpeed.text = "x" + speed;
            tSmall.text = "x" + small;
        }
    }

    //Ghost
    public void AddGhost()
    {
        if (currentCoins >= 200)
        {
            ghost++;
            currentCoins -= 200;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("Ghost", ghost);
        }
        else
        {
            insufficientMoneyImage.SetActive(true);
            StartCoroutine(HideInsufficientMoneyImage());
        }
    }
    public void RemoveGhost()
    {
        if (ghost > 0)
        {
            ghost--;
            tGhost.text = "x" + ghost;
            PlayerPrefs.SetInt("Ghost", ghost);
        }
    }

    //SpeedWall
    public void AddSpeed()
    {
        if (currentCoins >= 100)
        {
            speed++;
            currentCoins -= 100;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("Speed", speed);
        }
        else
        {
            insufficientMoneyImage.SetActive(true);
            StartCoroutine(HideInsufficientMoneyImage());
        }
    }
    public void RemoveSpeed()
    {
        if (speed > 0)
        {
            speed--;
            tSpeed.text = "x" + speed;
            PlayerPrefs.SetInt("Speed", speed);
        }
    }

    //Small
    public void AddSmall()
    {
        print(currentCoins + "$");
        if (currentCoins >= 50)
        {
            small++;
            currentCoins -= 50;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("Small", small);
        }
        else
        {
            insufficientMoneyImage.SetActive(true);
            StartCoroutine(HideInsufficientMoneyImage());
        }
    }
    public void RemoveSmall()
    {
        if (small > 0)
        {
            small--;
            tSmall.text = "x" + small;
            PlayerPrefs.SetInt("Small", small);
        }
    }

    IEnumerator HideInsufficientMoneyImage()
    {
        yield return new WaitForSeconds(2f);

        insufficientMoneyImage.SetActive(false);
    }

    public void GreenSkin()
    {
        print(greenSkin + " " + currentCoins);
        if (greenSkin == 0 && currentCoins >= 100)
        {
            currentCoins -= 100;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("GreenSkin", 1);
            greenSkin = 1;
            redSkin = 0;
            standartSkin = 0;
            PlayerPrefs.SetInt("GreenSkin", 0);
            greenImage.color = new Color(0, 1, 0, 1);
            redImage.color = new Color(1, 1, 1, 1);
            standartImage.color = new Color(1, 1, 1, 1);
        }
    }
    public void RedSkin()
    {
        print(redSkin + " " + currentCoins + "2");
        if (redSkin == 0 && currentCoins >= 200)
        {
            currentCoins -= 200;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("RedSkin", 1);
            redSkin = 1;
            greenSkin = 0;
            standartSkin = 0;
            PlayerPrefs.SetInt("RedSkin", 0);
            redImage.color = new Color(0, 1, 0, 1);
            greenImage.color = new Color(1, 1, 1, 1);
            standartImage.color = new Color(1, 1, 1, 1);
        }
    }
    public void StandartSkin()
    {
        currentCoins -= 0;
        PlayerPrefs.SetInt("Coins", currentCoins);
        PlayerPrefs.SetInt("StandartSkin", 1);
        standartSkin = 1;
        greenSkin = 0;
        redSkin = 0;
        PlayerPrefs.SetInt("StandartSkin", 0);
        standartImage.color = new Color(0, 1, 0, 1);
        greenImage.color = new Color(1, 1, 1, 1);
        redImage.color = new Color(1, 1, 1, 1);
    }
}
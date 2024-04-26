using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    void Start()
    {
        if (ShopMenu.greenSkin == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.1008155f, 1f);
        }

        if (ShopMenu.redSkin == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.1179245f, 0.149057f, 1f);
        }

        if (ShopMenu.standartSkin == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

}

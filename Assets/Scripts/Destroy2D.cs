using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2D : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}

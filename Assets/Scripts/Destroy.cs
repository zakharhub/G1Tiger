using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("��������");
        if (other.CompareTag("kaply"))
        {
            Destroy(other.gameObject);
        }
    }
}

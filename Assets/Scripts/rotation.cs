using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 1f;

    public void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}


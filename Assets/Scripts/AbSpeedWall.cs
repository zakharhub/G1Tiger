using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbSpeedWall : MonoBehaviour
{
    [SerializeField] private RotateAroundAxis rotationScript;
    [SerializeField] private float speedChangeAmount = 5f;
    [SerializeField] private float duration = 5f;

    private bool isChangingSpeed = false;

    public void ChangeRotationSpeed()
    {
        if (ShopMenu.speed > 0)
        {
            if (!isChangingSpeed)
            {
                StartCoroutine(ChangeSpeedForDuration());
            }
        }

    }

    private IEnumerator ChangeSpeedForDuration()
    {
        if (ShopMenu.speed > 0)
        {
            isChangingSpeed = true;
            print(rotationScript.rotationSpeed);
            float originalSpeed = rotationScript.rotationSpeed;
            rotationScript.rotationSpeed -= speedChangeAmount;
            print(rotationScript.rotationSpeed);

            yield return new WaitForSeconds(duration);

            rotationScript.rotationSpeed = originalSpeed;
            isChangingSpeed = false;
            print(rotationScript.rotationSpeed + "*");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Quaternion maxAngle;
    [SerializeField] float rotationSpeed;

    Quaternion targetRotation;
    bool isOpen;
    bool isRotating;

    void Start()
    {
        isOpen = false;
        isRotating = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            isOpen = !isOpen;
            isRotating = true;

            if (isOpen)
                targetRotation = transform.rotation * maxAngle;
            else
                targetRotation = Quaternion.Euler(0, 0, 0);
        }

        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
                isRotating = false;
        }
    }
}

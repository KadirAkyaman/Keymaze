using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float cameraVertical;
    [SerializeField] float rotateSpeed;
    [SerializeField] float minVerticalAngle;
    [SerializeField] float maxVerticalAngle;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {
        cameraVertical = Input.GetAxis("Mouse Y");

        float rotationAmount = cameraVertical * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.left, rotationAmount);
    }
}

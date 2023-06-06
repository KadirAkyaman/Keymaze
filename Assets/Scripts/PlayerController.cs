using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontalInput;
    float verticalInput;

    [SerializeField] float jumpAmount;
    Rigidbody rigidbody;

    float mouseHorizontal;

    [SerializeField] float rotateSpeed;

    public GameObject currentPlane;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Cursor.visible = false;
    }

    void Update()
    {
        MovementController();
        JumpController();
        RotatePlayer();
    }

    void RotatePlayer()
    {
        mouseHorizontal = Input.GetAxis("Mouse X");

        float rotationAmount = mouseHorizontal * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }

    void MovementController()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(horizontalInput * speed * Time.deltaTime, 0f, verticalInput * speed * Time.deltaTime);
    }

    void JumpController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.velocity = new Vector3(0f, jumpAmount, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            currentPlane = collision.gameObject;
        }
    }
}

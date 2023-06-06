using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    bool isRed;
    bool isBlue;
    bool isWhite;

    public GameObject redPlane;
    public GameObject bluePlane;


    Vector3 redStartPos;
    Vector3 blueStartPos;
    Vector3 whiteStartPos;

    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        redPlane = GameObject.Find("RedPlane");
        bluePlane = GameObject.Find("BluePlane");

        redStartPos = redPlane.transform.position;
        blueStartPos = bluePlane.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBlue = true;
            isRed = false;
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            isRed = true;
            isBlue = false;
        }

        if (isRed)
        {
            redPlane.transform.position = playerController.currentPlane.transform.position + new Vector3(0, 0, 30);
            bluePlane.transform.position = blueStartPos;
        }

        else if (isBlue)
        {
            bluePlane.transform.position = playerController.currentPlane.transform.position + new Vector3(0, 0, 30);
            redPlane.transform.position = redStartPos;
        }
    }
}

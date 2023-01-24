using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FIRST_PERSON : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;


    // Start is called before the first frame update
    void Start()
    {

        // lock the cursor in place 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        // get mouse input 
        float mouseX = Input.GetAxisRaw("Mouse X") * Timeout.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Timeout.deltaTime * sensY;


        yRotation += mouseX;
        xRotation -= mouseY;

        // Clamp the up and down rotation to looking straight up and straight down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate the camera and orientation
        Transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}

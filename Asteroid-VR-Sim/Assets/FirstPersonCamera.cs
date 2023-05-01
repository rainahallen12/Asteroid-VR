using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    // variables
    public Transform Player;
    public float mouseSensitivity = 2f;
    public float speed;
    
    float cameraVerticalRotation = 0f;
    float cameraHorizontalRotation = 0f;

    void Walk(){

        if(Input.GetKey(KeyCode.W)){

        transform.Translate(Vector3.forward * speed);      
        
        
        if (transform.position.y < 43.5){
                
               transform.Translate(Vector3.up * 1);

                }
            }


    }
    void Start()
    {
        // lock and hide the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()
    {
        // collect mouse input
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // rotate the camera around its local X axis
        cameraVerticalRotation -= inputY;
        cameraHorizontalRotation += inputX;
        
        // clamp looking up and down
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        // actually moving the camera around
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation + Vector3.up * cameraHorizontalRotation;

        Walk();

    }
}




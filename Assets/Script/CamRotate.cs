using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float Sensitivity = 80;
    public Transform playerBody;
  
    float xRotation ;
    float rotateY;
    float rotateX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotateY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        rotateX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;

        xRotation -= rotateY;

        xRotation = Math.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * rotateX);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}


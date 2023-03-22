using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera123 : MonoBehaviour
{
    public Transform PlayerModel;

    public float mouseSensitivity = 200f;

    private float xRotation = 0f;


    void Awake()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
       
        PlayerModel.Rotate(Vector3.up * mouseX);
    }
}

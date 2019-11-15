using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float float_mouseSensitivity = 100f;
    public Transform transform_playerBody;

    float float_xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X")*float_mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*float_mouseSensitivity * Time.deltaTime;
       
        transform_playerBody.Rotate(Vector3.up * mouseX);

        float_xRotation -= mouseY;
        float_xRotation = Mathf.Clamp(float_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(float_xRotation, 0f, 0f);

       // Debug.Log("x: " + mouseX);
       // Debug.Log("y: " +mouseY);
    }
}

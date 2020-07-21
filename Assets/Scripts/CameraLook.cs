using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float fMouseSense = 100f;

    public Transform tPlayer;

    float fXRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float fMouseX = Input.GetAxis("Mouse X") * fMouseSense * Time.deltaTime;
        float fMouseY = Input.GetAxis("Mouse Y") * fMouseSense * Time.deltaTime;

        fXRotation -= fMouseY;
        fXRotation = Mathf.Clamp(fXRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(fXRotation, 0f, 0f);
        tPlayer.Rotate(Vector3.up * fMouseX);
    }
}
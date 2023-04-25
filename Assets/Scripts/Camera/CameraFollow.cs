using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;

    public float touchX;
    public float touchY;
    public float mouseX;
    public float mouseY;
    //public float finalInputX;
    //public float finalInputZ;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    private float finalY = 0.0f;
    private float finalX = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touchX = Input.GetTouch(0).deltaPosition.x;
            touchY = Input.GetTouch(0).deltaPosition.y;
        }
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalX = mouseX + touchX;
        finalY = mouseY + touchY;
        rotY += finalX * inputSensitivity * Time.deltaTime;
        rotX += finalY * inputSensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion localRotation = Quaternion.Euler(-rotX, rotY, 0.0f);
        transform.rotation = localRotation;


    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        //set target
        Transform target = CameraFollowObj.transform;

        //move towards it
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target.position,step);
    }
}

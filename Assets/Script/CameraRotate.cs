using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float rotateX;
    float rotateY;

    public float rotateSpeed = 100;

    Vector3 cameraNear;
    Vector3 cameraFar;

    float wheelValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraNear = transform.localPosition;
        //localPosition 으로 내 부모를 기준으로한 위치로 간다.

    }

    // Update is called once per frame
    void Update()
    {

        cameraFar = cameraNear + transform.forward * -5;

        wheelValue -= Input.GetAxis("Mouse ScrollWheel");
        wheelValue = Mathf.Clamp(wheelValue, 0, 1.0f);

        Vector3 cameraPosition = Vector3.Lerp(cameraNear, cameraFar, wheelValue);

        transform.localPosition = cameraPosition;


        float axisX = Input.GetAxis("Mouse X");
        float axisY = Input.GetAxis("Mouse Y");

        rotateX += axisY * rotateSpeed * Time.deltaTime;
        rotateY += axisX * rotateSpeed * Time.deltaTime;

        rotateX = Mathf.Clamp(rotateX, -80, 80);

        transform.eulerAngles = new Vector3(-rotateX, rotateY, 0);
    }
}

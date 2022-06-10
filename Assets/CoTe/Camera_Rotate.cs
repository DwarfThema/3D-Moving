using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotate : MonoBehaviour
{
    float rotateX;
    float rotateY;

    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Mouse X");
        float axisY = Input.GetAxis("Mouse Y");

        rotateX += axisY * rotateSpeed * Time.deltaTime;
        rotateY += axisX * rotateSpeed * Time.deltaTime;

        rotateX = Mathf.Clamp(rotateX, -80, 80);

        transform.eulerAngles = new Vector3(-rotateX, rotateY, 0);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Move : MonoBehaviour
{
    CharacterController characterController;

    Vector3 dir;

    public float speed = 5;

    float gravity = -9.18f;
    float yVelocity;
    public int jumpPower = 3;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        dir = Camera.main.transform.TransformDirection(dir);

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }

        characterController.Move(dir * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    CharacterController controller;

    public float speed = 3f;

    public float gravity = -9.18f;
    public float jumpPower = 1;
    float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //이동
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        float time = Time.deltaTime;

        

        // 속도 증가
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
        }
        else
        {
            speed = 3f;
        }


        //점프
        jumpVelocity += gravity * time;

        if (Input.GetButtonDown("Jump"))
        {
            jumpVelocity = jumpPower;
        }

        dir.y = jumpVelocity;

        controller.Move(dir * speed * time);
    }
}

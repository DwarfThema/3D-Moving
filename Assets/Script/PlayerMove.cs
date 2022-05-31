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


    public enum State
    {
        Normal,
        Climb
    }

    public State state;

    GameObject target;
    Ladder ladder;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        target = GameObject.Find("Ladder");
        ladder = target.GetComponent<Ladder>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        float time = Time.deltaTime;

        if (state == State.Normal)
        {
            //이동
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            dir = Vector3.right * h + Vector3.forward * v;
            dir.Normalize();


            //카메라 동기화
            dir = Camera.main.transform.TransformDirection(dir);



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
        }
        else if(state == State.Climb)
        {
            float v = Input.GetAxis("Vertical");

            dir = new Vector3(0, v, 0);

            if(transform.position.y >= ladder.objHeight + 1)
            // 실제로 프린트 해보니 여유롭게 1을 더 주면 좋겠다 싶어서 1을 넣었다.
            {
                StartCoroutine("ClimbEndWalk");
            }
        }

        controller.Move(dir * speed * time);
        
    }
    IEnumerator ClimbEndWalk()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + transform.forward * 1;
        float currentTime = 0;

        while (true)
        {
            if (currentTime < 1)
            {
                currentTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, currentTime);

                yield return null;
            }
            else
            {
                state = State.Normal;

                yield break;
            }
        }
    }

}

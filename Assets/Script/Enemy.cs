using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //NavMeshAgent 하려면 꼭 필요

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;

    public enum State
    {
        Idle,
        Move,
        Return
    }

    public State state;

    GameObject target;

    Vector3 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        state = State.Idle;

        target = GameObject.Find("FirstPerson");

        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Idle)
        {
            UpdateIdle();
        }else if(state == State.Move)
        {
            UpdateMove();
        }else if( state == State.Return)
        {
            UpdateReturn();
        }
    }

    public float detectDistnace = 5f;

    private void UpdateIdle()
    {

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < detectDistnace)
        {
            state = State.Move;
        }
    }

    public float traceDistance = 5f;

    private void UpdateMove()
    {
        agent.destination = target.transform.position;

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance > traceDistance)
        {
            state = State.Return;
        }
    }

    private void UpdateReturn()
    {
        agent.destination = originPosition;

        float distance = Vector3.Distance(transform.position, originPosition);

        if (distance <= 0.1f)
        {
            state = State.Idle;
        }
    }
}

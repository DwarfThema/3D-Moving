using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public State state;

    public enum State
    {
        Idle,
        Attack
    }

    GameObject target;

    PlayerHP playerHp;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;

        target = GameObject.Find("FirstPerson");

        playerHp = target.GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Attack)
        {
            UpdateAttack();
        }
        else
        {
            state = State.Idle;
            UpdateIdle();
        }
    }

    float attackDistance = 2f;
    private void UpdateIdle()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < attackDistance)
        {
            state = State.Attack;
        }
    }

    float currentTime;
    float attackTime = 1;

    private void UpdateAttack()
    {
        currentTime += Time.deltaTime;

        if(currentTime > attackTime)
        {
            playerHp.AddDamage();
            currentTime = 0;
        }


        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            state = State.Idle;
        }
    }

}

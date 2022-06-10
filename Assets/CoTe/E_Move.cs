using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class E_Move : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject target;


    P_HP playerHP;

    float distance;

    public Animator anim;

    public enum State
    {
        Idle,
        Move,
        Attack,
        Die
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");

        playerHP = target.GetComponent<P_HP>();

        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(target.transform.position, transform.position);

        if(state == State.Idle)
        {
            UpdateIdle();
        }else if(state == State.Move)
        {
            UpdateMove();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
    }



    public float detectingArea = 20f;
    private void UpdateIdle()
    {
        if(distance < detectingArea)
        {
            Debug.Log("게으름");
            state = State.Move;
        }
    }

    public float attackArea = 15f;
    private void UpdateMove()
    {
        navMeshAgent.destination = target.transform.position;
        anim.SetTrigger("Move");

        if (distance < attackArea)
        {
            navMeshAgent.isStopped = true;
            state = State.Attack;
        }else if(distance > attackArea)
        {
            Debug.Log("이동");
            anim.SetTrigger("Move");
            state = State.Move;
        }
    }

    private void UpdateAttack()
    {
        anim.SetTrigger("Attack");
        Debug.Log("공격");

        if (distance > attackArea)
        {
            state = State.Move;
            navMeshAgent.isStopped = false;
        }
    }

    public void AddDamage(int damage)
    {
        anim.SetTrigger("Die");
        state = State.Die;
        Destroy(gameObject, 5f);
    }

    private void OnDestroy()
    {
        EnemyFactory.instance.ENEMYCOUNT--;
    }

    internal void OnEventAttack()
    {
        playerHP.AddDamage(1);
    }
}

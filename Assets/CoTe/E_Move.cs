using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class E_Move : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = target.transform.position;
    }

    public void AddDamage(int damage)
    {
        Destroy(gameObject);
    }
}

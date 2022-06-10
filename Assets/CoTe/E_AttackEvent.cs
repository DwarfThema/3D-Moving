using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AttackEvent : MonoBehaviour
{
    public E_Move E_Move;

    public void OnEventAttack()
    {
        E_Move.OnEventAttack();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

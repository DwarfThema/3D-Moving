using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_HP : MonoBehaviour
{
    int hp;
    public int maxHp = 10;

    public Slider sliderHP;

    public int HP
    {
        get { return hp; }
        set { 
            hp = value;
            sliderHP.value = value;
        }
    }
    public void AddDamage(int damage)
    {
        HP -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHp;
        sliderHP.value = HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

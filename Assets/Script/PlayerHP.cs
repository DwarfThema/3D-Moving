using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int hp;
    public int maxHP = 3;

    public Slider slider;

    public int HP
    {
        get { return hp; }  
        set 
        { 
            hp = value;
            slider.value = value;
        }
    }

    public void AddDamage()
    {
        HP -= 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        slider.value = maxHP;   
        //에이치피..
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            HitManager.instance.GameOver();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Shot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.transform.name);

                E_Move enemy = hitInfo.transform.GetComponent<E_Move>();
                if (enemy != null)
                {
                    enemy.AddDamage(1);
                }
            }
        }
    }
}

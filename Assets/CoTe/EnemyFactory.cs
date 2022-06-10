using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject enemy;

    int enemyCount;
    public int enemyMaxCount = 3;

    public float generateTime = 2;
    public int ENEMYCOUNT
    {
        get { return enemyCount; }
        set
        {
            enemyCount = value;
            if(enemyCount < 0)
            {
                enemyCount = 0;
            }
            if(enemyCount > enemyMaxCount)
            {
                enemyCount = enemyMaxCount;
            }

        }
    }


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            if(enemyCount < enemyMaxCount)
            {
                enemy = Instantiate(enemy);
                enemy.transform.position = transform.position + new Vector3(Random.value * 2, 0, Random.value * 2);
                enemyCount++;

                enemy.transform.rotation = transform.rotation;
                
            }

            yield return new WaitForSeconds(generateTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

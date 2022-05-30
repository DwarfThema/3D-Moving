using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    public GameObject gameOverImg;
    public GameObject gameOverText;


    public static HitManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameOverImg.SetActive(false);
        this.gameOverText.SetActive(false);
    }

    public void GameOver()
    {
        StartCoroutine("IeGameOver");
        
    }

    IEnumerator IeGameOver()
    {
        gameOverImg.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameOverText.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

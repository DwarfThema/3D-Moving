using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float objHeight;

    // Start is called before the first frame update
    void Start()
    {
        objHeight = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();

        if (player)
        {
            player.state = PlayerMove.State.Climb;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public int score;
    public Transform player;

    public float boostTimer;


    // Start is called before the first frame update
    void Start()
    {
        gm = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            player.GetComponent<Player>().maxspeed = 30;
        }
        else
        {
            player.GetComponent<Player>().maxspeed = 15;
        }
    }
}

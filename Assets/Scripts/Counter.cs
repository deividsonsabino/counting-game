using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private GameManager gameManager;
    public Text CounterText;

    private int count = 0;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        count += 1;
        gameManager.UpdateScore(count);
    }
}

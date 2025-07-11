using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingFish : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerInfo playerInfo;
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        playerInfo = gameManager.player.GetComponent<PlayerInfo>();
    }

    private void OnTriggerEnter2D(Collider2D fish)
    {
        if (fish.CompareTag("Fish"))
        {
            FishInfo fishInfo = fish.GetComponent<FishInfo>();
            playerInfo.AddMoney(fishInfo.price);
            Destroy(fish.gameObject); //:(
        }
    }
}

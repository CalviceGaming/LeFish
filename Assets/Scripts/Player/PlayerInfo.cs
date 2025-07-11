using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private float currentMoney = 0;
    private GameManager gameManager;
    private Text moneyText;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        moneyText = gameManager.moneyText;
    }
    
    public void AddMoney(float amount)
    {
        currentMoney += amount;
        moneyText.text = currentMoney.ToString("F1") + "$";
    }
}

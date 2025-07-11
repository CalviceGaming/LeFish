using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FishInfo : MonoBehaviour
{
    public FishTypes fishType;

    public float weight;
    public float price;
    
    [SerializeField] private FishMovement fishMovement;

    private void Start()
    {
        weight = UnityEngine.Random.Range(fishType.minWeight, fishType.maxWeight);
        price = weight * fishType.pricePerOneWeight;
        
        fishMovement.SetSpeed(fishType.speed);
    }
}

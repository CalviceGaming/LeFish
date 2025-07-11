using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFishType", menuName = "Fishing/Fish Type")]
public class FishTypes : ScriptableObject
{
    public string fishType;

    public float minWeight;
    public float maxWeight;

    public float pricePerOneWeight;
    
    public float speed;
}

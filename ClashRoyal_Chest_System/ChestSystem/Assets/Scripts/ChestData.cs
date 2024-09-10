using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewChestData", menuName ="ChestSystem/ChestData")]
public class ChestData : ScriptableObject
{
    public ChestType chestType;
    public int minCoins;
    public int maxCoins;
    public int minGems;
    public int maxGems;

}

public enum ChestType
{
    Common,
    Rare,
    Epic,
    Legendary

}

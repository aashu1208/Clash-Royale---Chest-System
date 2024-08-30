using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DesignerConfig", menuName ="GameConfig/DesignerConfig")]
public class DesignerConfig : ScriptableObject
{
    public int[] CoinRanges = new int[8];
    public int[] GemRanges = new int[8];
    public int MaxSlot;
    public int MaxQueue;
    public int GemCostPerTenMinutes;
}

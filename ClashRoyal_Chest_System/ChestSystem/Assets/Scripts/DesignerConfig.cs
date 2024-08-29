using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DesignerConfig", menuName ="GameConfig/DesignerConfig")]
public class DesignerConfig : ScriptableObject
{
    public int[] CoinRanges;
    public int[] GemRanges;
    public int MaxSlot;
    public int MaxQueue;
    public int GemCostPerTenMinutes;
}

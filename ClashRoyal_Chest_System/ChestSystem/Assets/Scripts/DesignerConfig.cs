using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DesignerConfig", menuName ="GameConfig/DesignerConfig")]
public class DesignerConfig : ScriptableObject
{
    public int[] CoinRanges = new int[]{ 100, 200, 300, 500, 600, 800, 1000, 1200};
    public int[] GemRanges = new int[] { 10, 20, 20, 40, 45, 60, 80, 100};
    public int MaxSlot;
    public int MaxQueue;
    public int GemCostPerTenMinutes;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum ChestState
{
    Locked,
    Unlocking,
    Unlocked,
    Collected


}
public class Chest
{

    public ChestState State;
    public int Coins { get; private set; }
    public int Gems { get; private set; }
    public float UnlockTime { get; private set; }
    public float RemainingTime { get; private set; }
    private ChestData chestData;

    /*public Chest(ChestData data)
    {
        chestData = data;
        State = ChestState.Locked;

        Coins = Random.Range(chestData.minCoins, chestData.minCoins+1);
        Gems = Random.Range(data.minGems, data.maxGems+1);
        

    }*/
    public void TapToStart(int chestIndex)
    {
        if (State == ChestState.Locked)
        {
            State = ChestState.Unlocking;
            ChestManager.chestManagerInstance.chestTexts[chestIndex].text = "Unlocking..";
            Debug.Log("Unlocking....");
        }

        else if (State == ChestState.Unlocking)
        {
            State = ChestState.Unlocked;
            ChestManager.chestManagerInstance.chestTexts[chestIndex].text = "Unlocked";
            Debug.Log("Unlocked..");
        }
        else if (State == ChestState.Unlocked)
        {
            State = ChestState.Collected;
            ChestManager.chestManagerInstance.chestTexts[chestIndex].text = "Collected";
            Debug.Log("Collected..");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public void TapToStart()
    {
        if (State == ChestState.Locked)
        {
            State = ChestState.Unlocking;
            Debug.Log("Unlocking....");
        }

        else if (State == ChestState.Unlocking)
        {
            State = ChestState.Unlocked;
            Debug.Log("Unlocked..");
        }
        else if (State == ChestState.Unlocked)
        {
            State = ChestState.Collected;
            Debug.Log("Collected..");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ChestState
{
    Locked,
    Unlocking,
    Unlcoked,
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
        }
    }

}

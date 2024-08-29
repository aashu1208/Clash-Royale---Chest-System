using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChestState { Locked, Unlocking, Unlocked, Collecting}

public class Chest
{
    public ChestState State {get; private set;}
    public int Coins { get; private set; }

    public int Gems { get; private set; }

    public float UnlockTime { get; private set; }
    public float remainingTime;

    public Chest(int coins, int gems, float unlocktime)
    {


    }

}

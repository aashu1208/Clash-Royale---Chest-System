using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChestState { Locked, Unlocking, Unlocked, Collected}

public class Chest
{
    public ChestState State {get; private set;}
    public int Coins { get; private set; }

    public int Gems { get; private set; }

    public float UnlockTime { get; private set; }
    public float remainingTime;

    public Chest(int coins, int gems, float unlocktime)
    {
        Coins = coins;
        Gems = gems;
        UnlockTime = unlocktime;
        remainingTime = unlocktime;
        State = ChestState.Locked;

    }
    public void StartUnlocking()
    {
        State = ChestState.Unlocking;
    }

    public void UpdateUnlocking(float deltaTime)
    {
        if (State == ChestState.Unlocking)
        {
            remainingTime -= deltaTime;
            if (remainingTime <= 0)
            {
                State = ChestState.Unlocked;
            }
        }
    }
    public int CalculateGemCost()
    {
        return Mathf.CeilToInt(remainingTime/600); //1 gem per 10 minutes
    }
    public void Collect()
    {
        State = ChestState.Collected;

    }

}

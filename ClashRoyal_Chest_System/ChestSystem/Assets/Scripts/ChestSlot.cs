using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlot : MonoBehaviour
{
    public Chest CurrentChest { get; private set; }
    public bool IsEmpty => CurrentChest == null;

    public void AddChest(Chest chest)
    {
        if (IsEmpty)
        {
            CurrentChest = chest;
        }

    }
    public void StartTimer()
    {
        if (CurrentChest != null && CurrentChest.State == ChestState.Locked)
        {

            CurrentChest.StartUnlocking();
        }

    }

    public void UnlockWithGems()
    {
        if (CurrentChest != null && CurrentChest.State == ChestState.Unlocking)
        {
            int gemCost = CurrentChest.CalculateGemCost();
            if (CurrencyManager.instance.HasEnoughgems(gemCost))
            {
                CurrencyManager.instance.SpendGems(gemCost);
                CurrentChest.Collect();
            }

            else
            {

            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

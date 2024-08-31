using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    public DesignerConfig config;
    private List<ChestSlot> slots;
    private Queue<Chest> chestQueue;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<ChestSlot>(FindObjectsOfType<ChestSlot>());
        chestQueue = new Queue<Chest>(config.MaxQueue);
    }

    public void GenerateRandomChest()
    {
        if (slots.Exists(slot => slot.IsEmpty))
        {
            int coins = Random.Range(config.CoinRanges[0], config.CoinRanges[1]);
            int gems = Random.Range(config.GemRanges[0], config.GemRanges[1]);
            float unlockTime = Random.Range(60f, 3600f);
            Chest newChest = new Chest(coins, gems, unlockTime);

            foreach (var slot in slots)
            {
                if (slot.IsEmpty)
                {
                    slot.AddChest(newChest);
                    break;
                }
            }
        }
        else
        {
            //Show "slots are full" pop-up
            UiManager.instance.ShowUIFullPopUp();
                
        }
    }

    private float GetUnlocktimeForChestType(int chestType)
    {
        switch (chestType)
        {
            case 0: return 900f;
            case 1: return 1800f;
            case 2: return 3600f;
            case 3: return 900f;
            default: return 10800f;
                
        }


    }


    // Update is called once per frame
    void Update()
    {
        // Handle chest timers here, updating the UI and state as needed
        foreach (var slot in slots)
        {
            if (slot.CurrentChest!= null && slot.CurrentChest.State == ChestState.Unlocking)
            {
                slot.CurrentChest.UpdateUnlocking(Time.deltaTime);
            }
        }

    }
}

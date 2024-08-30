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

    // Update is called once per frame
    void Update()
    {
        
    }
}

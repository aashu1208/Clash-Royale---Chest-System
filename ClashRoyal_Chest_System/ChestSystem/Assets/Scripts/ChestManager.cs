using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public Chest chest;
    public ChestState cheststate;
    // Start is called before the first frame update
    void Start()
    {
        chest = new Chest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_TapToStart()
    {
        chest.TapToStart();

    }
}

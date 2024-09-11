using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestManager : MonoBehaviour
{
    public static ChestManager chestManagerInstance;
    public Chest[] chest;
    public ChestState cheststate;

    // Texts UI's
    public TextMeshProUGUI[] chestTexts;
   
    // Start is called before the first frame update
    void Start()
    {
        chest = new Chest[4];
        for (int i = 0; i < chest.Length; i++)
        {
            chest[i] = new Chest();
        }

        if (chestManagerInstance == null)
        {
            chestManagerInstance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_TapToStart(int chestIndex)
    {
        if (chestIndex >= 0 && chestIndex < chest.Length)
        {
            chest[chestIndex].TapToStart(chestIndex);
        }

    }
}

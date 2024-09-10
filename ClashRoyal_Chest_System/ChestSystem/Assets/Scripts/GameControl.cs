using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private TextMeshProUGUI prizeText;

    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private GameObject handleButton; // Normal handle button

    [SerializeField]
    private GameObject handlePulledButton; // Pulled handle button

    private int prizeValue;
    private bool resultsChecked = false;
   
    // Start is called before the first frame update
    void Start()
    {
        handleButton.SetActive(true);
        handlePulledButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultsChecked)
        {
            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue;
        }
    }
    public void PullHandle()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            handleButton.SetActive(false);
            handlePulledButton.SetActive(true);

            HandlePulled?.Invoke(); // Trigger the event to start spinning the rows
            Debug.Log("Handle pulled and spinning started");
        }
        else
        {
            Debug.Log("Rows are not stopped, cannot pull the handle yet.");
        }
    }

    private void EndSpin()
    {
        handlePulledButton.SetActive(false);
        handleButton.SetActive(true);
    }

    public void CheckResults()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            string symbol = rows[0].stoppedSlot;

            // Determine if any symbol is "Wild" and substitute with the most frequent symbol
            bool hasWild = symbol == "Wild" || rows[1].stoppedSlot == "Wild" || rows[2].stoppedSlot == "Wild";
            if (hasWild)
            {
                string mostFrequentSymbol = GetMostFrequentSymbol();
                if (rows[0].stoppedSlot == "Wild") rows[0].stoppedSlot = mostFrequentSymbol;
                if (rows[1].stoppedSlot == "Wild") rows[1].stoppedSlot = mostFrequentSymbol;
                if (rows[2].stoppedSlot == "Wild") rows[2].stoppedSlot = mostFrequentSymbol;

                symbol = mostFrequentSymbol; // Update symbol after substituting wilds
            }

            // Check for winning combinations
            if (rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == rows[2].stoppedSlot)
            {
                switch (symbol)
                {
                    case "7":
                        prizeValue = 200;
                        prizeText.text = "Congratulations! You hit a jackpot with 7s! Prize: " + prizeValue;
                        break;
                    case "Bell":
                        prizeValue = 400;
                        prizeText.text = "Congratulations! You hit a jackpot with Bells! Prize: " + prizeValue;
                        break;
                    case "Fruit":
                        prizeValue = 600;
                        prizeText.text = "Congratulations! You hit a jackpot with Fruits! Prize: " + prizeValue;
                        break;
                    case "Bar":
                        prizeValue = 800;
                        prizeText.text = "Congratulations! You hit a jackpot with Bars! Prize: " + prizeValue;
                        break;
                    default:
                        prizeValue = 0;
                        prizeText.text = "No win this time. Better luck next spin!";
                        break;
                }
            }
            else
            {
                // Check for partial matches
                if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && rows[0].stoppedSlot == "7")
                    || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && rows[1].stoppedSlot == "7"))
                {
                    prizeValue = 100;
                    prizeText.text = "You matched two 7s! Prize: " + prizeValue;
                }
                else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && rows[0].stoppedSlot == "Bell")
                    || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && rows[1].stoppedSlot == "Bell"))
                {
                    prizeValue = 300;
                    prizeText.text = "You matched two Bells! Prize: " + prizeValue;
                }
                else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && rows[0].stoppedSlot == "Fruit")
                    || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && rows[1].stoppedSlot == "Fruit"))
                {
                    prizeValue = 500;
                    prizeText.text = "You matched two Fruits! Prize: " + prizeValue;
                }
                else if (((rows[0].stoppedSlot == rows[1].stoppedSlot) && rows[0].stoppedSlot == "Bar")
                    || ((rows[1].stoppedSlot == rows[2].stoppedSlot) && rows[1].stoppedSlot == "Bar"))
                {
                    prizeValue = 700;
                    prizeText.text = "You matched two Bars! Prize: " + prizeValue;
                }
                else
                {
                    prizeValue = 0;
                    prizeText.text = "No win this time. Better luck next spin!";
                }
            }

            prizeText.enabled = true;
            resultsChecked = true;
            EndSpin(); // Reset handle buttons state when results are checked
        }
    }

    private string GetMostFrequentSymbol()
    {
        // Method to find the most frequent symbol (excluding "Wild")
        Dictionary<string, int> symbolCounts = new Dictionary<string, int>
        {
            { rows[0].stoppedSlot, 0 },
            { rows[1].stoppedSlot, 0 },
            { rows[2].stoppedSlot, 0 }
        };

        // Count occurrences of each symbol
        foreach (Row row in rows)
        {
            if (row.stoppedSlot != "Wild")
            {
                symbolCounts[row.stoppedSlot]++;
            }
        }

        // Find the symbol with the highest count
        string mostFrequentSymbol = "";
        int maxCount = 0;
        foreach (var kvp in symbolCounts)
        {
            if (kvp.Value > maxCount)
            {
                maxCount = kvp.Value;
                mostFrequentSymbol = kvp.Key;
            }
        }

        return mostFrequentSymbol;
    }
}

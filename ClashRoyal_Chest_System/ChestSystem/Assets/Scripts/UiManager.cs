using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject slotsFullPopUp;

    public void ShowUIFullPopUp()
    {
        if (slotsFullPopUp != null)
        {
            slotsFullPopUp.SetActive(true);
            StartCoroutine(HideUIFullPopUp(2f));
        }

    }

    IEnumerator HideUIFullPopUp(float delay)
    {

        slotsFullPopUp.SetActive(false);
        yield return new WaitForSeconds(delay);

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

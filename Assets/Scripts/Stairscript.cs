using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stairscript : MonoBehaviour
{
    public int LevelRequirement; //this level is required to be completed
    private bool state; //Open or closed
    private bool unlocked;
    public GameObject stair;
    public Image img; //Lock image

    void Update()
    {
        if (unlocked != true)
        {
            state = (PlayerPrefs.GetInt("LevelComplete" + LevelRequirement) != 0); //Determine state based on saved variable of completed levels

            if (state == true)
            {
                unlocked = true;
                stair.SetActive(true);
                img.enabled = false;
            }
        }
    }
}

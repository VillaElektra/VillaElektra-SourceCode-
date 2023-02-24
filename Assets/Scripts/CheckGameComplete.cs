using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameComplete : MonoBehaviour
{
    public int NumberOfLevels; //Number of levels to complete
    public GameObject ButtonToDiploma;
    private bool complete;

    void Start()
    {
        complete = true;
        for(int i = 1; i <= NumberOfLevels; i++) //Check all levels
        {
            if (PlayerPrefs.GetInt("LevelComplete" + i) != 0) //If levels are complete, print complete
            {
                print("level" + i + "complete");
            }
            else
            {
                print("level" + i + "not complete"); //If levels are not complete, print not complete and make variable complete false
                complete = false;
            }
        }

        if (complete == true) //Only if all levels are completed, button appears that navigates player to diploma
        {
            if (!(ButtonToDiploma.activeSelf))
            {
                ButtonToDiploma.SetActive(true);
            }
        }

    }
}

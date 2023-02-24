using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelComplete2 : MonoBehaviour
{
    public GameObject[] Lines;
    private bool MadeIt; //Variable for checking level complete
    void Update()
    {
        MadeIt = true;
        for (int i = 0; i < Lines.Length; i++)
        {
            if (!(Lines[i].activeSelf)) //If all lines are active, madeit is never made false
            {
                MadeIt = false;
            }
        }
        if (MadeIt == true)
        {
            GetComponent<SceneLoader>().LoadScene(); //Then next scene is loaded
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosseLevelsController : MonoBehaviour
{
    public string sLevelToLoad; //Name of level to load+
    public static Boolean backTolevelSelect;

    public void LoadScene()
    {
        backTolevelSelect = true;
        if (sLevelToLoad != null && sLevelToLoad != "")
        {
            print("Loaded scene: " + sLevelToLoad);
            SceneManager.LoadScene(sLevelToLoad); //Load scene with this name
        }
        else
        {
            print("Cannot find scene");
        }
    }
}
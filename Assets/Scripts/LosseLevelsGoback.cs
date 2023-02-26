using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosseLevelsGoback : MonoBehaviour
{
    public string sLevelToLoad; //Name of level to load+

    public void LoadScene()
    {
        LosseLevelsController.backTolevelSelect = false;
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sLevelToLoad; //Name of level to load

    public void LoadScene()
    {
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
    public void BackToLosseLevels()
    {
        if (!LosseLevelsController.backTolevelSelect)
        {
            LoadScene();
        }
        else
        {
            string LevelSelect = "LosseLevels";
            if (LevelSelect != null && LevelSelect != "")
            {
                print("Loaded scene: " + LevelSelect);
                SceneManager.LoadScene(LevelSelect); //Load scene with this name
            }
            else
            {
                print("Cannot find scene");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputToScript : MonoBehaviour
{
    public Text inputText;
    public Text loadedName;

    void Start()
    {
        if (loadedName != null) //If a variable is attached, show name here
        {
            loadedName.text = PlayerPrefs.GetString("name" , "none");
        }
    }

    public void SetName()
    {
        if (string.IsNullOrEmpty(inputText.text )) //If text isnt empty, save name and load scene
        {
            print("geen naam ingevuld");
        }
        else
        {
            PlayerPrefs.SetString("name" , inputText.text);
            GetComponent<SceneLoader>().LoadScene();
        }
    }
}

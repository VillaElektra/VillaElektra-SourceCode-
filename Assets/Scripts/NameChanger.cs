using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameChanger : MonoBehaviour
{
    public Text txt;

    void Start() //Change name to saved name
    {
        txt.text = txt.text.Replace("<naam>", PlayerPrefs.GetString("name" , "collega"));
    }
}

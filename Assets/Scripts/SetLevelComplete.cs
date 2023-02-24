using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevelComplete : MonoBehaviour
{
    public int Level;
    public void SetToComplete()
    {
        PlayerPrefs.SetInt("LevelComplete" + Level, (true ? 1 : 0));
    }
}

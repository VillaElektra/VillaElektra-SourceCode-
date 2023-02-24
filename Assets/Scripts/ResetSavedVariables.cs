using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSavedVariables : MonoBehaviour
{
    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}

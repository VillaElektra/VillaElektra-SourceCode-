using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCode : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        print("Quit game");
    }
}

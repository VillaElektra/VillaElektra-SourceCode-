using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelComplete : MonoBehaviour
{
    public GameObject[] cards;
    private bool Correct;

    void Update()
    {
        Correct = true;
        for (int i = 0; i < cards.Length; i++) //Check if alle dropelements are locked, if 1 is not, 'correct' is false
        {
            if (cards[i].GetComponent<DragAndDrop>().locked == false)
            {
                Correct = false;
            }
        }
        if (Correct == true) //If correct is true, load next scene
        {
           GetComponent<SceneLoader>().LoadScene();
        }
    }
}

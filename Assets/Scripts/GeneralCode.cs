using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralCode : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //If escape is pressed, load scene
        {
            GetComponent<SceneLoader>().LoadScene();
        }
    }
}

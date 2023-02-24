using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableToLevel : MonoBehaviour
{
    public GameObject player;
    private float distance;
    public float minDistance; //Minimal distance for interaction
    //public GameObject Stars;
    public GameObject Spacebar;

    void Update()
    {
        distance = Vector2.Distance(this.transform.position,player.transform.position);
        if (distance < minDistance) //If distance is smaller than minimal distance
        {
            /*if (Stars != null)
            {
                if (Stars.activeInHierarchy == false)
                {
                    Stars.SetActive(true); //Show stars
                }
            }*/
            if (Spacebar.activeInHierarchy == false)
            {
                Spacebar.SetActive(true); //Show spacebar
            }
            if (Input.GetKeyDown("space")) //If spacebar is pressed, load next scene
            {
                GetComponent<SceneLoader>().LoadScene();
            }
        }
        else
        {
            /*if (Stars != null)
            {
                if (Stars.activeInHierarchy == true)
                {
                    Stars.SetActive(false); //Do not show stars
                }
            }*/
            if (Spacebar.activeInHierarchy == true)
            {
                Spacebar.SetActive(false); //Do not show spacebar
            }
        }
    }
}

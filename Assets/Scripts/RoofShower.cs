using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoofShower : MonoBehaviour
{
    public Image image; //Roof
    public GameObject player; //Player

    void OnTriggerEnter2D (Collider2D other) //Enable roof on entry
    {
        if (other.gameObject == player) 
        {
            image.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) //Disable roof on exit
    {
        if (other.gameObject == player) 
        {
            image.enabled = true;
        }
    }
}

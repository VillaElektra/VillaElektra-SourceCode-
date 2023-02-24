using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doorscript : MonoBehaviour
{
    public int LevelRequirement; //this level is required to be completed
    private bool state; //Open or closed
    public Rigidbody2D door;
    Quaternion startRotation; //Starting rotation of door
    Vector3 startPosition; //Starting position of door
    public Image img; //Lock image


    void Start() //Save starting position en rotation
    {
        startRotation = transform.rotation;
        startPosition = transform.position;
    }
    void Update()
    {
        state = (PlayerPrefs.GetInt("LevelComplete" + LevelRequirement) != 0); //Determine state based on saved variable of completed levels

        if (state == false) //Door close
        {
            door.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; //Freeze door
            transform.rotation = startRotation; //Reset position
            transform.position = startPosition; //Reset rotation
            img.enabled = true; //Enable locked image
        }
        else
        {
            door.constraints = RigidbodyConstraints2D.None; //No contraints
            img.enabled = false; //Disable locked image
        }
    }
}

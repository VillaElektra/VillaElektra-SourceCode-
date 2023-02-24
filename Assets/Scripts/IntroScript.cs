using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{

    public Animator animator;
    public GameObject player;
    public AudioSource playSound;
    private bool once = true;

    void Update()
    {
        if (!PlayerPrefs.HasKey("lastKnownPositionX") && !PlayerPrefs.HasKey("lastKnownPositionY")) //If there are no previous saved positions, this is the first time scene is loaded
        {
            if (once)
            {
                playSound.Play(); //Play intro truck sound
                once = false;
            }
            animator.SetBool("IntroPlayed", false); //Let animator know, intro has never been played
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) //If intro animation is done, spawn player
            {
                player.SetActive(true); //Activate player
            }
        }
        else
        {
            animator.SetBool("IntroPlayed", true); //Let animator know, intro has been played
            player.SetActive(true); //Activate player
        }
    }
}

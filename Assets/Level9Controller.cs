using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Level9Controller : MonoBehaviour
{
    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;
    public GameObject paper4;
    public InputField input3;
    public InputField input4;

    public AudioSource playSoundGood;
    public AudioSource playSoundFalse;
    public int level;

    void Start()
    {
        paper1.SetActive(true);
        paper2.SetActive(false);
        paper3.SetActive(false);
        paper4.SetActive(false);
    }

    public void Good()
    {
        print("good");
        ScoreHandler.ScorePlus(level); //Increase the score
        playSoundGood.Play(); //Play good answer sound
        GameObject GoodBad = GameObject.Find("GoodBadAnswer");
        Animator animator = GoodBad.GetComponent<Animator>();
        animator.SetTrigger("Good"); //Play good animation

        // Open the next question or end the level 
        if (paper1.activeSelf)
        {
            paper1.SetActive(false);
            paper2.SetActive(true);
        }
        else if (paper2.activeSelf)
        {
            paper2.SetActive(false);
            paper3.SetActive(true);
        }
        else if (paper3.activeSelf)
        {
            paper3.SetActive(false);
            paper4.SetActive(true);
        }
        else if (paper4.activeSelf)
        {
            GetComponent<SceneLoader>().LoadScene();
        }
    }

    public void Bad()
    {
        print("bad");
        ScoreHandler.ScoreMin(level); //Decrease the score
        playSoundFalse.Play(); //Play bad answer sound
        GameObject GoodBad = GameObject.Find("GoodBadAnswer");
        Animator animator = GoodBad.GetComponent<Animator>();
        animator.SetTrigger("Bad"); //Play bad animation
    }

    public void InputChecker()
    {
        // Check if the input is the correct input
        if (paper3.activeSelf)
        {
            string result = input3.text;

            if (result == "10")
            {
                Good();
            }
            else
            {
                Bad();
            }

            input3.text = "";
        }
        else if (paper4.activeSelf)
        {
            string result = input4.text;

            if (result == "30")
            {
                Good();
            }
            else
            {
                Bad();
            }

            input4.text = "";
        }
    }
}

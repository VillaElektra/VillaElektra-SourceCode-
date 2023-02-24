using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CheckOption : MonoBehaviour
{
    public AudioSource GoedGeluid;
    public AudioSource FoutGeluid;

    private GameObject GoodBad;
    private Animator animator;

    public int level;
    private int Guesses;

    void Start()
    {
        Guesses = 3;
        GoodBad = GameObject.Find("GoodBadAnswer");
        animator = GoodBad.GetComponent<Animator>(); //Find animator
    }




    public void BadOption()
    {
        FoutGeluid.Play(); //Play bad sound
        animator.SetTrigger("Bad"); //Play bad animation
        Guesses -= 1; //One guess is used
    }

    public void GoodOption()
    {
        GoedGeluid.Play(); //Play good sound
        animator.SetTrigger("Good"); //Play good animation
        
        if (Guesses > 0)
        {
            for(int i = 0; i < Guesses; i++) //Number of guesses left times the increase scoe
            {
                ScoreHandler.ScorePlus(level);
            }
        }
        // this.GetComponent<SceneLoader>().LoadScene(); //Load next scene
        SceneManager.LoadScene("Level8Compleet");
    }

}

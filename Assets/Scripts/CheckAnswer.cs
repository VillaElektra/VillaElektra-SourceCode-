using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CheckAnswer : MonoBehaviour
{
    public AudioSource GoedGeluid;
    public AudioSource FoutGeluid;
    public InputField input;
    public string Answer1;
    public string Answer2;
    public int level;
    private int Guesses;

    void Start()
    {
        Guesses = 3;
    }

    void Update()
    {
        GameObject GoodBad = GameObject.Find("GoodBadAnswer");
        Animator animator = GoodBad.GetComponent<Animator>(); //Find animator
        
        if (Input.GetKeyDown(KeyCode.Return)) //If enter is pressed
        {
            if (input.text == Answer1 || input.text ==Answer2) //If input is equal to one of two answers
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
                GetComponent<SceneLoader>().LoadScene(); //Load next scene
            }
            
            else //Not good answer
            {
                FoutGeluid.Play(); //Play bad sound
                animator.SetTrigger("Bad"); //Play bad animation
                Guesses -= 1; //One guess is used
            }
        }
    }

}

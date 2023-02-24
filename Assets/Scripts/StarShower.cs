using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarShower : MonoBehaviour
{
    public int level;
    public enum List //Choice in editor
    {
        LastScore, 
        HighScore, 
    };
    public List BasedOn;
    public int MaxScore; //Maximum score
    public int Min2Star; //Minimum score for 2 stars
    public int Min1Star; //Minimum score for 1 star
    private int Score;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    void Start()
    {

        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
    }

    void Update()
    {
        if (BasedOn == List.LastScore)
        {
            Score = PlayerPrefs.GetInt("Score" + level);
        }
        else if (BasedOn == List.HighScore)
        {
            Score = PlayerPrefs.GetInt("HighScore" + level);
        }

        if (Score >= MaxScore) //3 stars
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
        else if (Score >= Min2Star) //2 stars
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
        }
        else if (Score >= Min1Star) // 1 star
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
        }
        else //0 stars
        {
            Star1.SetActive(false);
            Star2.SetActive(false);
            Star3.SetActive(false);
        }
    }
}

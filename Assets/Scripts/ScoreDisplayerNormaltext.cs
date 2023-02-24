using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayerNormaltext : MonoBehaviour
{
    public int level; //Score of this level
    public string tekst; //Tekst in txt
    public enum List //Choice in editor
    {
        LastScore,
        HighScore,
    };
    public List BasedOn;
    public Text txt;
    private int Score;

    void Update()
    {
        if (BasedOn == List.LastScore) //Show last score
        {
            Score = PlayerPrefs.GetInt("Score" + level); //Get saved variable
        }
        else if (BasedOn == List.HighScore) //Show high score
        {
            Score = PlayerPrefs.GetInt("HighScore" + level); //Get saved variable
        }
        txt.text = (tekst + Score.ToString()); //Put tekst and score in the txt
    }
}

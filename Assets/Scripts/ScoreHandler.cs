using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static int[] Score; //Score[0] is total, Score[1] is level 1, Score[2] is level 2, etc.
    public static int[] HighScore; //HighScore[0] is total, HighScore[1] is level 1, HighScore[2] is level 2, etc.
    private static int ValueScorePlus_s;
    private static int ValueScoreMin_s;
    public int ValueScorePlus;
    public int ValueScoreMin;
    public int levelNumber;
    public bool resetScore;
    

    void Start()
    { 
        Score = new int[10];
        HighScore = new int[10];

        for(int i = 0; i < Score.Length; i++)
        {
            if (PlayerPrefs.HasKey("Score" + i)) //If there are scores saved, get them
            {
                Score[i] = PlayerPrefs.GetInt("Score" + i);
            }
            else //Else set scores to zero
            {
                Score[i] = 0;
            }

            if (PlayerPrefs.HasKey("HighScore" + i)) //If there are Highscores saved, get them
            {
                HighScore[i] = PlayerPrefs.GetInt("HighScore" + i);
            }
            else //Else set scores to zero
            {
                HighScore[i] = 0;
            }
        }
        if (resetScore == true)
        {
            Score[levelNumber] = 0; //if a level is started, reset score of current level
        }
    }

    void Update()
    {
        ValueScorePlus_s = ValueScorePlus;
        ValueScoreMin_s = ValueScoreMin;

        Score[0]=0;
        for(int i = 1; i < Score.Length; i++) //Calculate total score;
        {
            Score[0] += Score[i];
        }

        for(int i = 0; i < Score.Length; i++) //Check for new highscore
        {
            if (Score[i] > HighScore[i])
            {
                HighScore[i] = Score[i];
            }
        }
    }
    public static void ScorePlus(int i) //Increase score
    {
        Score[i] += ValueScorePlus_s;
    }
    public static void ScoreMin(int i) //Descrease score
    {
        Score[i] += ValueScoreMin_s;
    }

    public static void ResetScore(int i) //Reset score
    {
        Score[i] = 0;
    }

    void OnDisable() //If scene is closed
    {
        for(int i = 0; i < Score.Length; i++) //Save all scores
        {
            PlayerPrefs.SetInt("Score" + i, Score[i]);
            PlayerPrefs.SetInt("HighScore" + i, HighScore[i]);
        }
    }
}

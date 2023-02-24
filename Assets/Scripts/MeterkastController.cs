using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeterkastController : MonoBehaviour
{
    [Header("The Switches")]
    [SerializeField] private GameObject Switch1;
    [SerializeField] private GameObject Switch2;
    [SerializeField] private GameObject Switch3;
    [SerializeField] private GameObject Switch4;
    [SerializeField] private GameObject Switch5;
    [SerializeField] private GameObject Switch6;
    [SerializeField] private GameObject Switch7;
    [SerializeField] private GameObject Switch8;
    [SerializeField] private GameObject HoofdSchakkelaar;

    [Header("The Switches' bools")]
    [SerializeField] public static bool isSwitch1Off;
    [SerializeField] public static bool isSwitch2Off;
    [SerializeField] public static bool isSwitch3Off;
    [SerializeField] public static bool isSwitch4Off;
    [SerializeField] public static bool isSwitch5Off;
    [SerializeField] public static bool isSwitch6Off;
    [SerializeField] public static bool isSwitch7Off;
    [SerializeField] public static bool isSwitch8Off;
    [SerializeField] public static bool isHoofdSchakkelaarOn;

    [Header("Misc")]
    [SerializeField] public static List<bool> CurrentStateSwitches;
    [SerializeField] public static int CurrentLevel;
    [SerializeField] private Text InfoText;

    // Start is called before the first frame update
    void Start()
    {
        LevelSetup();
    }
    /// <summary>
    /// FlipSwitch 1-8 and the flip hoofdschakkelaar only turns off the the images
    /// and show the state they are in wheter it be on or off
    /// </summary>
    public void FlipSwitch1()
    {
        switch (isSwitch1Off)
        {
            case true:
                Switch1.SetActive(false);
                break;
            case false:
                Switch1.SetActive(true);
                break;
        }
        isSwitch1Off = !isSwitch1Off;
    }
    public void FlipSwitch2()
    {
        switch (isSwitch2Off)
        {
            case true:
                Switch2.SetActive(false);
                break;
            case false:
                Switch2.SetActive(true);
                break;
        }
        isSwitch2Off = !isSwitch2Off;
    }
    public void FlipSwitch3()
    {
        switch (isSwitch3Off)
        {
            case true:
                Switch3.SetActive(false);
                break;
            case false:
                Switch3.SetActive(true);
                break;
        }
        isSwitch3Off = !isSwitch3Off;
    }
    public void FlipSwitch4()
    {
        switch (isSwitch4Off)
        {
            case true:
                Switch4.SetActive(false);
                break;
            case false:
                Switch4.SetActive(true);
                break;
        }
        isSwitch4Off = !isSwitch4Off;
    }
    public void FlipSwitch5()
    {
        switch (isSwitch5Off)
        {
            case true:
                Switch5.SetActive(false);
                break;
            case false:
                Switch5.SetActive(true);
                break;
        }
        isSwitch5Off = !isSwitch5Off;
    }
    public void FlipSwitch6()
    {
        switch (isSwitch6Off)
        {
            case true:
                Switch6.SetActive(false);
                break;
            case false:
                Switch6.SetActive(true);
                break;
        }
        isSwitch6Off = !isSwitch6Off;
    }
    public void FlipSwitch7()
    {
        switch (isSwitch7Off)
        {
            case true:
                Switch7.SetActive(false);
                break;
            case false:
                Switch7.SetActive(true);
                break;
        }
        isSwitch7Off = !isSwitch7Off;
    }
    public void FlipSwitch8()
    {
        switch (isSwitch8Off)
        {
            case true:
                Switch8.SetActive(false);
                break;
            case false:
                Switch8.SetActive(true);
                break;
        }
        isSwitch8Off = !isSwitch8Off;
    }
    public void FlipHoofdSchakkelaar()
    {
        switch (isHoofdSchakkelaarOn)
        {
            case true:
                HoofdSchakkelaar.SetActive(false);
                break;
            case false:
                HoofdSchakkelaar.SetActive(true);
                break;
        }
        isHoofdSchakkelaarOn = !isHoofdSchakkelaarOn;
    }
    /// <summary>
    /// This method Makes and sets up the list so you can pass it on later to the other levels/ scenes
    /// </summary>
    private void MakeSwitchList()
    {
        CurrentStateSwitches = new List<bool> { false, false, false, false, false, false, false, false, false };
        for (int i = 0; i < CurrentStateSwitches.Count; i++)
        {
            switch (i)
            {
                case 0:
                    CurrentStateSwitches[i] = isSwitch1Off;
                    break;
                case 1:
                    CurrentStateSwitches[i] = isSwitch2Off;
                    break;
                case 2:
                    CurrentStateSwitches[i] = isSwitch3Off;
                    break;
                case 3:
                    CurrentStateSwitches[i] = isSwitch4Off;
                    break;
                case 4:
                    CurrentStateSwitches[i] = isSwitch5Off;
                    break;
                case 5:
                    CurrentStateSwitches[i] = isSwitch6Off;
                    break;
                case 6:
                    CurrentStateSwitches[i] = isSwitch7Off;
                    break;
                case 7:
                    CurrentStateSwitches[i] = isSwitch8Off;
                    break;
                case 8:
                    CurrentStateSwitches[i] = isHoofdSchakkelaarOn;
                    break;
            }
        }
    }
    /// <summary>
    /// This method shows the list that was made above for the switches, un the level for display
    /// </summary>
    private void MakeShowSwitchesState()
    {
        for (int i = 0; i < CurrentStateSwitches.Count; i++)
        {
            switch (i)
            {
                case 0:
                    Switch1.SetActive(CurrentStateSwitches[i]);
                    break;
                case 1:
                    Switch2.SetActive(CurrentStateSwitches[i]);
                    break;
                case 2:
                    Switch3.SetActive(CurrentStateSwitches[i]);
                    break;
                case 3:
                    Switch4.SetActive(CurrentStateSwitches[i]);
                    break;
                case 4:
                    Switch5.SetActive(CurrentStateSwitches[i]);
                    break;
                case 5:
                    Switch6.SetActive(CurrentStateSwitches[i]);
                    break;
                case 6:
                    Switch7.SetActive(CurrentStateSwitches[i]);
                    break;
                case 7:
                    Switch8.SetActive(CurrentStateSwitches[i]);
                    break;
                case 8:
                    HoofdSchakkelaar.SetActive(CurrentStateSwitches[i]);
                    break;
            }
        }
    }
    /// <summary>
    /// This method is sets up the level 
    /// with the static currentlevel variable that the prev method (Scene loader) should be defined before entering this meterkast level 
    /// </summary>
    private void LevelSetup()
    {
        switch (CurrentLevel)
        {
            case 6:
                InfoText.text = "-insert level 6 instructions-";
                break;

            case 7:
                InfoText.text = "LEVEL 7.\r\nSluit de stroom af, schakkel de hoofdschakkelaar uit.";
                MakeShowSwitchesState();
                break;

            case 8:
                InfoText.text = "-insert level 8 instructions-";
                break;

            case 9:
                InfoText.text = "-insert level 9 instructions-";
                break;

            case 10:
                InfoText.text = "-insert level 10 instructions-";
                break;
        }
    }    
    /// <summary>
    /// This method is sets up the list so you can pass it on later to the other levels/ scenes
    /// </summary>
    public static void SetupList(List<bool> List)
    {
        if (List != null)
        {
            CurrentStateSwitches = new List<bool>();
            for (int i = 0; i < List.Count; i++)
            {
                CurrentStateSwitches.Add( List[i] );
            }
        }
    }
    /// <summary>
    /// This method is takes you back to the level you came from
    /// </summary>
    public void BackToLevel()
    {
        switch (CurrentLevel)
        {
            case 6:
                LoadScene("Level6");
                break;
            case 7:
                MakeSwitchList();
                Level7Controller.WentToTurnOffPower = true;
                Level7Controller.UpdateSwitches();
                LoadScene("Level7");
                break;
            case 8:
                LoadScene("Level8");
                break;
            case 9:
                LoadScene("Level9");
                break;
            case 10:
                LoadScene("Level10");
                break;
        }
    }
    /// <summary>
    /// This method is a scene loader that takes you to the scene written in
    /// works in conjuction with the method above
    /// </summary>
    private void LoadScene(string sLevelToLoad)
    {
        if (sLevelToLoad != null && sLevelToLoad != "")
        {
            print("Loaded scene: " + sLevelToLoad);
            SceneManager.LoadScene(sLevelToLoad); //Load scene with this name
        }
        else
        {
            print("Cannot find scene");
        }
    }
}

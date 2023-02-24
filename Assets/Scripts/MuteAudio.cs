using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public Toggle sound;
    //public AudioListener audio1;

    void Start()
    {
        sound.isOn = (PlayerPrefs.GetInt("Sound") != 0); //Get state of sound
    }

    public void ToggleChange()
    {
        if (sound.isOn == false) //Its reverse
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    void OnDisable() //If scene is closed save current state of sound
    {
        PlayerPrefs.SetInt("Sound", (sound.isOn ? 1 : 0));
    }
}

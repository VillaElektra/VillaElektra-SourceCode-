using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    public int NumberToPlay;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start ()
    {
        Play(sounds[NumberToPlay].name);
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is niet gevonden!");
            return;
        }
        s.source.Play();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Diploma")
        {
            sounds[NumberToPlay].source.Stop();
        }
        else
        {
            if (!sounds[NumberToPlay].source.isPlaying)
            {
                sounds[NumberToPlay].source.Play();
            }
        }
    }
}

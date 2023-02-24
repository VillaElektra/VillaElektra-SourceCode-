using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource playSound;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.name == other.name)
        {
            playSound.Play();
        }
    }
}

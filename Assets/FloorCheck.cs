using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    private int floor;
    public GameObject floor1;
    public GameObject floor2;
    // Update is called once per frame
    void Start()
    {
        if (PlayerPrefs.HasKey("floor"))
        {
            floor = PlayerPrefs.GetInt("floor");
        }
        else
        {
            PlayerPrefs.SetInt("floor", 0);
            floor = 0;
        }

        if (floor == 0)
        {
            floor1.SetActive(true);
            floor2.SetActive(false);
        }
        else if (floor == 1)
        {
            floor1.SetActive(false);
            floor2.SetActive(true);
        }
    }
}

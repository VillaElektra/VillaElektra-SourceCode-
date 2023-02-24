using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideController : MonoBehaviour
{
    public GameObject[] slide;
    public GameObject[] text;
    public static int length;
    public static int show;

    void Start()
    {
        show = 1;
        length = slide.Length;
    }

    void Update()
    {
        for (int i = 0; i < length; i++) //Only show the slide with number of 'show'
        {
            if (i != show)
            {
                slide[i].GetComponent<Image>().enabled = false; //Dont show other slide images
                text[i].SetActive(false); //Dont show other slide texts
            }
            else
            {
                slide[i].GetComponent<Image>().enabled = true; //Show current slide image
                text[i].SetActive(true); //Show current slide text
            }
        }

        if (slide[length - 1].GetComponent<Image>().enabled == true) //If last slide is reached, load next scene
        {
            GetComponent<SceneLoader>().LoadScene();
        }
    }

    public static void PlusOne() //Next slide
    {
        if (show < length)
        {
            show += 1;
        }
    }

}

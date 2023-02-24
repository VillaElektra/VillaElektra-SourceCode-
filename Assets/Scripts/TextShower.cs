using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShower : MonoBehaviour
{
    public string[] tekst;
    public Text txt;
    private int number;
    public GameObject arrow;
    private string test;
    public GameObject SymboolCollega;
    public GameObject SymboolKlus;

    void Start()
    {
        number = 0;
    }
    void Update()
    {
        txt.text = tekst[number];
        txt.text = txt.text.Replace("<naam>", PlayerPrefs.GetString("name" , "collega"));
        SymbolShower();
    }

    public void AddOne()
    {
        if (number < (tekst.Length - 1)) //show next text
        {
            number += 1;
        }
        else 
        {
            number = 0; 
        }
        if (tekst.Length-number == 1) //If last text, show arrow to villa elektra
        {
            arrow.SetActive(true);
        }
    }

    public void SymbolShower()
    {
        if (number == 4)
        {
            SymboolCollega.SetActive(true);
        }
        else
        {
            SymboolCollega.SetActive(false);
        }
        if (number == 6)
        {
            SymboolKlus.SetActive(true);
        }
        else
        {
            SymboolKlus.SetActive(false);
        }
    }
}

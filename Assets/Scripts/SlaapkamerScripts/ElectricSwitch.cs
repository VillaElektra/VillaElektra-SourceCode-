using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricSwitch : MonoBehaviour
{

    public Image component;

    private bool state = true;

    public void ChangState()
    {
        component.gameObject.SetActive(!state);
        state = !state;
    }
}

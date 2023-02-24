using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcButton : MonoBehaviour {

	public Text label;

	public Manager calcManager
	{
		get
		{
			if (_calcManager == null)
				_calcManager = GetComponentInParent<Manager>();
			return _calcManager;
		}
	}
	static Manager _calcManager;


	public void onTapped()
	{
		Debug.Log("Tapped: " + label.text);
		calcManager.buttonTapped(label.text[0]);
	}
}
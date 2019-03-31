using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComboTest : MonoBehaviour {
	//Code Got From: http://wiki.unity3d.com/index.php?title=KeyCombo
	public string[] buttons;
	private int currentIndex = 0; //moves along the array as buttons are pressed

	public float allowedTimeBetweenButtons = .3f; //tweak as needed
	private float timeLastButtonPressed;

	public ComboTest(string[] b)
	{
		buttons = b;
	}

	//usage: call this once a frame. when the combo has been completed, it will return true
	public bool Check()
	{
		Debug.Log ("Index Reset");
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
		{
			Debug.Log ("HIT");
			if (currentIndex < buttons.Length)
			{
				if ((buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1) ||
					(buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == 1) ||
					(buttons[currentIndex] == "left" && Input.GetAxisRaw("Horizontal") == -1) ||
					(buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1) ||
					(buttons[currentIndex] != "down" && buttons[currentIndex] != "up" && buttons[currentIndex] != "left" && buttons[currentIndex] != "right" && Input.GetButtonDown(buttons[currentIndex])))
				{
					timeLastButtonPressed = Time.time;
					currentIndex++;
				}

				if (currentIndex >= buttons.Length)
				{
					currentIndex = 0;
					return true;
				}
				else return false;
			}
		}

		return false;
	}
}

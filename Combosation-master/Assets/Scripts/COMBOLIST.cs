using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COMBOLIST : MonoBehaviour
{
	//Directional inputs one after the other function as xcircles. Ex: down + right is a quartercircle forward, down + right + up is a half circle forward, etc.
	//Abutton, Bbutton, Xbutton, and Ybutton are attached to their respective buttons on an XBox controller
	public static ComboTest RomanceCombo1 = new ComboTest (new string[] {"Abutton", "Abutton", "Bbutton" });
	public static ComboTest RomanceCombo2 = new ComboTest (new string[] {"Abutton", "Xbutton", "down", "right", "Ybutton" });
	public static ComboTest RomanceCombo3 = new ComboTest (new string[] {"Abutton","Abutton","Xbutton","Xbutton","up","right","Abutton"});

	public static ComboTest SincereCombo1 = new ComboTest (new string[] {"Bbutton", "Bbutton", "Ybutton" });
	public static ComboTest SincereCombo2 = new ComboTest (new string[] {"Bbutton", "Bbutton", "up", "left", "Abutton" });
	public static ComboTest SincereCombo3 = new ComboTest (new string[] {"Bbutton","Ybutton","Bbutton","Ybutton","down","right","Bbutton"});

	public static ComboTest JokingCombo1 = new ComboTest (new string[] {"Xbutton", "Xbutton", "Bbutton" });
	public static ComboTest JokingCombo2 = new ComboTest (new string[] {"Xbutton", "Abutton", "down", "up", "Ybutton" });
	public static ComboTest JokingCombo3 = new ComboTest (new string[] {"Xbutton","Xbutton","Abutton","Bbutton","down","right","Xbutton"});

	void Update ()
	{
		/*if (RomanceCombo1.Check ()) {
			// do the falcon punch
			Debug.Log ("I like you");
		}		
		if (RomanceCombo2.Check ()) {
			// do the falcon punch
			Debug.Log ("You're beautiful"); 
		}
		if (RomanceCombo3.Check ()) {
			// do the falcon punch
			Debug.Log ("I LOVE you!"); 
		}

		if (SincereCombo1.Check ()) {
			// do the falcon punch
			Debug.Log ("I wrote you a letter"); 
		}		
		if (SincereCombo2.Check ()) {
			// do the falcon punch
			Debug.Log ("I made you lunch"); 
		}
		if (SincereCombo3.Check ()) {
			// do the falcon punch
			Debug.Log ("I got you flowers"); 
		}

		if (JokingCombo1.Check ()) {
			// do the falcon punch
			Debug.Log ("Did it hurt when you fell from heaven?"); 
		}		
		if (JokingCombo2.Check ()) {
			// do the falcon punch
			Debug.Log ("Are you Wifi 'cause I'm getting a good signal"); 
		}
		if (JokingCombo3.Check ()) {
			// do the falcon punch
			Debug.Log ("I love you, bitch. I'll always be loving you, bitch"); 
		}*/
	}
}


using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ComboJyson : MonoBehaviour {


	public List<Combo> comboList;
	string myJson;
	public int ComboToDo;

	// Use this for initialization
	void Start () {
		//store the file address for convenience
		myJson = "Assets/json/comboList.json";

		//make a list of combos from the json file!
		CreateListFromJson ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
		
//			executeCombo(ComboToDo);

		}
	}



	private bool CreateListFromJson()
	{
		//catch in case it don't work
		try{
			//give us a place to store the next line of json
			string line;

			//create a reader to read the file
			StreamReader jsonReader = new StreamReader(myJson);

			using (jsonReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = jsonReader.ReadLine();

					if (line != null)
					{
						Combo newCombo = JsonUtility.FromJson<Combo>(line);
						comboList.Add(newCombo);
					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				jsonReader.Close();
				return true;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (System.Exception e)
		{
			Debug.Log(e.Message);
			return false;
		}
	}


}

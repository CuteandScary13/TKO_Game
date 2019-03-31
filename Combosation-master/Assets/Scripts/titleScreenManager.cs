using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreenManager : MonoBehaviour {

	float sceneEndTimer = 1f;
	public Animator sceneEndAnim;
	public GameObject sceneEndAnimObject;

	public AudioSource transitionSource;


	bool sceneEnding;
	bool tutNext;
	bool gameNext;

	// Use this for initialization
	void Start () {
		sceneEndAnimObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (sceneEndTimer);
		if (Input.GetKeyDown(KeyCode.Space)) {
			gameNext = true;
			sceneEnding = true;
			transitionSource.Play ();

		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			tutNext = true;
			sceneEnding = true;
			transitionSource.Play ();

		}

		if (sceneEnding == true) {
			sceneEndTimer -= Time.deltaTime;
			sceneEndAnimObject.SetActive (true);
			sceneEndAnim.Play ("screenTransitionOpenAnimation");
			if (sceneEndTimer <= 0) {
				if (tutNext == true) {
					SceneManager.LoadScene ("tutorialScene");
				} else if (gameNext == true) {
					SceneManager.LoadScene ("transitionScene");
				}
			}
		}
	}
}

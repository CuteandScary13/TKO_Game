using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionSceneManager : MonoBehaviour {

	float sceneEndTimer = 1f;
	public Animator sceneEndAnim;
	public GameObject sceneEndAnimObject;

	public AudioSource transitionSource;
	public AudioSource music;

	bool sceneEnding;
	// Use this for initialization
	void Start () {
		sceneEndAnimObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (sceneEndTimer);
		if (Input.GetKeyDown(KeyCode.Space)) {
			sceneEnding = true;
			transitionSource.Play ();
			music.Stop ();
		}

		if (sceneEnding == true) {
			sceneEndTimer -= Time.deltaTime;
			sceneEndAnimObject.SetActive (true);
			sceneEndAnim.Play ("screenTransitionOpenAnimation");
			if (sceneEndTimer <= 0) {
				SceneManager.LoadScene ("MasterScene");
			}
		}
	}
}

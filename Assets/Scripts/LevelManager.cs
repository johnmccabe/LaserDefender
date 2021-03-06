﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int activeSceneBuildIndex;

	void Start () {
		Scene activeScene = SceneManager.GetActiveScene();
		activeSceneBuildIndex = activeScene.buildIndex;
	}

	public void LoadLevel (string name) {
		Debug.Log ("Level load requested for: " + name);
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel () {
		Debug.Log ("activeSceneBuildIndex " + activeSceneBuildIndex);
		SceneManager.LoadScene(++activeSceneBuildIndex);
	}

	public void QuitRequest () {
		Debug.Log ("QuitRequest called");
		Application.Quit ();
	}

	public void BrickDestroyed() {
		LoadNextLevel ();
	}
}

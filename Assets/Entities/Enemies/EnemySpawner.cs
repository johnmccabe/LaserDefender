using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		Instantiate (enemyPrefab, this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		// need as GameObject as Instantiate returns an Object
		GameObject enemy = Instantiate (enemyPrefab, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		enemy.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

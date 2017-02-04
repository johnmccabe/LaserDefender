using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 6f;
	public float height = 3.5f;
	public float formationSpeed = 5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = true;
	private float xmin, xmax;

	// Use this for initialization
	void Start () {
		InitialiseScreenBoundry ();
		SpawnUntilFull ();
	}

	void InitialiseScreenBoundry () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundry = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distanceToCamera));
		Vector3 rightBoundry = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distanceToCamera));
		xmax = rightBoundry.x;
		xmin = leftBoundry.x;
	}

	void SpawnEnemies () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull () {
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		} 
		if (NextFreePosition()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	void OnDrawGizmos () {
		// Note that the z=0f in the Vector 3 is automatically added
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
	
	// Update is called once per frame
	void Update () {
		MoveFormation();

		if (AllMembersDead ()) {
			Debug.Log ("Empty Formation Respawning");
			SpawnUntilFull ();
		}
	}

	void MoveFormation () {
		if (movingRight) {
			transform.position += Vector3.right * formationSpeed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * formationSpeed * Time.deltaTime;
		}

		// check if the formation is exiting the playspace
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		// side whose boundry you check depends on the direction of movement
		if (leftEdgeOfFormation < xmin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		}
	}

	bool AllMembersDead () {
		// Iterate over the children in the formation gameobject
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				// if you find an enemy then return true
				return false;
			}
		}
		return true;
	}

	Transform NextFreePosition () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 15f;
	
	// Update is called once per frame
	void Update () {
		MoveWithKeyboard ();
	}

	void MoveWithKeyboard() {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (speed* Time.deltaTime, 0, 0);
		}
	}
}

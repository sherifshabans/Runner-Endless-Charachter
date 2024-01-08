using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCone : MonoBehaviour {
	Vector3 target;
	void Start () {
		target = new Vector3(transform.position.x, transform.position.y, -20f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlayerManager.isGameStarted || PlayerManager.gameOver) return;
		transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
	}
}

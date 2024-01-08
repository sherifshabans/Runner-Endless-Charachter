using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			PlayerController.forwardSpeed += 1f;
			if (PlayerController.forwardSpeed > 30) PlayerController.forwardSpeed = 30;
			Destroy(gameObject);
			FindObjectOfType<AudioManager>().PlaySound("PowerUps");

		}
	}
}

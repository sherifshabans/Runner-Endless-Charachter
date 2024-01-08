using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(100 * Time.deltaTime, 0, 0);
	}
	private void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Player")
        {
			PlayerManager.numberOfCoins++;
			Destroy(gameObject);
			FindObjectOfType<AudioManager>().PlaySound("Coins");

		}
	}
}

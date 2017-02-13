using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {
	public Rigidbody2D zombie;
	private int counter, frameDelta;
	private float speed;

	// Use this for initialization
	void Start () {
		speed = .04f;
		counter = 1;
		frameDelta = 3;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - speed, transform.position.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Wall")) {
			Destroy (gameObject);
		}
	}
}

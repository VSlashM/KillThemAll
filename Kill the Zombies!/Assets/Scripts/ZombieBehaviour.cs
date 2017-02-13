using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {
	public Rigidbody2D zombie;
	private float speed;

	// Use this for initialization
	void Start () {
		speed = .01f;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x-speed, transform.position.y);
	}
}

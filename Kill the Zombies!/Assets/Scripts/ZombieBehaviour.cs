using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
	public Rigidbody2D zombie;
	public GameObject player;
	public int health;
	private int counter, frameDelta;
	private float speed;
	private PlayerController playerCont;
	// Use this for initialization
	void Start ()
	{
		speed = .04f;
		counter = 1;
		frameDelta = 3;
		zombie.freezeRotation = true;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerCont = player.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (transform.position.x - speed, transform.position.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Wall")) {
			Destroy (gameObject);

		} else if (other.gameObject.CompareTag ("Bullet")) {
			health--;
			playerCont.score++;
			Destroy (other.gameObject);
			if (health == 0) {
				Destroy (gameObject);

			}
		}
	}
}

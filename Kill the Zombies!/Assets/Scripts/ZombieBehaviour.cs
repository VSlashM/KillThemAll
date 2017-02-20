using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
	public Rigidbody2D zombie;
	public GameObject player;
	public int health;
	public float speed;
	private PlayerController playerCont;
	public AudioSource hit, reachedEnd, dead;
	// Use this for initialization
	void Start ()
	{
		speed = .04f;
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
			reachedEnd.Play ();
			playerCont.lives--;
		} else if (other.gameObject.CompareTag ("Bullet")) {
			health--;
			playerCont.score++;
			hit.Play ();
			Destroy (other.gameObject);
			if (health == 0) {
				Destroy (gameObject);
				dead.Play ();
			}
		}
	}
}

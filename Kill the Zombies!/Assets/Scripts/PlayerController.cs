using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D player;
	public int speed;
	private int score, lives, wounds;
	public AudioSource wounded, woundedAgain;
	public SpriteRenderer monsterKiller;
	// Use this for initialization
	void Start ()
	{
		monsterKiller = GetComponent<SpriteRenderer> ();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
		transform.position += move * speed * Time.deltaTime;
		if (Input.GetAxis ("Horizontal") > 0) {
			monsterKiller.flipX = false;

		} else if (Input.GetAxis ("Horizontal") < 0) {
			monsterKiller.flipX = true;
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Monster")) {
			wounds++;
			if (wounds % 2 == 1) {
				wounded.Play ();
				Destroy (other.gameObject);
				lives--;
			} else {
				woundedAgain.Play ();
				Destroy (other.gameObject);
				lives--;
			}
		}
	}
}

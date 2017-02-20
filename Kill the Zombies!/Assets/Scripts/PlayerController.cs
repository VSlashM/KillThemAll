using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D player, bullet;
	public int speed, score, lives, wounds, ammo;
	private int counter;
	public AudioSource wounded, woundedAgain, ammoGet, noAmmo, die;
	public SpriteRenderer monsterKiller;
	public Text livesDisplay, scoreDisplay, ammoDisplay, loseText, winText, restartText, instructions;
	private GameObject monster;
	private ZombieBehaviour zomBehave;
	public Exception e;
	// Use this for initialization
	void Start ()
	{
		ammo = 10;
		monsterKiller = GetComponent<SpriteRenderer> ();
		player.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		counter++;
		livesDisplay.text = "Lives: " + lives;
		scoreDisplay.text = "Score: " + score;
		ammoDisplay.text = "Ammo: " + ammo;
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
		transform.position += move * speed * Time.deltaTime;
		monster = GameObject.FindGameObjectWithTag ("Monster");
		if (counter < 200) {
			instructions.text = "Press space to shoot";
		} else {
			instructions.text = "";
		}
		try {
			zomBehave = monster.GetComponent<ZombieBehaviour> ();
		} catch (Exception e) {
			if (counter > 5000 && lives > 0) {
				win ();
				if (Input.GetKeyDown (KeyCode.R)) {
					restart ();
				}
			}
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			monsterKiller.flipX = false;

		} else if (Input.GetAxis ("Horizontal") < 0) {
			monsterKiller.flipX = true;
		}
		if (Input.GetKeyDown ("space")) {
			if (ammo > 0) {
				ammo--;
				Rigidbody2D ammoClone = (Rigidbody2D)Instantiate (bullet, gameObject.GetComponent<Rigidbody2D> ().transform.position, transform.rotation);
			} else if (ammo <= 0) {
				noAmmo.Play ();
			}
		}
		if (lives <= 0) {
			gameOver ();
			die.Play ();
			if (Input.GetKeyDown (KeyCode.R)) {
				restart ();
			}

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
		if (other.gameObject.CompareTag ("Ammo")) {
			ammo += 10;
			Destroy (other.gameObject);
			ammoGet.Play ();
		}
	}

	void gameOver ()
	{
		die.Play ();
		gameObject.transform.localScale = new Vector3 (0f, 0f, 0f);
		speed = 0;
		loseText.text = "Game Over";
		restartText.text = "Press 'R' to restart";	
	}

	void win ()
	{
		gameObject.transform.localScale = new Vector3 (0f, 0f, 0f);
		speed = 0;
		winText.text = "You Win!";
		restartText.text = "Press 'R' to restart";

	}

	void restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}

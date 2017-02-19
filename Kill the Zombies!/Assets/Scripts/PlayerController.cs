using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D player, bullet;
	public int speed;
	public int score, lives, wounds, ammo;
	public AudioSource wounded, woundedAgain;
	public SpriteRenderer monsterKiller;
	public Text livesDisplay, scoreDisplay, ammoDisplay;
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
		livesDisplay.text = "Lives: " + lives;
		scoreDisplay.text = "Score: " + score;
		ammoDisplay.text = "Ammo: " + ammo;
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
		transform.position += move * speed * Time.deltaTime;
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
				if (lives < 0) {
					Destroy (gameObject);
				}
			} else {
				woundedAgain.Play ();
				Destroy (other.gameObject);
				lives--;
			}
		}
		if (other.gameObject.CompareTag ("Ammo")) {
			ammo += 10;
			Destroy (other.gameObject);
		}
	}
}

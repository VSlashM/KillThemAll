using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGenerator : MonoBehaviour
{
	public Rigidbody2D ammo;
	public int frameDelta, counter, bossSpawn;
	private float posY, posX;
	private Vector3 startPosition;

	// Use this for initialization
	void Start ()
	{
		counter = 1;
		frameDelta = 500;
		posX = gameObject.transform.position.x + -12f;
	}

	// Update is called once per frame
	void Update ()
	{
		counter++;
		posY = Random.Range (-4.0f, 2.0f);
		startPosition = new Vector3 (posX, posY, 0f);
		if (counter % frameDelta == 0) {
			Rigidbody2D ammoClone = (Rigidbody2D)Instantiate (ammo, startPosition, transform.rotation);

		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechGenerator : MonoBehaviour
{
	public Rigidbody2D mech, tank;
	public int frameDelta, counter, bossSpawn;
	private float posY, posX;
	private Vector3 startPosition;

	// Use this for initialization
	void Start ()
	{
		counter = 1;
		frameDelta = 200;
		bossSpawn = 1000;
		posX = gameObject.transform.position.x + 16f;

	}
	
	// Update is called once per frame
	void Update ()
	{
		counter++;
		posY = Random.Range (-4.0f, 2.0f);
		startPosition = new Vector3 (posX, posY, 0f);
		if (counter % frameDelta == 0 && counter % bossSpawn != 0) {
			for (int i = 0; i < Random.Range (1, 5); i++) {
				Rigidbody2D mechClone = (Rigidbody2D)Instantiate (mech, startPosition, transform.rotation);
			}
		}
		if (counter % bossSpawn == 0) {
			Rigidbody2D tankClone = (Rigidbody2D)Instantiate (tank, startPosition, transform.rotation);
		}
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	public float speed;
	public Rigidbody2D bullet;

	// Use this for initialization
	void Start ()
	{
		speed = 1f;
		bullet = gameObject.GetComponent<Rigidbody2D> ();
		bullet.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Wall")) {
			Destroy (gameObject);
		}
	}
}

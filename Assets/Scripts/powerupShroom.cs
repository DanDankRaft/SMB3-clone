using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupShroom : MonoBehaviour {

	public float speed;
	Vector2 currentVelocity; //currentVelocity is always measured in unit vectors. speed is NOT taken into account here
	void OnSideCollision()
	{
		currentVelocity = currentVelocity * -1;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.GetComponent<Player>() != null)
		{
			col.gameObject.GetComponent<Player>().giveHealth(1);
			col.gameObject.GetComponent<Player>().isBigPlayer = true;
			Destroy(gameObject);
		}
	}


	void Start()
	{
		Player player = FindObjectOfType<Player>();
		if(player.transform.lossyScale.x > 0)
			currentVelocity = Vector2.right;
		else
			currentVelocity = Vector2.left;
	}


	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = currentVelocity * speed;
	}
}

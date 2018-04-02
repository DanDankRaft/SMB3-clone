using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : obstacle {

	public Vector2 velocity = Vector2.right;

	public virtual void Movement()
	{
		GetComponent<Rigidbody2D>().velocity = velocity;
	}

	public virtual void 
}

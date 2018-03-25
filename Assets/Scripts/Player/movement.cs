using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public float jumpHeight;
	public float movementSpeed;
	[SerializeField] LayerMask groundedMask;

	[SerializeField] bool isGrounded;
	void Update()
	{
		if(Input.GetButtonDown("Jump") && isGrounded)
			StartCoroutine(Jump());

		if(GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		if(GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
	}

	IEnumerator Jump()
	{
		yield return new WaitForFixedUpdate();
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
	}
	Ray2D[] rays = new Ray2D[2]; 
	void FixedUpdate()
	{
		//Player movement
		GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);

		//Is the player grounded?
		Collider2D col = GetComponent<Collider2D>();

		rays[0] = new Ray2D(new Vector2(col.bounds.min.x, transform.position.y), Vector2.down);
		rays[1] = new Ray2D(new Vector2(col.bounds.max.x, transform.position.y), Vector2.down);
		
		isGrounded = false; //if any of the raycasts hit the ground, than the player is grounded. Otherwise, this stays false
		foreach(Ray2D ray in rays)
		{
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, col.bounds.extents.y+0.05f, groundedMask);
			
			if(hit.collider != null)
			{
				//Debug.Log(hit.collider.name);
				isGrounded = true;
			}
		}
	}
	
}

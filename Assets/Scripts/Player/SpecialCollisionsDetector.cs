using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCollisionsDetector : MonoBehaviour {

	public bool doingHeadCollisions;
	public string headCollisonName;

	public bool doingSideCollisions;
	public string sideCollisionName;
	
	public bool doingLegCollisions;
	public string legCollisionsName;

	Vector3 firstContactPoint;
	Vector3 secondContactPoint;

	void OnCollisionEnter2D(Collision2D col)
	{
		
		Vector3 firstContactPoint = col.contacts[0].point;
		Vector3 secondContactPoint = col.contacts[1].point;

		if(firstContactPoint.y > transform.position.y && doingHeadCollisions) //Head Collision
		{
			 col.gameObject.SendMessage(headCollisonName, SendMessageOptions.DontRequireReceiver); //Sends the message to both the player and the collider it hit.
			 SendMessage(headCollisonName, SendMessageOptions.DontRequireReceiver);
		}

		if(firstContactPoint.y < transform.position.y && doingLegCollisions) //Leg Collision
		{
			col.gameObject.SendMessage(legCollisionsName, SendMessageOptions.DontRequireReceiver);
			SendMessage(legCollisionsName, SendMessageOptions.DontRequireReceiver);
		}

		if(firstContactPoint.x == secondContactPoint.x && doingSideCollisions) //Side Collision
		{
			col.gameObject.SendMessage(sideCollisionName, SendMessageOptions.DontRequireReceiver);
			SendMessage(sideCollisionName, SendMessageOptions.DontRequireReceiver);
		}
	}

	public static double round(double originalNumber, int places)
	{
		float multipliedNumber = (float) (originalNumber*Mathf.Pow(10, places));
		return Mathf.Round(multipliedNumber) / Mathf.Pow(10, places);
	}

}

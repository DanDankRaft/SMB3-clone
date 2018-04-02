using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<Player>() != null)
		{
			col.gameObject.GetComponent<Player>().coins++;
			Destroy(gameObject);
		}
	}
}

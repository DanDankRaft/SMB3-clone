using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class questionBlock : MonoBehaviour {

	public bool isActive = true;
	public bool containsCoin;
	public GameObject contents;


	void PlayerHeadCollision()
	{
		if(isActive)
		{
			if(containsCoin) //If the question mark is supposed to give a coin (not the entity), give coin. Otherwise, give the item in GameObject contents
			{
				Debug.Log("player got a coin");
				FindObjectOfType<Player>().coins++;
			}
			else
			{
				Instantiate(contents, transform.position + Vector3.up, transform.rotation);
			}

			isActive = false;
		}
	}

	[MenuItem("MyDinner/Henlo")]
	static void sayHi()
	{
		Debug.Log("hi");
	}


	void Update()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		if(isActive)
			renderer.sprite =(Sprite) AssetDatabase.LoadAssetAtPath("Assets/materials/qmark.png", typeof(Sprite));
		else
			renderer.sprite =(Sprite) AssetDatabase.LoadAssetAtPath("Assets/materials/empryblock.png", typeof(Sprite));
	}
}

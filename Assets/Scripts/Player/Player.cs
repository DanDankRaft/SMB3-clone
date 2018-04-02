using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public int health;

	public bool isBigPlayer = true;
	public GameObject bigPlayer;
	public GameObject smallPlayer;
	public PlayerState currentState;
	public int coins = 0;


	public void giveHealth(int extraHealth)
	{
		health += extraHealth;
	}

	public void giveDamage(int damage)
	{
		health -= damage;
	}

	void Death()
	{
		Debug.Log("Player died!");
	}

	void Update()
	{
		if(health <= 0)
			Death();

		if(health > 2)
			health = 2;

		if(health == 1 && currentState != PlayerState.small)
		{
			setPlayerState(PlayerState.small);
		}

		if(health == 2 && currentState == PlayerState.small)
		{
			setPlayerState(PlayerState.big);

		}
	}

	public enum PlayerState
	{
		small,
		big,
		tanuki
	}

	public PlayerState setPlayerState(PlayerState newState)
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		BoxCollider2D col = GetComponent<BoxCollider2D>();
		GameObject newStatePrefab;

		switch(newState)
		{
			case PlayerState.small:

				newStatePrefab = smallPlayer;
				break;
			case PlayerState.big:
				//transform.position += Vector3.up;
				newStatePrefab = bigPlayer;
				break;
			default:
				newStatePrefab = smallPlayer; //TODO: add tanuki state later
				break;
		}

		renderer.sprite = newStatePrefab.GetComponent<SpriteRenderer>().sprite;
		//col.size = newStatePrefab.GetComponent<BoxCollider2D>().size;
		col.offset = newStatePrefab.GetComponent<BoxCollider2D>().offset;

		currentState = newState;
		return newState;
	}

	//function created by UnityAnswers user Shaffe. special thanks to him
	public static T CopyComponent<T>(T original, GameObject destination) where T : Component
 	{
     System.Type type = original.GetType();
     Component copy = destination.GetComponent(type);
     System.Reflection.FieldInfo[] fields = type.GetFields();
     foreach (System.Reflection.FieldInfo field in fields)
     {
         field.SetValue(copy, field.GetValue(original));
     }
     return copy as T;
 	}
}

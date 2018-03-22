using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour {

	public int health;

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
		//EditorApplication.isPlaying = false;
	}

	void Update()
	{
		if(health <= 0)
			Death();
	}
}

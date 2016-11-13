using UnityEngine;
using System.Collections;

public class EnemyTerritory : MonoBehaviour
{
	public CircleCollider2D territory;
	GameObject player;
	bool playerInTerritory;

	public GameObject enemy;
	AI_Zombie zombie;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		zombie = enemy.GetComponent <AI_Zombie> ();
		playerInTerritory = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (playerInTerritory == true)
		{
			zombie.MoveZombie ();
		}

		if (playerInTerritory == false)
		{
			zombie.Reset ();
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject == player)
		{
			playerInTerritory = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject == player) 
		{
			playerInTerritory = false;
		}
	}
}
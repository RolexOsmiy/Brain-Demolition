using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public float spawnTime;
	public GameObject enemy;
	public Transform[] spawnPoints;
	public int count;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void Spawn ()
	{
		/* If the player has no health left...
		if(playerHealth.currentHealth <= 0f)
		{
			return;
		}*/

		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		count -= 1;
	}

}

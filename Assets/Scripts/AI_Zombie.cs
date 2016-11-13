using UnityEngine;
using System.Collections;

public class AI_Zombie : MonoBehaviour {

	public Transform target;
	public float speed = 3f;

	void Start () 
	{
		target =  GameObject.FindWithTag("Player").transform;
		Reset ();
	}

	void Update()
	{
		
	}

	public void MoveZombie()
	{
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);
		if (Vector3.Distance(transform.position,target.position)>2f)
		{
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
		}
	}

	public void Reset()
	{
		
	}
}


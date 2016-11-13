using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Character2DTopDown : MonoBehaviour {

	public float speed = 1.5f;
	public float acceleration = 100;
	public Transform FirePoint;
	public Bullet bulletScript;

	private Vector3 direction;
	private Rigidbody2D body;
	private Animator anim;


	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Start () 
	{			
		body = GetComponent<Rigidbody2D>();
		body.freezeRotation = true;
		body.gravityScale = 0;
	}

	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed * acceleration);

		if(Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
		}

		if(Mathf.Abs(body.velocity.y) > speed)
		{
			body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed);
		}
	}

	void LookAtCursor()
	{
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
		lookPos = lookPos - transform.position;
		float angle  = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void Update () 
	{
		direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		LookAtCursor();

		if(Input.GetMouseButtonDown(0))
		{
			float angle  = Mathf.Atan2(FirePoint.right.y, FirePoint.right.x) * Mathf.Rad2Deg;
			Bullet bullet = Instantiate(bulletScript, FirePoint.position, Quaternion.AngleAxis(angle, Vector3.forward)) as Bullet;
			bullet.SetDirection(FirePoint.right);
		}
	}
}
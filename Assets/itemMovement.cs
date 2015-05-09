using UnityEngine;
using System.Collections;

public class itemMovement: MonoBehaviour
{
	private Vector3 direction;
	private float speed;
	
	// Use this for initialization
	void Start ()
	{
		this.direction = new Vector3(1.0f, 0.0f).normalized;
		this.speed = 0.03f;
		Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position += direction * speed;
	}
	void OnCollisionEnter2D(Collision2D other)
	{ if (other.gameObject.tag == "wallRight" || other.gameObject.tag == "wallLeft")
		direction *= -1; //reverse the direction
	}
	
}
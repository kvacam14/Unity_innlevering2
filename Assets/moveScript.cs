using UnityEngine;
using System.Collections;

public class moveScript: MonoBehaviour
{
	private Vector3 direction;
	private float speed;
	
	// Use this for initialization
	void Start ()
	{
		this.direction = new Vector3(-1.0f, 0.0f).normalized;
		this.speed = 0.01f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position += direction * speed;
	}
	void OnCollisionEnter2D(Collision2D other)
	{ if (other.gameObject.tag == "wall")
			direction *= -1; //reverse the direction
		}

}
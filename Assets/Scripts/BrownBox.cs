using UnityEngine;
using System.Collections;

public class BrownBox : MonoBehaviour {
	private float timeLeft = 0.2f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	void back(){
		transform.Translate(0, -0.05f, transform.position.z);
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		
		
		// If the player enters the trigger zone...
		
		
		if(col.gameObject.tag == "Head")
		{
			//Collider2D collider = col.collider;
			
			Vector3 contactPoint = col.contacts[0].point;
			//Vector3 center = collider.bounds.center;
			
			//bool right = contactPoint.x > center.x;
			//bool top = contactPoint.y > center.y;
			if((contactPoint.y-0.02f) <transform.position.y){
				end();
				
			}
		}
		
		/*if(col.gameObject.tag == "Wall")
		{
			Retart();
		}
		if (col.gameObject.tag == "Finish") {
			Destroy (gameObject);
		}*/
	}
	void end(){
		Destroy (gameObject);
	}
}
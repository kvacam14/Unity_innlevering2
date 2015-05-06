using UnityEngine;
using System.Collections;

public class Mbox : MonoBehaviour {
	float timeLeft = 0.2f;
	float startY;
	bool go=false;
	// Use this for initialization
	void Start () {
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (go) {
		

			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				back ();
				go=false;
			}
		}
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
				if(!go){

					end();
				}
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
		timeLeft = 0.2f;
		transform.Translate(0, 0.05f, transform.position.z);
		go = true;
		//Destroy (gameObject);
	}
}

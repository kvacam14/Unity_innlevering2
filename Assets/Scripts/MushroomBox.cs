using UnityEngine;
using System.Collections;

public class MushroomBox : MonoBehaviour {

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

		
		
		if(col.gameObject.tag == "Head")
		{
			
			Vector3 contactPoint = col.contacts[0].point;
		
			if((contactPoint.y-0.02f) <transform.position.y){
				if(!go){
					end();
					col.gameObject.GetComponent<animationMario>().resize ();
				}
			}



		}

	}
	void end(){
		timeLeft = 0.2f;
		transform.Translate(0, 0.05f, transform.position.z);
		go = true;
		//Destroy (gameObject);
	}
}

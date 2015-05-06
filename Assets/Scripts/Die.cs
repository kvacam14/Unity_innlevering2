using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {
	float timeLeft = 1;
	float startY;
	bool go=false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (go) {
			print ("go");
			
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				go=false;
				GameObject.FindGameObjectWithTag("Head").GetComponent<animationMario>().restart();

			}
		}
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		
		
		// If the player enters the trigger zone...
		
		
		if(col.gameObject.tag == "Head"&&go==false)
		{
			col.gameObject.GetComponent<animationMario>().resize();

			end();
		}

	}
	private void end(){

		timeLeft = 1;
		go = true;
	}
}

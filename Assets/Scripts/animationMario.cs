using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class animationMario : MonoBehaviour {

	private Animator animator;

	private bool isGrounded;
	private bool isBig;
	private bool isDead;
	private bool bIsPressed;
	private bool isOnPole;
	private bool isFire;


	void Start () 
    {
		animator = GetComponent<Animator> ();
	}

	private void UpdateAnimator(){
		//Sender inn verdier til variablene
		animator.SetBool ("isGrounded", isGrounded);
		animator.SetBool ("bIsPressed", bIsPressed);
		animator.SetBool ("isDead", isDead);
		animator.SetBool ("isOnPole", isOnPole);
		animator.SetBool ("isBig", isBig);
		animator.SetBool ("isFire", isFire);
		
		animator.SetFloat ("verticalAxis", Input.GetAxis ("Vertical"));
		animator.SetFloat ("horizontalAxis", Input.GetAxis ("Horizontal"));

		//Eksempel for hvordan kalle på trigger.
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			isBig = !isBig;
			animator.SetTrigger("changeSize");
		}
	}

	    
	void Update () 
    {
		UpdateAnimator ();
		Test (); // Q, W, E, R, T + Left Ctrl
	}


	private void Test(){

		//FOR Å SJEKKE DE FORSKJELLIGE ANIMASJONENE
		if (Input.GetKeyDown(KeyCode.W)) 
		{
			isGrounded = !isGrounded;
		}
		
		if (Input.GetKeyDown(KeyCode.E)) 
		{
			isDead = !isDead;
		}
		
		if (Input.GetKeyDown(KeyCode.R)) 
		{
			isOnPole = !isOnPole;
		}
		
		if (Input.GetKeyDown(KeyCode.LeftControl)) 
		{
			bIsPressed = !bIsPressed;
		}
		if (Input.GetKeyUp(KeyCode.LeftControl)) 
		{
			bIsPressed = !bIsPressed;
		}

		if (Input.GetAxis ("Horizontal") < 0) {
			transform.localScale = new Vector3 (-1f, transform.localScale.y, transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (1f, transform.localScale.y, transform.localScale.z);
		}


		if(Input.GetKeyUp (KeyCode.T))
		{
			isFire = !isFire;
		}

		
	}
  
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class animationMario : MonoBehaviour {

	private Animator animator;

	private bool isGrounded;
	private bool isBig;
	public bool isDead;
	private bool bIsPressed;
	private bool isOnPole;
	private bool isFire;
	public float maxSpeed = 1f;


	private bool grounded = false;			// Whether or not the player is grounded.
	public float JumpSpeed = 4f;		// Amount of force added when the player jumps.
	private Transform groundCheck;	
	private Transform groundCheck2;

	public Vector2 startPosition;
	void Start () 
    {
		startPosition=GetComponent<Rigidbody2D> ().position;
		animator = GetComponent<Animator> ();
		transform.Find("big").GetComponent<PolygonCollider2D>().isTrigger=true;
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
			transform.Find("big").GetComponent<PolygonCollider2D>().isTrigger=!isBig;
			
		}
	}
	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		groundCheck2 = transform.Find("groundCheck2");
	}
	    
	void Update () 
    {
		/*if(Input.GetAxis ("Horizontal")<-0.2||Input.GetAxis ("Horizontal")>0.2){
			
			bIsPressed=true;
		}else{
			bIsPressed=false;
		}
		if (GetComponent<Rigidbody2D> ().velocity.x>0.5&&GetComponent<Rigidbody2D> ().velocity.x<-0.5&&Input.GetAxis ("Vertical")<0.9) {
			bIsPressed=false;
		}
		*/

		//isGrounded = Physics2D.Linecast(groundCheck.position, new Vector2(groundCheck.position.x,(float)(groundCheck.position.y-0.01))); 
		isGrounded = Physics2D.Linecast(groundCheck.position, groundCheck2.position);

		//isGrounded
		if (Input.GetButton("Jump"))
		{
			if (isGrounded&&(GetComponent<Rigidbody2D> ().velocity.y<0.01&&GetComponent<Rigidbody2D> ().velocity.y>-0.01))
			{
				//print("isGrounded");
				GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
				isGrounded = false;
			}
		}

		float h = Input.GetAxis ("Horizontal");


		//anim.SetFloat ("Speed", Mathf.Abs (h));
		/*
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed){
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		*/

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (h * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);




		UpdateAnimator ();


		if (h > 0)
		{
			transform.localScale = new Vector3(0.2f, 0.2f, 1);
		}
		else if (h < 0)
		{
			transform.localScale = new Vector3(-0.2f, 0.2f, 1);
		}
		//Test (); // Q, W, E, R, T + Left Ctrl
	}


	private void Test(){
		/*
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
		*/
		/*if (Input.GetAxis ("Horizontal") < 0) {
			transform.localScale = new Vector3 (-1f, transform.localScale.y*0.3f, transform.localScale.z*0.3f);
		} else {
			transform.localScale = new Vector3 (1f, transform.localScale.y*0.3f, transform.localScale.z*0.3f);
		}*/


		/*if(Input.GetKeyUp (KeyCode.T))
		{
			isFire = !isFire;
		}*/

		
	}
	public void restart(){
		print ("reset");
		isDead = false;
		GetComponent<Rigidbody2D> ().position=startPosition;
		GetComponent<Animation>().clip.SampleAnimation(gameObject, 0);
		//animator.StopPlayback ();
		//animator.StartPlayback ();
	}
	public void resize()
	{
		isBig = !isBig;
		animator.SetTrigger ("changeSize");
		transform.Find ("big").GetComponent<PolygonCollider2D> ().isTrigger = !isBig;
		HealthScript playerHealth = this.GetComponent<HealthScript> ();
		if (playerHealth != null)
			playerHealth.Damage (-1);

	}

	public Vector2 pointOfContact;
	
	void OnCollisionEnter2D (Collision2D colliderWeTouched){
		if (colliderWeTouched.gameObject.tag == "enemy"){ //If the tag of the collider we touched is "enemy", then...
			
			pointOfContact = colliderWeTouched.contacts[0].normal; //Grab the normal of the contact point we touched
			
			//Detect which side of the collider we touched
			if (pointOfContact == new Vector2(0,1)){ //touched the top of enemy
				EnemyScript enemy = colliderWeTouched.gameObject.GetComponent<EnemyScript>();
				if (enemy != null){

				HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
				if (enemyHealth != null) enemyHealth.Damage(1);
				}

			}else{
					HealthScript playerHealth = this.GetComponent<HealthScript> ();
					if (playerHealth != null)
						playerHealth.Damage (1); //damage player
				}
			}   
		}
	}

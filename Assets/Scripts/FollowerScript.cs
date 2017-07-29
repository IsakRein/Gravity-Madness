using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FollowerScript : MonoBehaviour {
	public Transform target;
	public float speed = 3f;
	private float assignedSpeed;
	public GameManager GameManager;
	public Player Player;

	private bool gameStarted = false;
	private Vector3 startPosition;

	private Rigidbody2D rb;

	
	void Start () 
	{
		gameStarted = true;
		startPosition = transform.position;
		assignedSpeed = speed;
		
		rb = GetComponent<Rigidbody2D>();
	}
	

	void OnDisable ()	
	{
		transform.position = startPosition;
	}


	// Update is called once per frame
	void Update () 
	{    

        if (GameManager.gravityOption != -1)
        {
        	//move towards the player
        	Vector3 direction = Player.transform.position - transform.position;
     		direction.Normalize();
			rb.velocity = direction * assignedSpeed;
	    }


	    if (Player.goalAnimationBool || Player.isDead) 
	    {
	    	assignedSpeed -= 1.5f * Time.deltaTime;
	    	if (assignedSpeed <= 0) 
	    	{
	    		assignedSpeed = 0;
	    	}
	    	Vector3 direction = Player.transform.position - transform.position;
     		direction.Normalize();
			rb.velocity = direction * assignedSpeed;
	    }

	    else 
	    {
	    	assignedSpeed = speed;
	    }

	    /*
	    
	    if (Player.isDead == true) 
	    {
			rb.velocity = Vector3.zero;
			rb.angularVelocity = 0;
			rb.isKinematic = true;
			rb.Sleep();
	    }

	    else {
	    	rb.isKinematic = false;
			rb.WakeUp();
	    } 

	    */
	}

	public void Reset() 
	{
		if (gameStarted == true) 
		{
			transform.position = startPosition;
			rb = GetComponent<Rigidbody2D>();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = 0;
			assignedSpeed = speed;
		}
	}
}

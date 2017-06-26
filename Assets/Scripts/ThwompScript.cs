using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompScript : MonoBehaviour {
	public float speed;
	private Vector3 currentDirection = Vector3.zero;

	void Start () 
	{
		
	}
	
	void Update() {
		if (currentDirection.Equals(Vector3.zero))
    	{
        	Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        	if (!inputDirection.Equals(Vector3.zero))
        	{
            	currentDirection = inputDirection;
            	this.rigidbody2D.velocity = currentDirection * speed;
        	}
    	}
	}

	void OnCollisionEnter2D(UnityEngine.Collision2D other)
	{
    	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompScript : MonoBehaviour {
	private Rigidbody2D rb;
	public bool direction = true;
	public float speed;
	public float wait;
	public float startWaitTime;
	public float wallWaitTime;

	void Start () 
	{
		wait = startWaitTime;
	}
	
	void Update() 
	{
		wait -= Time.deltaTime;
		
		if (wait <= 0) 
		{
			//left
		    if (direction == true) 
			{
				transform.position += Vector3.left * speed * Time.deltaTime;
			}

			//right
			if (direction == false) 
			{
				transform.position += Vector3.right * speed * Time.deltaTime;
			}
		}
		
	}


	void OnCollisionEnter2D(UnityEngine.Collision2D other)
	{
    	if (other.gameObject.CompareTag("Wall"))
    	{
    		direction = !direction;
    		wait = wallWaitTime;
    	}  
	}
}

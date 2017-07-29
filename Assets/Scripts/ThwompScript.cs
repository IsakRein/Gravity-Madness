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

	private bool directionAtStart;

	private Vector3 startPosition;

    private bool animateEyes = true;
    private bool eyesClosed = false;
    public float timeLeft = 2.0f;
    public float blinkTime = 0.15f;

    private bool gameStarted = false;

	void Start () 
	{
		wait = startWaitTime;
		startPosition = transform.position;
		directionAtStart = direction;
		gameStarted = true;
	}
	

	void OnEnable () 
	{

	}

	


	void OnDisable ()	
	{
		transform.position = startPosition;
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
		TimeManager(); 
	}


	public void Reset () 
	{
		if (gameStarted == true) {
			transform.position = startPosition;
			rb = GetComponent<Rigidbody2D>();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = 0;
			direction = directionAtStart;
			wait = startWaitTime;
		}
	}


	void OnCollisionEnter2D(UnityEngine.Collision2D other)
	{
    	if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Spike"))
    	{
    		direction = !direction;
    		wait = wallWaitTime;
    	} 
    	if (other.gameObject.CompareTag("Player"))
    	{
    		wait = 1000;
    	}  
	}


	void SwitchEyes()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Eyes")
            {
                child.gameObject.SetActive(eyesClosed);
            }
        }

        foreach (Transform child in transform)
        {
            if (child.name == "Eyes2")
            {
                child.gameObject.SetActive(!eyesClosed);
            }
        }
    }


    void TimeManager()
    {
        if (animateEyes == true) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                if (eyesClosed == false)
                {
                    SwitchEyes();
                    eyesClosed = !eyesClosed;
                }

                blinkTime -= Time.deltaTime;
                if (blinkTime < 0)
                {
                    SwitchEyes();
                    timeLeft = 3.0f;
                    blinkTime = 0.15f;
                    eyesClosed = !eyesClosed;
                }
            }
        } 
    }
}

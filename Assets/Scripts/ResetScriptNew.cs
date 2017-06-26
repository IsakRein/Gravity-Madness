using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScriptNew : MonoBehaviour {
	public Vector3 startPosition;
	private Rigidbody2D rb;

	public otherScript otherScript;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void OnEnable () 
	{
		startPosition = transform.position;
	}

	void OnDisable ()
	{
		transform.position = startPosition;
	}
	
	public void Reset () 
	{
		transform.position = startPosition;
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0;
	}
}

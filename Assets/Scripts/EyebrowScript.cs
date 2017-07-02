using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyebrowScript : MonoBehaviour {
	public Transform target;
	Quaternion rotation;

	void Awake()
	{
	   rotation = transform.rotation;
	}
	
	void Update () 
	{
		transform.position = target.position + new Vector3 (0, 0.24f, 0);
	}

	void LateUpdate()
	{
	    transform.rotation = rotation;
	}
}

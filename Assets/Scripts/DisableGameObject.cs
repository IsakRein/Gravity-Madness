using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour {
	public GameObject obj;

	void Disable () 
	{
		obj.SetActive(false);
	}
}
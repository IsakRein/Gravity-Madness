using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravitySwitchAnim : MonoBehaviour {
	private Animator GravityAnimator;
	private SpriteRenderer SpriteR;
	public string str;
	
	void Start() 
	{
		Time.timeScale = 1; 
		GravityAnimator = gameObject.GetComponent<Animator>();
		SpriteR = gameObject.GetComponent<SpriteRenderer>();
	}

	public void Render() 
	{
		SpriteR.enabled = true;
	}

	public void DontRender() 
	{
		SpriteR.enabled = false;	
		GravityAnimator.ResetTrigger(str);
	}
}

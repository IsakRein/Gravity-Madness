using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravitySwitchAnim : MonoBehaviour {
	private Animator GravityAnimator;
	private SpriteRenderer SpriteR;
	public string str;

	public string otherTrig;

	public Animator otherAnim1;
	public Animator otherAnim2;
	public Animator otherAnim3;

	void Start() 
	{
		Time.timeScale = 1; 
		GravityAnimator = gameObject.GetComponent<Animator>();
		SpriteR = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (otherAnim1.GetCurrentAnimatorStateInfo(0).IsName("GravitySwitch")) {
			otherAnim1.SetTrigger(otherTrig);
		}
		if (otherAnim2.GetCurrentAnimatorStateInfo(0).IsName("GravitySwitch")) {
			otherAnim2.SetTrigger(otherTrig);
		}
		if (otherAnim3.GetCurrentAnimatorStateInfo(0).IsName("GravitySwitch")) {
			otherAnim3.SetTrigger(otherTrig);
		}
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour {

	public Animator PopUpAnim;
	public Animator BackgroundAnim;

	public void PopIn() 
	{
		gameObject.SetActive(true);
		PopUpAnim.SetTrigger("PopInTrig");
		BackgroundAnim.SetTrigger("FadeIn");
	}

	public void PopOut() 
	{
		PopUpAnim.SetTrigger("PopOutTrig");	
		BackgroundAnim.SetTrigger("FadeOut");
	}
}


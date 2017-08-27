using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class PackScroll : MonoBehaviour {
	public Text txt;
	public Transform packText;
	public Transform circles;

	public ScrollSnap ScrollSnap;

	public int currentPack;
	public int newPack;

	public Color grey1;
	public Color grey2;	

	private bool textFollow;


	void OnEnable () 
	{
		currentPack = 1;
		DisplayPack(currentPack);

		Vector3 localPos = transform.localPosition;
		localPos.x = 15600;
		transform.localPosition = localPos;

		ScrollSnap.enabled = false;
	}


	void Update () 
	{
		CheckPos();

		if (textFollow) 
		{
			Vector3 packLocalPos = packText.localPosition;
			packLocalPos.x = transform.localPosition.x - 11280;
			packText.localPosition = packLocalPos;
		} 

		else 
		{
			Vector3 packLocalPos = packText.localPosition;
			packLocalPos.x = 0;
			packText.localPosition = packLocalPos;
		}
	}

	void LateUpdate () 
	{
		if (transform.localPosition.x != 15600) 
		{
			ScrollSnap.enabled = true;
		}
	}

	void CheckPos() {
		if (transform.localPosition.x > 15060) {
			newPack = 1;
		} else if (transform.localPosition.x > 13980) {
			newPack = 2;
		} else if (transform.localPosition.x > 12900) {
			newPack = 3;
		} else if (transform.localPosition.x > 11820) {
			newPack = 4;
		} else if (transform.localPosition.x > 10740) {
			newPack = 5;
		} else {
			newPack = 6;
		}
	
		if (transform.localPosition.x < 11280) {
			textFollow = true;
		} else {
			textFollow = false;
		}
		
		if (currentPack != newPack) {
			currentPack = newPack;
			DisplayPack (currentPack);
		}
	}



	void DisplayPack(int pack)
	{
		if (pack != 6) {
			txt.text = "Pack " + pack;
		}
			
		foreach (Transform child in circles.transform) 
		{
			if (child.name == "Circle (" + pack + ")")
            {
                child.gameObject.transform.localScale = new Vector3 (65, 65, 1);
                child.gameObject.GetComponent<SpriteRenderer>().color = grey1;            
            }
            else 
            {
            	child.gameObject.transform.localScale = new Vector3 (50, 50, 1);
                child.gameObject.GetComponent<SpriteRenderer>().color = grey2;  
            }
		}
	}
}

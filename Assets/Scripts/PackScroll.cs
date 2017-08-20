using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackScroll : MonoBehaviour {
	public Text txt;
	public Transform circles;

	public int currentPack;
	public int newPack;

	public Color grey1;
	public Color grey2;	

	void Start () 
	{
		currentPack = 1;
		DisplayPack(currentPack);
	}
	
	void Update () 
	{
		CheckPos();
	}

	void CheckPos() 
	{
		if (transform.localPosition.x > 15060) 
		{
			newPack = 1;
		}
		else if (transform.localPosition.x > 13980) 
		{
			newPack = 2;
		}
		else if (transform.localPosition.x > 12900) 
		{
			newPack = 3;
		}
		else if (transform.localPosition.x > 11820) 
		{
			newPack = 4;
		}
		else if (transform.localPosition.x > 10740) 
		{
			newPack = 5;
		}
		else 
		{
			newPack = 6;
		}

		if (currentPack != newPack) 
		{
			currentPack = newPack;
			DisplayPack(currentPack);
		}
	}

	void DisplayPack(int pack)
	{
		txt.text = "Pack " + pack;

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

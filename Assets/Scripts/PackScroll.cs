using System;
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

	public Transform circle1;
	public Transform circle2;
	public Transform circle3;
	public Transform circle4;
	public Transform circle5;
	public Transform circle6;

    public SpriteRenderer circlespr1;
    public SpriteRenderer circlespr2;
    public SpriteRenderer circlespr3;
    public SpriteRenderer circlespr4;
    public SpriteRenderer circlespr5;
    public SpriteRenderer circlespr6;


	private float localLocalPos;

	private bool textFollow;


	void OnEnable () 
	{
		currentPack = 1;
		txt.text = "Pack " + currentPack;

		Vector3 localPos = transform.localPosition;
		localPos.x = 15600;
		transform.localPosition = localPos;

		ScrollSnap.enabled = false;
	}


	void Update () 
	{
		TextChanger();
		CircleSize();

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





	void TextChanger() {
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
			if (currentPack != 6) {
				txt.text = "Pack " + currentPack;
			};
		}
	}

	void CircleSize() {
		float localPosX = transform.localPosition.x;

		if (15600 > localPosX) {
			if (localPosX > 14520) {
				localLocalPos = (Math.Abs (1080 - (localPosX - 14520))) / 1080;

				float scaleValue1 = 75 - (25 * localLocalPos);
				circle1.localScale = new Vector3 (scaleValue1, scaleValue1, 1);

				float colorValue1 = (51 + (68 * localLocalPos)) / 255;
				circlespr1.color = new Color (colorValue1, colorValue1, colorValue1, 1);

				float scaleValue2 = 50 + (25 * localLocalPos);
				circle2.localScale = new Vector3 (scaleValue2, scaleValue2, 1);

				float colorValue2 = (119 - (68 * localLocalPos)) / 255;
				circlespr2.color = new Color (colorValue2, colorValue2, colorValue2, 1);

			} else if (localPosX > 13440) {
				localLocalPos = (Math.Abs (1080 - (localPosX - 13440))) / 1080;

				float scaleValue1 = 75 - (25 * localLocalPos);
				circle2.localScale = new Vector3 (scaleValue1, scaleValue1, 1);

				float colorValue1 = (51 + (68 * localLocalPos)) / 255;
				circlespr2.color = new Color (colorValue1, colorValue1, colorValue1, 1);

				float scaleValue2 = 50 + (25 * localLocalPos);
				circle3.localScale = new Vector3 (scaleValue2, scaleValue2, 1);

				float colorValue2 = (119 - (68 * localLocalPos)) / 255;
				circlespr3.color = new Color (colorValue2, colorValue2, colorValue2, 1);

			} else if (localPosX > 12360) {
				localLocalPos = (Math.Abs (1080 - (localPosX - 12360))) / 1080;

				float scaleValue1 = 75 - (25 * localLocalPos);
				circle3.localScale = new Vector3 (scaleValue1, scaleValue1, 1);

				float colorValue1 = (51 + (68 * localLocalPos)) / 255;
				circlespr3.color = new Color (colorValue1, colorValue1, colorValue1, 1);

				float scaleValue2 = 50 + (25 * localLocalPos);
				circle4.localScale = new Vector3 (scaleValue2, scaleValue2, 1);

				float colorValue2 = (119 - (68 * localLocalPos)) / 255;
				circlespr4.color = new Color (colorValue2, colorValue2, colorValue2, 1);

			} else if (localPosX > 11280) {
				localLocalPos = (Math.Abs (1080 - (localPosX - 11280))) / 1080;

				float scaleValue1 = 75 - (25 * localLocalPos);
				circle4.localScale = new Vector3 (scaleValue1, scaleValue1, 1);

				float colorValue1 = (51 + (68 * localLocalPos)) / 255;
				circlespr4.color = new Color (colorValue1, colorValue1, colorValue1, 1);

				float scaleValue2 = 50 + (25 * localLocalPos);
				circle5.localScale = new Vector3 (scaleValue2, scaleValue2, 1);

				float colorValue2 = (119 - (68 * localLocalPos)) / 255;
				circlespr5.color = new Color (colorValue2, colorValue2, colorValue2, 1);

			} else if (localPosX > 10200) {
				localLocalPos = (Math.Abs (1080 - (localPosX - 10200))) / 1080;

				float scaleValue1 = 75 - (25 * localLocalPos);
				circle5.localScale = new Vector3 (scaleValue1, scaleValue1, 1);

				float colorValue1 = (51 + (68 * localLocalPos)) / 255;
				circlespr5.color = new Color (colorValue1, colorValue1, colorValue1, 1);

				float scaleValue2 = 50 + (25 * localLocalPos);
				circle6.localScale = new Vector3 (scaleValue2, scaleValue2, 1);

				float colorValue2 = (119 - (68 * localLocalPos)) / 255;
				circlespr6.color = new Color (colorValue2, colorValue2, colorValue2, 1);
			}
		}
	}
}

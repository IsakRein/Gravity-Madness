using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopUp : MonoBehaviour {

	public void SendEmail ()
	{
	  	string email = "info@indigogames.se";
	  	string subject = MyEscapeURL("Gravity Madness Contact");
	  	string body = MyEscapeURL("Please enter your message here:\n________\n\n\n" +
   		"________\n");
  		//Open the Default Mail App
  		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body);
 	}  
	 
	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}

	public void Twitter() 
	{
		Application.OpenURL("https://twitter.com/IsakRein/");	
	}
}

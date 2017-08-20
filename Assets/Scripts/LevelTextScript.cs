using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LevelTextScript : MonoBehaviour {
    private Text txt;
    public int currentLevel;
    public double currentLevel2;
    public double roundedCL;
    public int roundedCL2;
    public RectTransform LevelObj;
    public Vector3 localPos;

    void Start()
    {
        string a = gameObject.transform.parent.transform.name;
        string b = string.Empty;
        
        for (int i = 0; i < a.Length; i++)
        {
            if (Char.IsDigit(a[i])) 
            {
                b += a[i];
            }
        }

        if (b.Length > 0) 
        {
            currentLevel = int.Parse(b);
            currentLevel2 = double.Parse(b);
        }   
 
        localPos = LevelObj.localPosition;
        
        //positioning 
        switch (currentLevel % 10)
        {
            case 1:
            case 6:
            localPos.x = -400;
            break;
            case 2:
            case 7:
            localPos.x = -200;
            break;
            case 3:
            case 8:
            localPos.x = 0;
            break;
            case 4:
            case 9:
            localPos.x = 200;
            break;
            case 5:
            case 0:
            localPos.x = 400;
            break;
        }

        roundedCL = Math.Floor(((currentLevel2-0.1)/5)+1);
        int roundedCL2 = Convert.ToInt32(roundedCL);

        switch (roundedCL2 % 7) 
        {
            case 1 % 7:
            localPos.y = 581;
            break;
            case 2 % 7:
            localPos.y = 381;
            break;
            case 3 % 7:
            localPos.y = 181;
            break;
            case 4 % 7:
            localPos.y = -19;
            break;
            case 5 % 7:
            localPos.y = -219;
            break;
            case 6 % 7:
            localPos.y = -419;
            break;
            case 7 % 7:
            localPos.y = -619;
            break;
        }

        LevelObj.localPosition = localPos;


        txt = gameObject.GetComponent<Text>();
        txt.text = "" + currentLevel;
        txt.fontSize = 125;
        
        txt.text = "" + currentLevel;
    }
}

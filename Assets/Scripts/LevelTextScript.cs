using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LevelTextScript : MonoBehaviour {
    private Text txt;
    public int currentLevel;

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
        }

        txt = gameObject.GetComponent<Text>();
        txt.text = "" + currentLevel;
        txt.fontSize = 125;
    }

    void Update()
    {
        txt.text = "" + currentLevel;
    }
}

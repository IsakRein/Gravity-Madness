using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TextScript : MonoBehaviour {
    public Text txt;
    private int currentLevel = 1;
    public LevelScript Levels;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        currentLevel = Levels.currentLevelScore;
        txt.text = "" + currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = Levels.currentLevelScore;
        txt.text = "" + currentLevel;
    }
}

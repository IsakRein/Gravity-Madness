using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour {
    public string levelName;
    public int currentLevelScore;
    public Vector3 startPosition;
    public LevelScript Levels;
    public Player Player;
    public GameManager GameManager;
    public Text goalText;
    private float TimeLeft;

    public float[] timeArray; 

    void Start () 
    {
        currentLevelScore = Levels.currentLevelScore;
        GoalLoadPos();
    }


    void Update () 
    {
        if (GameManager.gravityOption != -1 && TimeLeft > 0 && timeArray[currentLevelScore] != 0)
        {
            TimeLeft -= Time.deltaTime;
            goalText.text = "" + Mathf.Ceil(TimeLeft);
            if (TimeLeft <= 0)
            {
                Player.Death();   
            }
        }
    }

    public void UpdateTime(int Level) 
    {
        if (timeArray[Level] == 0) 
        {
            goalText.text = "";
            TimeLeft = timeArray[Level];
        }
        
        else 
        {
            TimeLeft = timeArray[Level];
            goalText.text = "" + Mathf.Ceil(TimeLeft);
        }
    }

    public void GoalLoadPos()
    {
        currentLevelScore = Levels.currentLevelScore;
        levelName = "Level (" + currentLevelScore + ")";
        foreach (Transform child in Levels.transform)
        {
            if (child.name == levelName)
            {
                startPosition = child.Find("GoalPos").position;
                transform.position = startPosition;
            }
        }
    }
}

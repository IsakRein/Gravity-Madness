using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
    public string levelName;
    public int currentLevelScore;
    private Vector3 startPosition;
    public LevelScript Levels;

    void Start () {
        currentLevelScore = Levels.currentLevelScore;
        GoalLoadPos();
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

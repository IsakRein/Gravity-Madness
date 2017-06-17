using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {
    public int levelScore;
    public int currentLevelScore;

    public GameObject Game;
    public GameManager GameManager;

    public Player Player;

    public Button left_Button;
    public Button right_Button;
    public Button retry_Button;


    void Start () {
        levelScore = GameManager.levelScore;

        DisplayLevel(currentLevelScore);
         
        left_Button.onClick.AddListener(LeftOnClick);
        right_Button.onClick.AddListener(RightOnClick);
        retry_Button.onClick.AddListener(RetryOnClick);

        if (currentLevelScore == 1)
        {
            left_Button.interactable = false;
        }
        else
        {
            left_Button.interactable = true;
        }

        if (currentLevelScore == levelScore)
        {
            right_Button.interactable = false;
        }
        else
        {
            right_Button.interactable = true;
        }
    }


    void OnEnable()
    {
        DisplayLevel(currentLevelScore);
    }


    void Update()
    {
        MakeButtonInteractable();
    }


    void MakeButtonInteractable()
    {
        if (currentLevelScore == 1)
        {
            left_Button.interactable = false;
        }
        else
        {
            left_Button.interactable = true;
        }

        if (currentLevelScore == levelScore)
        {
            right_Button.interactable = false;
        }
        else
        {
            right_Button.interactable = true;
        }
    }


    public void LeftOnClick()
    {
        currentLevelScore = currentLevelScore - 1;
        DisplayLevel(currentLevelScore);
    }

    public void RightOnClick()
    {
        currentLevelScore = currentLevelScore + 1;
        DisplayLevel(currentLevelScore);
    }


    public void RetryOnClick()
    {
        DisplayLevel(currentLevelScore);
    }


    public void LevelWon()
    {
        currentLevelScore = currentLevelScore + 1;
        DisplayLevel(currentLevelScore);
    }


    public void DisplayLevel (int level)
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Level (" + level + ")")
            {
                child.gameObject.SetActive(true);
            }

            else if (child.name != "Level (" + level + ")")
            {
                child.gameObject.SetActive(false);
            }
        }
        Player.LoadPos();
    }
}

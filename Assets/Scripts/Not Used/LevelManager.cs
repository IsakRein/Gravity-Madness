/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public bool PackWon = false;

    public bool levelWon2 = false;


    public int currentLevel = 1;

    private int amountOfChildren = 0;

    public Button left_Button;
    public Button right_Button;
    public Button retry_Button;

    private void Start()
    {
        displayCurrentLevel();
        countChildren();
        PackWon = false;

        Button leftButton = left_Button.GetComponent<Button>();
        Button rightButton = right_Button.GetComponent<Button>();
        Button retryButton = retry_Button.GetComponent<Button>();

        leftButton.onClick.AddListener(LeftOnClick);
        rightButton.onClick.AddListener(RightOnClick);
        retryButton.onClick.AddListener(RetryOnClick);
    }


    void LeftOnClick()
    {
        currentLevel = currentLevel - 1;
        displayCurrentLevel();
    }


    void RightOnClick()
    {
        if (currentLevel >= amountOfChildren)
        {
            PackWon = true;
        }

        currentLevel = currentLevel + 1;
        displayCurrentLevel();
    }


    void RetryOnClick()
    {
        displayCurrentLevel();
    }


    void Update()
    {
        checkIfLevelWon();
    }


    void checkIfLevelWon()
    {
        if (GameObject.Find("Player 1").GetComponent<Player>().goalReached == true)
        {
            if (currentLevel >= amountOfChildren)
            {
                PackWon = true;
            }

            currentLevel = currentLevel + 1;

            displayCurrentLevel();
        }
    }


    void displayCurrentLevel()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Level (" + currentLevel + ")")
            {
                child.gameObject.SetActive(true);
            }

            else if (child.gameObject.name != "Level " + "(" + currentLevel + ")")
            {
                child.gameObject.SetActive(false);
            }
        }
    }


    void countChildren()
    {
        foreach (Transform child in transform)
        {
            amountOfChildren = amountOfChildren + 1;
        }
    }
}
*/
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackManager : MonoBehaviour {

    public bool PackWon = false;
    public int LevelScore = 1;
    public int PackScore = 1;
    public GameObject GameManager;

    private string currentPackName = ("Pack (1)");
    private int amountOfGrandChildren = 0;

    public Button left_Button;
    public Button right_Button;
    public Button retry_Button;


    void Start()
    {
        countGrandChildren();
        displayCurrentPack();
        displayCurrentLevel();
    }


    void Update()
    {
        checkIfPackWon();
        checkIfLevelWon();
    }


    void checkIfPackWon()
    {
        foreach (Transform child in transform)
        {
            if (child.name == currentPackName)
            {
                if (GetComponentInChildren<LevelManager>().PackWon)
                {
                    PackScore = PackScore + 1;

                    displayCurrentPack();
                }
            }
        }
    }


    void checkIfLevelWon()
    {
        if (GameObject.Find("Player 1").GetComponent<Player>().goalReached == true)
        {
            if (LevelScore >= amountOfGrandChildren)
            {
                PackScore = PackScore + 1;
                countGrandChildren();
            }

            LevelScore = LevelScore + 1;

            displayCurrentLevel();
        }
    }


    void displayCurrentPack ()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Pack (" + PackScore + ")")
            {
                child.gameObject.SetActive(true);
            }

            else if (child.gameObject.name != "Pack " + "(" + PackScore + ")")
            {
                child.gameObject.SetActive(false);
            }
        }
    }


    void displayCurrentLevel()
    {
        foreach (Transform child in GameObject.Find("Pack (" + PackScore + ")").transform)
        {
            if (child.gameObject.name == "Level (" + LevelScore + ")")
            {
                child.gameObject.SetActive(true);
            }

            else if (child.gameObject.name != "Level " + "(" + LevelScore + ")")
            {
                child.gameObject.SetActive(false);
            }
        }
    }


    void countGrandChildren()
    {
        foreach (Transform child in GameObject.Find("Pack (" + PackScore + ")").transform)
        {
            amountOfGrandChildren = amountOfGrandChildren + 1;
        }
    }
}
*/
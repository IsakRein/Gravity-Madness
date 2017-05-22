using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelectScript : MonoBehaviour {
    public int levelScore;
    public int currentLevel;
    public Button btn;
    public GameObject Game;
    public GameObject LevelSelect;

    public GameManager GameManager;

    public LevelScript Levels;

    Image imageComponent;
    public Sprite levelFinished;
    public Sprite levelUnfinished;

    void Start()
    {
        levelScore = GameManager.levelScore;

        imageComponent = GetComponent<Image>();

        string a = gameObject.transform.name;
        string b = string.Empty;
        for (int i = 0; i < a.Length; i++)
        {
            if (Char.IsDigit(a[i]))
                b += a[i];
        }

        if (b.Length > 0)
            currentLevel = int.Parse(b);

        btn.onClick.AddListener(ActivateLevel);

        if (currentLevel > levelScore)
        {
            imageComponent.sprite = levelUnfinished;
            GUI.backgroundColor = Color.clear;
            btn.interactable = false;
        }

        else
        {
            imageComponent.sprite = levelFinished;
            btn.interactable = true;
        }
        

        /*
        if ((currentLevel % 10 == 1) || (currentLevel % 10 == 6))
        {
            transform.position = new Vector3(-1, 0, 0);
        }
        else if ((currentLevel % 10 == 2) || (currentLevel % 10 == 7))
        {
            transform.position = new Vector3(-200, 0, 0);
        }
        else if ((currentLevel % 10 == 3) || (currentLevel % 10 == 8))
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else if ((currentLevel % 10 == 4) || (currentLevel % 10 == 9))
        {
            transform.position = new Vector3(200, 0, 0);
        }
        else
        {
            transform.position = new Vector3(400, 0, 0);
        }
        */
    }

    void OnEnable()
    {
        levelScore = GameManager.levelScore;

        if (currentLevel > levelScore)
        {
            btn.interactable = false;
        }

        else
        {
            btn.interactable = true;
        }
    }


    void ActivateLevel()
    {
        Levels.currentLevelScore = currentLevel;
        Game.gameObject.SetActive(true);
        LevelSelect.gameObject.SetActive(false);
    }
}

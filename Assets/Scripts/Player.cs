﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioSource au_impact;
    public Transform target;
    
    private Vector3 startPosition;
    private Rigidbody2D rb;

    //scripts
    public GameManager GameManager;
    public LevelScript Levels;
    public GoalScript Goal;
    public TextScript LevelText;

    public float speed;

    //levels
    public int levelScore;
    public int currentLevelScore;
    private string levelName;

    //eyes
    public GameObject Eyes;
    public GameObject Eyes2;
    private bool eyesClosed = false;
    public float timeLeft = 1.0f;
    public float blinkTime = 0.1f;

    //goalanimation
    private bool goalAnimationBool = false;
    public float goalAnimationSpeed = 1.0f;
    public Vector2 goalPosition;

    public float smooth = 1f;
    private Quaternion targetRotation;

    //in between levels
    public CanvasGroup canvasGroup;
    public float fadeInTime;
    public float fadeOutTime;
    public float visibleTime;
    private bool InBetweenLevelsBool;
    private bool InBetweenLevelsVisible = false;

    private Vector3 zeroScale = new Vector3 (0, 0, 0);
    private bool transitionLoadLevel = true;    
    private bool transitionDisplayText = true;

    private float transitionTime = 0;
    private float transitionTime2 = 0;
    private float transitionTime3 = 1;

    public Text transitionText; 

    void Start()
    {
        levelScore = GameManager.levelScore;
        currentLevelScore = Levels.currentLevelScore;
        LoadPos();

        targetRotation = transform.rotation;
    }


    void Update()
    {
        TimeManager();
        GoalAnimation();
        InBetweenLevels();
    }


    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            goalAnimationBool = true; 
            InBetweenLevelsBool = true;
        }

        else if (other.gameObject.CompareTag("Spike"))
        {
            LoadPos();
        }
    }



    void GoalAnimation() {
        if (goalAnimationBool == true) {
            GameManager.gravityOption = -1;
            GameManager.controlsEnabled = false;
            float step = goalAnimationSpeed * Time.deltaTime;
            
            //move to middle
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            
            //rotate
            targetRotation *=  Quaternion.AngleAxis(5, Vector3.forward);
            transform.rotation= Quaternion.Lerp (transform.rotation, targetRotation , 10 * smooth * Time.deltaTime); 
            
            //make smaller
            if (transform.localScale.magnitude > zeroScale.magnitude) {
                transform.localScale -= Vector3.one*Time.deltaTime*step;
            }
        }

        if (transform.position == target.position || transform.localScale.magnitude <= zeroScale.magnitude) {
            goalAnimationBool = false;
        }
    }


    public void LoadPos()
    {
        currentLevelScore = Levels.currentLevelScore;
        levelName = "Level (" + currentLevelScore + ")";

        foreach (Transform child in Levels.transform)
        {
            if (child.name == levelName)
            {
                startPosition = child.Find("PlayerPos").position;
                transform.position = startPosition;
            }
        }
        Goal.GoalLoadPos();

        transform.localEulerAngles = new Vector3(0,0,0);
        transform.localScale = new Vector3(0.0165f, 0.0165f, 1f);
        GameManager.gravityOption = -1;

        LevelText.txt.text = "" + currentLevelScore;
    }


    void InBetweenLevels() 
    {
        if (InBetweenLevelsBool == true) {
            
            if (transitionDisplayText == true) {
                int nextLevel = currentLevelScore + 1;
                transitionText.text = "LEVEL " + nextLevel;

                transitionDisplayText = false;
            }
            

            canvasGroup.blocksRaycasts = true;
            //fade in
            if (InBetweenLevelsVisible == false) {
                transitionTime += Time.deltaTime / fadeInTime;
                canvasGroup.alpha = transitionTime;
            }
                
            if (canvasGroup.alpha == 1) {
                InBetweenLevelsVisible = true;

                transitionTime2 += Time.deltaTime / visibleTime;

                if (levelScore == currentLevelScore) {
                    levelScore = levelScore + 1;
                    Levels.levelScore = levelScore;
                    GameManager.levelScore = levelScore;
                    GameManager.UpdateLevel();
                }

                if (transitionLoadLevel == true) {
                    Levels.LevelWon();
                    transitionLoadLevel = false;
                }
            }
                    
            if (transitionTime2 > 1) {

                transitionTime3 -= Time.deltaTime / fadeOutTime;
                canvasGroup.alpha = transitionTime3;
                        
                if (canvasGroup.alpha == 0) {
                    GameManager.controlsEnabled = true;
                    canvasGroup.blocksRaycasts = false;
                    InBetweenLevelsVisible = false;
                    transitionLoadLevel = true;
                    transitionDisplayText = true;
                        
                    transitionTime = 0;
                    transitionTime2 = 0;
                    transitionTime3 = 1;

                    InBetweenLevelsBool = false;
                }
            }
        }
    }


    void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            au_impact.Play();
        }
    }


    void SwitchEyes()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Eyes")
            {
                child.gameObject.SetActive(eyesClosed);
            }
        }

        foreach (Transform child in transform)
        {
            if (child.name == "Eyes2")
            {
                child.gameObject.SetActive(!eyesClosed);
            }
        }

    }


    void TimeManager()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (eyesClosed == false)
            {
                SwitchEyes();
                eyesClosed = !eyesClosed;
            }

            blinkTime -= Time.deltaTime;
            if (blinkTime < 0)
            {
                SwitchEyes();
                timeLeft = 3.0f;
                blinkTime = 0.15f;
                eyesClosed = !eyesClosed;
            }
        }
    }
}
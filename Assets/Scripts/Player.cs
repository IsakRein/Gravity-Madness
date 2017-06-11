using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    public AudioSource au_impact;
    public Transform target;
    public float speed;
    private Vector3 startPosition;
    private Rigidbody2D rb;

    public GameManager GameManager;
    public LevelScript Levels;
    public GoalScript Goal;

    public TextScript LevelText;

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
    private float goalAnimationSpeed = 1.0f;
    public Vector2 goalPosition;

    //in between levels
    public CanvasGroup canvasGroup;
    public float fadeInTime;
    public float fadeOutTime;
    public float visibleTime;
    public bool InBetweenLevelsBool;
    public bool InBetweenLevelsVisible = false;

    float transitionTime = 0;
    public float transitionTime2 = 0;
    float transitionTime3 = 1;

    void Start()
    {
        levelScore = GameManager.levelScore;
        currentLevelScore = Levels.currentLevelScore;
        LoadPos();
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
            //transform.Translate(0, -step * Time.deltaTime, 0, Space.World);
            transform.Rotate(Vector3.forward * step * 50000);
            
            //make smaller
            Vector3 zeroScale = new Vector3(0, 0, 0);
            if (transform.localScale.magnitude > zeroScale.magnitude) {
                transform.localScale -= Vector3.one*Time.deltaTime*step;
            }
        }

        if (transform.position == target.position) {
            goalAnimationBool = false;
            
            InBetweenLevelsBool = true;
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
        
        transform.localScale = new Vector3(0.0165f, 0.0165f, 1f);
        GameManager.gravityOption = -1;

        LevelText.txt.text = "" + currentLevelScore;
    }


    void InBetweenLevels() 
    {
        if (InBetweenLevelsBool == true) {
            canvasGroup.blocksRaycasts = true;
            //fade in
            if (InBetweenLevelsVisible == false) {
                transitionTime += Time.deltaTime * fadeInTime;
                canvasGroup.alpha = transitionTime;

                if (canvasGroup.alpha == 1) {
                    transitionTime2 += Time.deltaTime * visibleTime;

                    if (levelScore == currentLevelScore) {
                        levelScore = levelScore + 1;
                        Levels.levelScore = levelScore;
                        GameManager.levelScore = levelScore;
                        GameManager.UpdateLevel();
                        LoadPos();

                    }
                    Levels.CheckIfWon();

                    if (transitionTime2 > 1) {
                        transitionTime3 -= Time.deltaTime * fadeOutTime;
                        canvasGroup.alpha = transitionTime3;

                        if (canvasGroup.alpha == 0) {
                            GameManager.controlsEnabled = true;
                            canvasGroup.blocksRaycasts = false;
                            InBetweenLevelsBool = false;

                            float transitionTime = 0;
                            float transitionTime2 = 0;
                            float transitionTime3 = 1;
                        }
                    }
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
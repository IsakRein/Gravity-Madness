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
            
            //make smaller
            Vector3 zeroScale = new Vector3(0, 0, 0);
            if (transform.localScale > zeroScale) {
                transform.localScale -= Vector3.one*Time.deltaTime*step;
            }
        }

        if (transform.position == target.position) {
            goalAnimationBool = false;
            if (levelScore == currentLevelScore)
                {
                    levelScore = levelScore + 1;
                    Levels.levelScore = levelScore;
                    GameManager.levelScore = levelScore;
                    GameManager.UpdateLevel();
                }
            Levels.CheckIfWon();
            LoadPos();
            GameManager.controlsEnabled = true;
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
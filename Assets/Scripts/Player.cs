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
    float timeLeft = 1.0f;
    float blinkTime = 0.1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelScore = GameManager.levelScore;
        currentLevelScore = Levels.currentLevelScore;
        LoadPos();
    }


    void Update()
    {
        TimeManager();
    }


    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            NewLevel();
            LoadPos();
        }

        else if (other.gameObject.CompareTag("Spike"))
        {
            LoadPos();
        }
    }


    void NewLevel()
    {
        if (levelScore == currentLevelScore)
        {
            levelScore = levelScore + 1;
            Levels.levelScore = levelScore;
            GameManager.levelScore = levelScore;
            GameManager.UpdateLevel();
        }
        Levels.CheckIfWon();
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

        rb.Sleep();
        rb.isKinematic = true;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
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
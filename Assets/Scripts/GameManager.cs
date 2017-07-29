using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int levelScore;

    public Player Player;
    public Rigidbody2D rb;

    public int gravityOption = -1;

	//public AudioSource au_impact;

    //public Button gravityButtonLeft;
    //public Button gravityButtonRight;

    //playbutton
    public Button playButton;
    public GameObject homeScreenCanvas;
    public GameObject levelSelect;
    public GameObject game;
    public NavScript LevelSelect;

    //swipe
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 10.0f;
    private float maxSwipeTime = 0.5f;

    public bool controlsEnabled = true;


    void Start () {
        game.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(false);
        homeScreenCanvas.gameObject.SetActive(true);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        /*
        gravityButtonLeft.onClick.AddListener(GravityLeft);
        gravityButtonRight.onClick.AddListener(GravityRight);
        */

        playButton.onClick.AddListener(PlayOnClick);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        if (PlayerPrefs.HasKey("levelScorePref"))
        {
            levelScore = PlayerPrefs.GetInt("levelScorePref");
        }

        else
        {
            levelScore = 1;
        }
    }


    void Update()
    {
        SwipeDetect();
        rb.WakeUp();
        rb.isKinematic = false;
        ArrowsControl();
        CheckGravity();

        if (Input.touchCount == 0 && !Input.anyKey && Player.goalAnimationBool == false && Player.InBetweenLevelsBool == false) 
        {
            controlsEnabled = true;
        }
    }

    
    void SwipeDetect ()
    {
        if (Input.touchCount > 0 && controlsEnabled)
        {
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Moved:
                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    gravityOption = 1;
                                }
                                else
                                {
                                    gravityOption = 3;
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    gravityOption = 2;
                                }
                                else
                                {
                                    gravityOption = 0;
                                }
                            }
                        }
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;
                }
            }
            rb.WakeUp();
            rb.isKinematic = false;
        }

    }


    void ArrowsControl()
    {
        if (controlsEnabled == true) {
            if (Input.GetKey("down"))
            {
                gravityOption = 0;
            }
            if (Input.GetKey("left"))
            {
                gravityOption = 3;
            }
            if (Input.GetKey("up"))
            {
                gravityOption = 2;
            }
            if (Input.GetKey("right"))
            {
                gravityOption = 1;
            }
        }
    }


    public void UpdateLevel()
    {
        PlayerPrefs.SetInt("levelScorePref", levelScore);
    }


    /*
    void GravityLeft()
    {
        if (gravityOption != 3)
        {
            gravityOption = gravityOption + 1;
        }
        else
        {
            gravityOption = 0;
        }

        rb.WakeUp();
        rb.isKinematic = false;
    }


    void GravityRight()
    {
        if (gravityOption > 0)
        {
            gravityOption = gravityOption - 1;
        }
        else if (gravityOption == -1)
        {
            gravityOption = 0;
        }
        else
        {
            gravityOption = 3;
        }

        rb.WakeUp();
        rb.isKinematic = false;
    }
    */


    void PlayOnClick()
    {
        homeScreenCanvas.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(true);
    }


    void CheckGravity ()
    {
        //idle
        if (gravityOption == -1)
        {
            rb.Sleep();
            rb.isKinematic = true;
            Physics2D.gravity = new Vector2(0, 0);
        }

        //down
        if (gravityOption == 0)
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
        }

        //right
        if (gravityOption == 1)
        {
            Physics2D.gravity = new Vector2(9.81f, 0);
        }

        //up
        if (gravityOption == 2)
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
        }

        //left
        if (gravityOption == 3)
        {
            Physics2D.gravity = new Vector2(-9.81f, 0);
        }
    }
}

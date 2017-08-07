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

    //animator left
    public Animator animatorLeft;
    public Transform GravitySwitchAnimLeft;
    public Renderer GravitySwitchRendLeft;

    //animator up
    public Animator animatorUp;
    public Transform GravitySwitchAnimUp;
    public Renderer GravitySwitchRendUp;

    //animator right
    public Animator animatorRight;
    public Transform GravitySwitchAnimRight;
    public Renderer GravitySwitchRendRight;

    //animator down
    public Animator animatorDown;
    public Transform GravitySwitchAnimDown;
    public Renderer GravitySwitchRendDown;


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

        GravitySwitchRendLeft.enabled = false;
        GravitySwitchRendUp.enabled = false;
        GravitySwitchRendRight.enabled = false;
        GravitySwitchRendDown.enabled = false;
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
                                    //right
                                    RightGravity();
                                }
                                else
                                {
                                    //left
                                    LeftGravity();
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    //up
                                    UpGravity();
                                }
                                else
                                {
                                    //down
                                    DownGravity();
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
            if (Input.GetKey("left"))
            {
                LeftGravity();
            }
            if (Input.GetKey("up"))
            {
                UpGravity();
            }
            if (Input.GetKey("right"))
            {
                RightGravity();   
            }
            if (Input.GetKey("down"))
            {
                DownGravity();
            }  
        }
    }


    void LeftGravity() 
    {
        if (gravityOption != 3) 
        {
            GravitySwitchRendLeft.enabled = true;
            gravityOption = 3;
            GravitySwitchAnimLeft.transform.rotation = Quaternion.Euler(0, 0, 0);
            animatorLeft.SetTrigger("LeftTrig");
        }
    }


    void UpGravity() 
    {   
        if (gravityOption != 2) 
        {
            GravitySwitchRendUp.enabled = true;
            GravitySwitchAnimUp.transform.rotation = Quaternion.Euler(0, 0, -90);
            animatorUp.SetTrigger("UpTrig");
            gravityOption = 2;
        }
    }


    void RightGravity() 
    {
        if (gravityOption != 1) 
        {
            GravitySwitchRendRight.enabled = true;
            gravityOption = 1;
            GravitySwitchAnimRight.transform.rotation = Quaternion.Euler(0, 0, 180);
            animatorRight.SetTrigger("RightTrig");    
        }    
    }


    void DownGravity() 
    {
        if (gravityOption != 0) 
        {
            GravitySwitchRendDown.enabled = true;
            gravityOption = 0;
            GravitySwitchAnimDown.transform.rotation = Quaternion.Euler(0, 0, 90);
            animatorDown.SetTrigger("DownTrig");
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

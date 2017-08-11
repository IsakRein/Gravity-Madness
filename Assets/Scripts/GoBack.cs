using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoBack : MonoBehaviour
{
    public Button btn;

    public GameObject deActivate;
    public GameObject Activate;

    public SpriteRenderer gsLeft;
    public SpriteRenderer gsUp;
    public SpriteRenderer gsRight;
    public SpriteRenderer gsDown;

    void Start()
    {
        btn.onClick.AddListener(activate);
    }

    void activate()
    {
        deActivate.SetActive(false);
        Activate.SetActive(true);

        gsLeft.enabled = false;
        gsUp.enabled = false;
        gsRight.enabled = false;
        gsDown.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activate();
        }
    }
}
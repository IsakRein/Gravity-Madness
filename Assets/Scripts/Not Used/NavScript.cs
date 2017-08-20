using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavScript : MonoBehaviour {
    public Button navLeft;
    public Button navRight;

    public Text txt;

    public GameObject levelsUI;

    public string currentPackName;

    public int currentPack = 1;

    // Use this for initialization
    void Start () {
        currentPack = 1;
        currentPackName = "Pack (" + currentPack + ")";

        navLeft.interactable = false;
        navRight.interactable = true;

        navLeft.onClick.AddListener(LeftOnClick);
        navRight.onClick.AddListener(RightOnClick);
        txt.text = "Pack " + currentPack;
    }


    void DisplayPack(int pack)
    {
        foreach (Transform child in levelsUI.transform)
        {
            currentPackName = "Pack (" + currentPack + ")";
            if (child.name == currentPackName)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
       
    }

    void Update()
    {
        if (currentPack == 1)
        {
            navLeft.interactable = false;
        }
        else
        {
            navLeft.interactable = true;
        }

        if (currentPack == levelsUI.transform.childCount)
        {
            navRight.interactable = false;
        }
        else
        {
            navRight.interactable = true;
        }
    }

    void LeftOnClick()
    {
        currentPack = currentPack - 1;
        DisplayPack(currentPack);
        txt.text = "Pack " + currentPack;
    }

    void RightOnClick()
    {
        currentPack = currentPack + 1;
        DisplayPack(currentPack);
        txt.text = "Pack " + currentPack;
    }
}

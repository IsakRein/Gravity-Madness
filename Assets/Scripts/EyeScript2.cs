using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript2 : MonoBehaviour {
    public Transform otherEye;
    void Update () {
        transform.rotation = otherEye.rotation;
    }
}

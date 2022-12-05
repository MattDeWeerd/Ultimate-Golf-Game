using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceWriter : MonoBehaviour
{
    public static Text ForceText;
    private static float force = 0;

    private void Start()
    {
        ForceText = GetComponent<Text>();
    }

    public static void setForce(float toSet)
    {
        force = toSet;
        ForceText.text = "FORCE: " + force;
    }

    public static void resetForce()
    {
        force = 0;
        ForceText.text = "FORCE: " + force;
    }
}

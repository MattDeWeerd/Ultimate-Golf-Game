using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeCounter : MonoBehaviour
{
    public static Text StrokeText;
    private static int strokeCount = 0;

    private void Start()
    {
        StrokeText = GetComponent<Text>();
    }

    public static void increaseStrokes()
    {
        strokeCount++;
        StrokeText.text = "STROKES: " + strokeCount;
    }

    public static void resetStrokes()
    {
        strokeCount = 0;
        StrokeText.text = "STROKES: " + strokeCount;
    }
}

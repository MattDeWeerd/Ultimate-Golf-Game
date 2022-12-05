using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager Instance;
    // Start is called before the first frame update
    void Start()
    {

        if(Instance == null)
        {
            Instance = this;
        } else
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}

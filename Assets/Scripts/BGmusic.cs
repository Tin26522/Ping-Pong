using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{    
    private static BGmusic bgmusic;

     void Awake()
    {
        if (bgmusic == null)
        {
            bgmusic = this;
            DontDestroyOnLoad(bgmusic);
        }

        else
        {
            Destroy(bgmusic);
        }
    }
}

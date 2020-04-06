using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class level1 : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<level1>().Length;
        if (numMusicPlayers != 1) { Object.Destroy(gameObject); }
        Object.DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update



}

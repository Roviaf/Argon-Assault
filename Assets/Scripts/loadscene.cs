﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadscene : MonoBehaviour
{
    void Start()
    {
        Invoke("musicafterload", 2f);
    }



    private void musicafterload()
    {
        SceneManager.LoadScene(1);
    }

}

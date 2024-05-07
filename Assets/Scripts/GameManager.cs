using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject levelUP;

    //public static GameObject levelup = new GameObject();

    void Start()
    {
        levelUP.SetActive(false);
    }

    void Update()
    {
        if (TimeManager.Timeflg == 1)
        {
            Time.timeScale = 0.0f;
            levelUP.SetActive(true);
        }
    }
}

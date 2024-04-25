using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject levelUP;
    public GameObject title;
    public GameObject Return;


    public static int flg = 0;
    //public static GameObject levelup = new GameObject();

    void Start()
    {
        levelUP.SetActive(false);
        title.SetActive(false);
        Return.SetActive(false);
    }

    void Update()
    {
        if (TimeManager.Timeflg == 1 && flg == 0)
        {
            Time.timeScale = 0.0f;
            levelUP.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TimeManager.Timeflg = 1;
            flg = 1;
            Time.timeScale = 0.0f;
            title.SetActive(true);
            Return.SetActive(true);
        }
    }
}

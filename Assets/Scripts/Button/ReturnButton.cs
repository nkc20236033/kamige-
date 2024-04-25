using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{

    public GameObject title;
    public GameObject Return;

    public void OnClick()
    {
        TimeManager.Timeflg = 0;
        GameManager.flg = 0;
        Time.timeScale = 1.0f;
        title.SetActive(false);
        Return.SetActive(false);
    }
}

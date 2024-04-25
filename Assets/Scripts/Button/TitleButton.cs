using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void OnClick()
    {
        TimeManager.Timeflg = 0;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject levelUP;

    Button button;

    public void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnClick()
    {
        TimeManager.Timeflg = 0;
        Time.timeScale = 1.0f;
        levelUP.SetActive(false);
        Debug.Log("‹­‰»Š®—¹");
    }
}

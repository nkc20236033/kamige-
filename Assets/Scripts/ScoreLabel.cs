using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{

    public int Score; //�G��|�������̉��Z�X�R�A
    public Text ScoreText;
    
    public void ScoreAdd()
    {
        Score = Score + 100;
        ScoreText.text = "�X�R�A�F" + Score.ToString();
    }
}

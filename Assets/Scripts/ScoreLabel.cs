using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{

    public int Score; //敵を倒した時の加算スコア
    public Text ScoreText;
    
    public void ScoreAdd()
    {
        Score = Score + 100;
        ScoreText.text = "スコア：" + Score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountLabel : MonoBehaviour
{

    public int Cnt; //�G��|������
    public Text CntText;

    public void CountAdd()
    {
        Cnt++;
        CntText.text = "�|�����G�F" +  Cnt.ToString();
    }
}
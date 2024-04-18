using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountLabel : MonoBehaviour
{

    public int Cnt; //“G‚ğ“|‚µ‚½”
    public Text CntText;

    public void CountAdd()
    {
        Cnt++;
        CntText.text = "“|‚µ‚½“GF" +  Cnt.ToString();
    }
}
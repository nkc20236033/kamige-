using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCon : MonoBehaviour
{
    //追加　XとYの上限
    float yLimit = 0f;
    // キャラクターオブジェクト
    public GameObject playerObj;
    // カメラとの距離
    private Vector3 offset;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - playerObj.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;

        currentPos.y = yLimit;

        transform.position = currentPos;

        transform.position = playerObj.transform.position + offset;
    }
}

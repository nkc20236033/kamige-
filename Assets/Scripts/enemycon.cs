using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float speed = 2.0f; // 上下の速度

    void Update()
    {
        // 上下の動きを制御
        float movement = Mathf.Sin(Time.time * speed); // Sin関数を使って上下の動きを生成
        transform.position = new Vector3(transform.position.x, movement, transform.position.z);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float speed = 2.0f; // �㉺�̑��x

    void Update()
    {
        // �㉺�̓����𐧌�
        float movement = Mathf.Sin(Time.time * speed); // Sin�֐����g���ď㉺�̓����𐶐�
        transform.position = new Vector3(transform.position.x, movement, transform.position.z);
    }
}
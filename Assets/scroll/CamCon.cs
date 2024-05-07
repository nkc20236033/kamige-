using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCon : MonoBehaviour
{
    //�ǉ��@X��Y�̏��
    float yLimit = 0f;

    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;

        currentPos.y = Mathf.Clamp(currentPos.y, -yLimit, yLimit);

        transform.position = currentPos;

    }
}

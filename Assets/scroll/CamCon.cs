using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCon : MonoBehaviour
{
    //�ǉ��@X��Y�̏��
    float yLimit = 0f;
    // �L�����N�^�[�I�u�W�F�N�g
    public GameObject playerObj;
    // �J�����Ƃ̋���
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

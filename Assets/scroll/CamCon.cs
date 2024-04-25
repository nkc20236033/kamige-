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
        transform.position = new Vector3(playerObj.transform.position.x + offset.x, yLimit, playerObj.transform.position.y + offset.y);
    }
}

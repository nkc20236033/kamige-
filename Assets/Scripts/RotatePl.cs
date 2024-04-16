using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePl : MonoBehaviour
{
    // ���S�_
    [SerializeField] private Vector3 _center;

    // ��]��
    [SerializeField] private Vector3 _axis = new Vector3(0, 0, 1);

    // �~�^������
    [SerializeField] private float _period = 2;

    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        _center = player.transform.position;
        // ���S�_center�̎�����A��axis�ŁAperiod�����ŉ~�^��
        transform.RotateAround(
            _center,
            _axis,
            360 / _period * Time.deltaTime
        );
    }
}

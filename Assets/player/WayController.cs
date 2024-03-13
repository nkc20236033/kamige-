using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class WayController : MonoBehaviour
{
    GameObject player;
    Vector3 mousePos, worldPos;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // �v���C���[�̃X�N���[�����W���v�Z����
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // �v���C���[���猩���}�E�X�J�[�\���̕������v�Z����
        var direction = Input.mousePosition - screenPos;

        // �}�E�X�J�[�\�������݂�������̊p�x���擾����
        var angle = Utils.GetAngle(Vector3.zero, direction);

        // �v���C���[���}�E�X�J�[�\���̕���������悤�ɂ���
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;


    }
}

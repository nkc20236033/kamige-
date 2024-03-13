using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    /// <summary>
    /// ���ܕێ����Ă���ŋߐڃ^�[�Q�b�g
    /// </summary>
    [HideInInspector]
    public GameObject Target;

    /// <summary>
    /// �G�^�O�����ԋ߂��Q�[���I�u�W�F�N�g��T���܂��B
    /// </summary>
    /// <returns></returns>
    public GameObject ScanWithFindTag()
    {
        GameObject[] _targets = GameObject.FindGameObjectsWithTag("Enemy");

        float tmp = float.MaxValue; // ������r���邽�߂̈ꎞ�ۑ�
        foreach (GameObject o in _targets)
        {
            // �ł��߂��G�ɓ���ւ�
            float distance_to_enemy =
Vector3.Distance(transform.position, o.transform.position);
            if (distance_to_enemy < tmp)
            {
                tmp = distance_to_enemy;
                Target = o;
            }
        }
        return Target;
    }
}
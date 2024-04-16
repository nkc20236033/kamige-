using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLauncher : MonoBehaviour
{
    [SerializeField] GameObject ice_prefab;
    [SerializeField] Transform MuzzlePosition; // �e�����̈ʒu

    /// <summary>
    /// �e�𓊂�����^�[�Q�b�g
    /// </summary>
    GameObject Target;

    /// <summary>
    /// �G�X�L�����p
    /// </summary>
    EnemyScanner enemyScanner;

    private void Start()
    {
        enemyScanner = GetComponent<EnemyScanner>();
    }

    public void Throw()
    {
        GameObject go = Instantiate(ice_prefab, MuzzlePosition.position, MuzzlePosition.rotation);
        Ice b = go.GetComponent<Ice>();
        b.Shot(transform.position);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLauncher : MonoBehaviour
{
    [SerializeField] GameObject magic_prefab; 
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
        Target = enemyScanner.ScanWithFindTag();

        if (Target == null) return;
        GameObject go = Instantiate(magic_prefab, MuzzlePosition.position, Quaternion.identity);
        Magic b = go.GetComponent<Magic>();
        b.Shot(Target.transform.position);
    }
}
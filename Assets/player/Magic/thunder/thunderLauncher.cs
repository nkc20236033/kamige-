using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderLauncher : MonoBehaviour
{
    [SerializeField] GameObject thunder_prefab;

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
        Instantiate(thunder_prefab, Target.transform.position, Quaternion.identity);
    }
}

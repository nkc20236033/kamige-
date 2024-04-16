using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderLauncher : MonoBehaviour
{
    [SerializeField] GameObject thunder_prefab;

    /// <summary>
    /// 弾を投げつけるターゲット
    /// </summary>
    GameObject Target;

    /// <summary>
    /// 敵スキャン用
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

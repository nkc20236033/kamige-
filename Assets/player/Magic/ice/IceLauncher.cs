using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLauncher : MonoBehaviour
{
    [SerializeField] GameObject ice_prefab;
    [SerializeField] Transform MuzzlePosition; // 弾発生の位置

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
        GameObject go = Instantiate(ice_prefab, MuzzlePosition.position, MuzzlePosition.rotation);
        Ice b = go.GetComponent<Ice>();
        b.Shot(transform.position);
    }
}
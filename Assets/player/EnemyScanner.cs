using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    /// <summary>
    /// いま保持している最近接ターゲット
    /// </summary>
    [HideInInspector]
    public GameObject Target;

    /// <summary>
    /// 敵タグから一番近いゲームオブジェクトを探します。
    /// </summary>
    /// <returns></returns>
    public GameObject ScanWithFindTag()
    {
        GameObject[] _targets = GameObject.FindGameObjectsWithTag("Enemy");

        float tmp = float.MaxValue; // 距離比較するための一時保存
        foreach (GameObject o in _targets)
        {
            // 最も近い敵に入れ替え
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
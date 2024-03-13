using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyController EnemyPrefab; // 敵のプレハブを管理する
    public float interval; // 出現間隔（秒）
    public EnemyController BossPrefab;  //ボスのプレハブを管理する
    private float m_timer; // 出現タイミングを管理するタイマー
    public float timeTrigger;

    private void Start()
    {
        Debug.Log("start");
    }

    // 毎フレーム呼び出される関数
    private void Update()
    {
        // 出現タイミングを管理するタイマーを更新する
        m_timer += Time.deltaTime;

        // まだ敵が出現するタイミングではない場合、
        // このフレームの処理はここで終える
        if (m_timer < interval) return;

        // 出現タイミングを管理するタイマーをリセットする
        m_timer = 0;

        // 敵のゲームオブジェクトを生成する
        var Enemy = Instantiate(EnemyPrefab);

        // 敵を画面外のどの位置に出現させるかランダムに決定する
        var respawnType = (EnemyController.RESPAWN_TYPE)Random.Range(
            0, (int)EnemyController.RESPAWN_TYPE.SIZEOF);

        Enemy.Init(respawnType);

        //ボス出現処理
        if (Time.time > timeTrigger)
        {
            var Boss = Instantiate(BossPrefab);
            respawnType = (EnemyController.RESPAWN_TYPE)Random.Range(
            0, (int)EnemyController.RESPAWN_TYPE.SIZEOF);

            Boss.Init(respawnType);
            Debug.Log("ボス出現！！");

            timeTrigger = timeTrigger + 300;
            Debug.Log(timeTrigger);
        }
    }
}

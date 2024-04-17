using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private BoxCollider2D boxcol;
    private GameObject player;

    public Vector2 m_respawnPosInside; // 敵の出現位置（内側）
    public Vector2 m_respawnPosOutside; // 敵の出現位置（外側）
    public static int EnemyHP;
    public int EnemyEXP;
    public static int m_damage;
    public GameObject EXP;
    public GameObject AllCollect;

    // 敵の出現位置の種類
    public enum RESPAWN_TYPE
    {
        UP, // 上
        RIGHT, // 右
        DOWN, // 下
        LEFT, // 左
        SIZEOF, // 敵の出現位置の数
    }

    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];

        EnemyHP = 10;
        m_damage = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pv = player.transform.position;
        Vector3 ev = transform.position;

        float p_vX = pv.x - ev.x;
        float p_vY = pv.y - ev.y;

        float vx;
        float vy;

        float sp = 10f;

        float enemydelay = 5000;

        // 減算した結果がマイナスであればXは減算処理
        if (p_vX < 0)
        {
            vx = -sp;
        }
        else
        {
            vx = sp;
        }

        // 減算した結果がマイナスであればYは減算処理
        if (p_vY < 0)
        {
            vy = -sp;
        }
        else
        {
            vy = sp;
        }

        transform.Translate(vx / enemydelay, vy / enemydelay, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "magic")
        {    
                EnemyHP -= m_damage;
                Debug.Log(m_damage + "のダメージ");


            if (EnemyHP <= 0)
            {
                Debug.Log("撃破");
                Instantiate(EXP, transform.position, Quaternion.identity);
                int r = Random.Range(1, 1001);
                if (r == 1000)
                {
                    Instantiate(AllCollect, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }

    public void Init(RESPAWN_TYPE respawnType)
    {
        var pos = Vector3.zero;
        Vector2 Plpos  = PlayerController.playerpos;

        // 指定された出現位置の種類に応じて、
        // 出現位置と進行方向を決定する
        switch (respawnType)
        {
            // 出現位置が上の場合
            case RESPAWN_TYPE.UP:
                pos.x = Random.Range(
                    -10,10);
                pos.y = Plpos.y + 7;
                break;

            // 出現位置が右の場合
            case RESPAWN_TYPE.RIGHT:
                pos.x = Plpos.x + 10;
                pos.y = Random.Range(
                    -7, 7);
                break;

            // 出現位置が下の場合
            case RESPAWN_TYPE.DOWN:
                pos.x = Random.Range(
                    -10, 10);
                pos.y = Plpos.y - 7;
                break;

            // 出現位置が左の場合
            case RESPAWN_TYPE.LEFT:
                pos.x = Plpos.x - 10;
                pos.y = Random.Range(
                    -7, 7);
                break;
        }

        // 位置を反映する
        transform.localPosition = pos;

        GetComponent<Renderer>().material.color = Color.blue;
    }
}

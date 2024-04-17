using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private BoxCollider2D boxcol;
    private GameObject player;

    public Vector2 m_respawnPosInside; // �G�̏o���ʒu�i�����j
    public Vector2 m_respawnPosOutside; // �G�̏o���ʒu�i�O���j
    public static int EnemyHP;
    public int EnemyEXP;
    public static int m_damage;
    public GameObject EXP;
    public GameObject AllCollect;

    // �G�̏o���ʒu�̎��
    public enum RESPAWN_TYPE
    {
        UP, // ��
        RIGHT, // �E
        DOWN, // ��
        LEFT, // ��
        SIZEOF, // �G�̏o���ʒu�̐�
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

        // ���Z�������ʂ��}�C�i�X�ł����X�͌��Z����
        if (p_vX < 0)
        {
            vx = -sp;
        }
        else
        {
            vx = sp;
        }

        // ���Z�������ʂ��}�C�i�X�ł����Y�͌��Z����
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
                Debug.Log(m_damage + "�̃_���[�W");


            if (EnemyHP <= 0)
            {
                Debug.Log("���j");
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

        // �w�肳�ꂽ�o���ʒu�̎�ނɉ����āA
        // �o���ʒu�Ɛi�s���������肷��
        switch (respawnType)
        {
            // �o���ʒu����̏ꍇ
            case RESPAWN_TYPE.UP:
                pos.x = Random.Range(
                    -10,10);
                pos.y = Plpos.y + 7;
                break;

            // �o���ʒu���E�̏ꍇ
            case RESPAWN_TYPE.RIGHT:
                pos.x = Plpos.x + 10;
                pos.y = Random.Range(
                    -7, 7);
                break;

            // �o���ʒu�����̏ꍇ
            case RESPAWN_TYPE.DOWN:
                pos.x = Random.Range(
                    -10, 10);
                pos.y = Plpos.y - 7;
                break;

            // �o���ʒu�����̏ꍇ
            case RESPAWN_TYPE.LEFT:
                pos.x = Plpos.x - 10;
                pos.y = Random.Range(
                    -7, 7);
                break;
        }

        // �ʒu�𔽉f����
        transform.localPosition = pos;

        GetComponent<Renderer>().material.color = Color.blue;
    }
}

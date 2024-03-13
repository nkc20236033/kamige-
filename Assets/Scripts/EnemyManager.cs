using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyController EnemyPrefab; // �G�̃v���n�u���Ǘ�����
    public float interval; // �o���Ԋu�i�b�j
    public EnemyController BossPrefab;  //�{�X�̃v���n�u���Ǘ�����
    private float m_timer; // �o���^�C�~���O���Ǘ�����^�C�}�[
    public float timeTrigger;

    private void Start()
    {
        Debug.Log("start");
    }

    // ���t���[���Ăяo�����֐�
    private void Update()
    {
        // �o���^�C�~���O���Ǘ�����^�C�}�[���X�V����
        m_timer += Time.deltaTime;

        // �܂��G���o������^�C�~���O�ł͂Ȃ��ꍇ�A
        // ���̃t���[���̏����͂����ŏI����
        if (m_timer < interval) return;

        // �o���^�C�~���O���Ǘ�����^�C�}�[�����Z�b�g����
        m_timer = 0;

        // �G�̃Q�[���I�u�W�F�N�g�𐶐�����
        var Enemy = Instantiate(EnemyPrefab);

        // �G����ʊO�̂ǂ̈ʒu�ɏo�������邩�����_���Ɍ��肷��
        var respawnType = (EnemyController.RESPAWN_TYPE)Random.Range(
            0, (int)EnemyController.RESPAWN_TYPE.SIZEOF);

        Enemy.Init(respawnType);

        //�{�X�o������
        if (Time.time > timeTrigger)
        {
            var Boss = Instantiate(BossPrefab);
            respawnType = (EnemyController.RESPAWN_TYPE)Random.Range(
            0, (int)EnemyController.RESPAWN_TYPE.SIZEOF);

            Boss.Init(respawnType);
            Debug.Log("�{�X�o���I�I");

            timeTrigger = timeTrigger + 300;
            Debug.Log(timeTrigger);
        }
    }
}

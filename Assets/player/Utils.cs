using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �֗��Ȋ֐����Ǘ��𐫓I�N���X
public static class Utils
{

    // �ړ��\�Ȕ͈�
    public static Vector2 m_moveLimit = new Vector2(4.15f, 3.0f);

    // �w�肳�ꂽ�ʒu���ړ��\�Ȕ͈͂Ɏ��߂��l��Ԃ�
    public static Vector3 ClampPosition(Vector3 position)
    {
        // Mathf.Clamp(�����������I�u�W�F�N�g�̍��W,���W�̍ŏ��l,���W�̍ő�l)
        return new Vector3(
            Mathf.Clamp(position.x, -m_moveLimit.x, m_moveLimit.x),
            Mathf.Clamp(position.y, -m_moveLimit.y, m_moveLimit.y),
            0
        );
    }

    public static float GetAngle(Vector2 from, Vector2 to)
    {
        // �w�肳�ꂽ2�̈ꂩ��p�x�����߂�
        var dx = to.x - from.x;
        var dy = to.y - from.y;
        var rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

}

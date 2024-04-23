using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CaveGenerator : MonoBehaviour
{
    // ��̍��W
    [SerializeField]
    float offsetX = 960;
    [SerializeField]
    float offsetY = 1020;

    // ���������p
    float heightScale = 50.0f;
    // �p�[�����m�C�Y�̓ǂݎ��Ԋu
    float xScale = 0.02f;
    // Unity��Ŏ��ۂɔz�u����Ԋu
    float xSpace = 10.0f;

    // �㉺���]�B
    public bool yReverse;
    // SpriteShapeController
    SpriteShapeController spriteShapeController;

    // �������钸�_��
    [SerializeField]
    int PointCount = 1000;

    // ������
    void Awake()
    {
        spriteShapeController = GetComponent<SpriteShapeController>();
        spriteShapeController.spline.Clear();
    }

    // ���A����
    void Start()
    {
        // �p�[�����m�C�Y�ǂݎ��J�n�ʒu�������_���Őݒ�B
        // �Ȃ��Ɩ��񓯂��`�ɂȂ�B
        var randomXoffset = Random.Range(0, 2);
        var randomXoffset2 = Random.Range(0, 2);

        Spline spline = spriteShapeController.spline;

        // �K�v�Ȃ�㉺���]
        if (yReverse)
        {
            offsetY = -offsetY;
        }

        // 0�ڂ�Spline�̃|�C���g�𐶐�
        spline.InsertPointAt(0, new Vector2(-offsetX, -offsetY));

        // Spline�̃|�C���g��z�u���Ă����B
        for (int i = 1; i < PointCount; i++)
        {
            // �p�[�����m�C�Y���獂���𐶐�
            float height = heightScale * Mathf.PerlinNoise(randomXoffset + i * xScale, 0.0f);
            // �ꉞ��d�Ƀp�[�����m�C�Y���獂��������Ă݂�(�Ӗ��Ȃ�����)�B
            height += heightScale * Mathf.PerlinNoise(randomXoffset2 + i * xScale, 0.0f);

            if (yReverse)
            {
                height = -height;
            }

            // Spline�̃|�C���g�̔z�u�Ԋu�ɗh�炬��^����B
            var randomSpace = Random.Range(0, 3);
            // Spline�̃|�C���g�����ۂ�Unity��Ŕz�u����ʒu�����߂�B
            Vector2 pos = new Vector2((i * xSpace + randomSpace) - offsetX, height - offsetY);
            // Spline�̃|�C���g��ǉ�
            spline.InsertPointAt(i, pos);
        }
        // 0�ڂ�Spline�̃|�C���g�ƂȂ����Ēn�ʂ�h��Ԃ� 
        spline.InsertPointAt(PointCount, new Vector2(PointCount * xSpace - offsetX, -offsetY));
        spriteShapeController.RefreshSpriteShape();
    }
}

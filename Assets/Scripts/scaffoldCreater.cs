using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CaveGenerator : MonoBehaviour
{
    // 基準の座標
    [SerializeField]
    float offsetX = 960;
    [SerializeField]
    float offsetY = 1020;

    // 高さ調整用
    float heightScale = 50.0f;
    // パーリンノイズの読み取り間隔
    float xScale = 0.02f;
    // Unity状で実際に配置する間隔
    float xSpace = 10.0f;

    // 上下反転。
    public bool yReverse;
    // SpriteShapeController
    SpriteShapeController spriteShapeController;

    // 生成する頂点数
    [SerializeField]
    int PointCount = 1000;

    // 初期化
    void Awake()
    {
        spriteShapeController = GetComponent<SpriteShapeController>();
        spriteShapeController.spline.Clear();
    }

    // 洞窟生成
    void Start()
    {
        // パーリンノイズ読み取り開始位置をランダムで設定。
        // ないと毎回同じ形になる。
        var randomXoffset = Random.Range(0, 2);
        var randomXoffset2 = Random.Range(0, 2);

        Spline spline = spriteShapeController.spline;

        // 必要なら上下反転
        if (yReverse)
        {
            offsetY = -offsetY;
        }

        // 0個目のSplineのポイントを生成
        spline.InsertPointAt(0, new Vector2(-offsetX, -offsetY));

        // Splineのポイントを配置していく。
        for (int i = 1; i < PointCount; i++)
        {
            // パーリンノイズから高さを生成
            float height = heightScale * Mathf.PerlinNoise(randomXoffset + i * xScale, 0.0f);
            // 一応二重にパーリンノイズから高さを取ってみる(意味ないかも)。
            height += heightScale * Mathf.PerlinNoise(randomXoffset2 + i * xScale, 0.0f);

            if (yReverse)
            {
                height = -height;
            }

            // Splineのポイントの配置間隔に揺らぎを与える。
            var randomSpace = Random.Range(0, 3);
            // Splineのポイントを実際にUnity上で配置する位置を決める。
            Vector2 pos = new Vector2((i * xSpace + randomSpace) - offsetX, height - offsetY);
            // Splineのポイントを追加
            spline.InsertPointAt(i, pos);
        }
        // 0個目のSplineのポイントとつながって地面を塗りつぶす 
        spline.InsertPointAt(PointCount, new Vector2(PointCount * xSpace - offsetX, -offsetY));
        spriteShapeController.RefreshSpriteShape();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPController : MonoBehaviour
{
    
    private BoxCollider2D boxcol;
    private GameObject player;

    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }
    
    void FixedUpdate()
    {
        //全収集
        if (PlayerController.EXPflg == 1)
        {

            Vector3 pv = player.transform.position;
            Vector3 ev = transform.position;

            float p_vX = pv.x - ev.x;
            float p_vY = pv.y - ev.y;

            float vx;
            float vy;

            float sp = 10f;

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

            transform.Translate(vx / 100, vy / 100, 0);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

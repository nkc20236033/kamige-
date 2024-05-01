using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0f;
    Rigidbody2D rb;
    Animator animator;
    public int playerHP;
    public GameObject heart;
    public static Vector2 playerpos;
    public static  int playerEXP;          //経験値量
    float EXPlimit = 10;    //必要経験値量
    int playerLevel;　　　　 //プレイヤーのレベル

    public static int EXPflg;      //全回収用フラグ


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHP = 3;
    }
    
    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"));
        moveDirection.Normalize();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        playerpos = transform.position;

        //Vector2 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        //pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        //transform.position = pos;

        if(playerHP == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHP--;
           
        }

        if (collision.gameObject.CompareTag("EXP"))
        {
            playerEXP = playerEXP + 1;
            Debug.Log(playerEXP);
            
            if (playerEXP == EXPlimit)
            {
                EXPlimit = Mathf.Ceil(EXPlimit * 1.1f);
                playerLevel = playerLevel + 1;
                playerEXP = 0;
                Debug.Log("レベルアップ");

                TimeManager.Timeflg = 1;
            }

        }

        if (collision.gameObject.CompareTag("Collect"))
        {
            EXPflg = 1;
            StartCoroutine(DelayCoroutine());
            Debug.Log("EXPflg = " + EXPflg);
        }
    }


    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(5);

        EXPflg = 0;

        Debug.Log("EXPflg = " + EXPflg);
    }
}

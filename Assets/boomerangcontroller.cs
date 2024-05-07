using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerangcontroller : MonoBehaviour
{
    float speed = 15;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.right * speed;
        speed -= Time.deltaTime*20f;
        transform.Rotate(new Vector3(0, 0, 5));
        Destroy(gameObject,3);
    }
}

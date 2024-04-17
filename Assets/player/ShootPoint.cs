using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public GameObject Bullet;
    float timer = 0;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        timer += 1;
        if (timer % 20 == 0)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}

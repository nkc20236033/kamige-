using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    float speed = 7.0f;

    bool _enbled = false;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void FixedUpdate()
    {
        if (_enbled)
        {
            transform.position += transform.up * Time.deltaTime * speed;
            transform.Translate(0, 0.1f, 0);
        }
    }

    public void Shot(Vector3 target)
    {
        _enbled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}

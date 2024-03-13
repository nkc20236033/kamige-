using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] float Speed = 20;

    bool _enbled = false;
    Vector3 _direction;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        if (_enbled)
        {
            transform.Translate(_direction.normalized * Speed * Time.deltaTime);
        }
    }

    public void Shot(Vector3 target)
    {
        _direction = target - gameObject.transform.position;
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
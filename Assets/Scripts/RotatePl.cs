using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePl : MonoBehaviour
{
    // ’†S“_
    [SerializeField] private Vector3 _center;

    // ‰ñ“]²
    [SerializeField] private Vector3 _axis = new Vector3(0, 0, 1);

    // ‰~‰^“®üŠú
    [SerializeField] private float _period = 2;

    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        _center = player.transform.position;
        // ’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®
        transform.RotateAround(
            _center,
            _axis,
            360 / _period * Time.deltaTime
        );
    }
}

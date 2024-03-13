using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float speed = 2.0f; // ã‰º‚Ì‘¬“x

    void Update()
    {
        // ã‰º‚Ì“®‚«‚ğ§Œä
        float movement = Mathf.Sin(Time.time * speed); // SinŠÖ”‚ğg‚Á‚Äã‰º‚Ì“®‚«‚ğ¶¬
        transform.position = new Vector3(transform.position.x, movement, transform.position.z);
    }
}
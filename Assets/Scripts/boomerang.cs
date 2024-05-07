using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boomerang : MonoBehaviour
{
    public Vector3 bo;
    public GameObject bmr;
    float span;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        span += Time.deltaTime;
        if (span >= 2)
        {
            bo = GameObject.Find("player").transform.position;
            Instantiate(bmr, new Vector3(bo.x,bo.y,bo.z),Quaternion.identity);
            span = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    public float LifeTime;


    void Update()
    {
        Destroy(gameObject, LifeTime);
        speed = 0.02f;
        transform.Translate(Vector3.down * speed);
    }


}

using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    public float LifeTime;
    private SpeedController _spawner;

    private void Start()
    {
        _spawner = FindObjectOfType<SpeedController>();
    }

    void Update()
    {
        speed = _spawner.CurrentSpeed;
        Destroy(gameObject, LifeTime);
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }
}

using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    public float LifeTime;

    void Update()
    {
        Destroy(gameObject, LifeTime);
        transform.Translate(Vector3.down * speed);
    }
}

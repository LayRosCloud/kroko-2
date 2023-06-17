using UnityEngine;

public class MoveBlock : Block
{
    private SpeedController _spawner;

    private void Start()
    {
        _spawner = FindObjectOfType<SpeedController>();
    }

    void Update()
    {
        float speed = _spawner.CurrentSpeed;
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }
}

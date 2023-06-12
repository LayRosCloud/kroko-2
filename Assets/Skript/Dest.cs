using UnityEngine;

public class Dest : MonoBehaviour
{
    public float lifetime;
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

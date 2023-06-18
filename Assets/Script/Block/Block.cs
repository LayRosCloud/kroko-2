using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] protected float _lifetime;
    [SerializeField] protected bool _destroy;
    [SerializeField, Range(0, 100)] private float _spawnChance;

    public float GetSpawnChance()
    {
        return _spawnChance;
    }
    
    private void Start()
    {
        if (_destroy == false)
        {
            return;
        }
        Destroy(gameObject, _lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null)
        {
            EnterPlayer();
        }
    }

    protected virtual void EnterPlayer()
    {
        Debug.Log("Player is enter on collider");
    }
}

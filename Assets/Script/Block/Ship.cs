using System;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Collider _parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null)
        {
            other.GetComponentInParent<PlayerDeath>().Die();
            _parent.isTrigger = true;
        }
    }
}

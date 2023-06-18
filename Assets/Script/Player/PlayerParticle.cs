
using System;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private GameObject _particle;

    private void OnEnable()
    {
        PlayerEvents.Instance.MoveEvent.AddListener(Spawn);
    }

    private void Spawn()
    {
        GameObject gm = Instantiate(_particle);
        gm.transform.position = transform.position;
        Destroy(gm, 0.2f);
    }
}


using System;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField] private GameObject _particle;

    private void OnEnable()
    {
        PlayerEvents.Instance.LeftMoveEvent += Spawn;
        PlayerEvents.Instance.RightMoveEvent += Spawn;
    }

    private void OnDisable()
    {
        PlayerEvents.Instance.RightMoveEvent -= Spawn;
        PlayerEvents.Instance.LeftMoveEvent -= Spawn;
    }

    private void OnDestroy()
    {
        PlayerEvents.Instance.RightMoveEvent -= Spawn;
        PlayerEvents.Instance.LeftMoveEvent -= Spawn;
    }

    private void Spawn()
    {
        GameObject gm = Instantiate(_particle);
        gm.transform.position = transform.position;
        Destroy(gm, 0.2f);
    }
}

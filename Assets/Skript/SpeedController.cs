using System;
using System.Collections;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float CurrentSpeed { get; private set; } = 1f;
    [SerializeField] private float _timeChange = 0.1f;
    [SerializeField] private Player _player;
    private Spawner _spawner;
    private Coroutine _addCooldownCoroutine;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    public void AddValue()
    {
        if (_addCooldownCoroutine == null)
        {
            _addCooldownCoroutine = StartCoroutine(CooldownAdded());
        }
    }

    private IEnumerator CooldownAdded()
    {
         yield return new WaitForSeconds(_timeChange);
         CurrentSpeed += 0.01f;
         _player.Rigidbody.mass += 0.03f;
         _spawner.SetSpawnCooldownBlocks(_spawner.SpawnCooldownBlocks - 0.03f);
         _addCooldownCoroutine = null;
    }
}
